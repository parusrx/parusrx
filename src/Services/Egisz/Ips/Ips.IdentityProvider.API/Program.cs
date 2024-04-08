// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using LibCore.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParusRx.Egisz.Ips.IdentityProvider.API.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.Jwt));

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

LibCore.Initializer.Initialize();

var app = builder.Build();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapGet("auth/token", (IOptionsSnapshot<JwtSettings> settings) => 
{
    // Creating a JWT token. See: https://datatracker.ietf.org/doc/html/rfc7519

    JwtSettings jwtSettings = settings.Value;

    using X509Certificate2 certificate = X509CertificateExtensions.Create(jwtSettings.Certificate.Path, jwtSettings.Certificate.Password, CpX509KeyStorageFlags.CspNoPersistKeySet);

    string alg = certificate.GetKeyAlgorithm() switch
    {
        "1.2.643.7.1.1.1.1" => "ECGOST3410-2012",
        "1.2.643.7.1.1.1.2" => "ECGOST3410-2012",
        _ => throw new NotSupportedException($"Key algorithm {certificate.GetKeyAlgorithm()} is not supported.")
    };

    JwtHeader header = new()
    {
        { "alg", alg },
        { "x5c", new List<string> { Convert.ToBase64String(certificate.GetRawCertData()) } }
    };

    JwtPayload payload = new()
    {
        { "sub", jwtSettings.Auth.Subject },
        { "aud", jwtSettings.Auth.Audience },
        { "iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds() },
        { "exp", DateTimeOffset.UtcNow.Add(jwtSettings.Auth.TokenLifetime).ToUnixTimeSeconds() }
    };

    JwtSecurityToken token = new(header, payload);

    string message = token.EncodedHeader + "." + token.EncodedPayload;
    
    ContentInfo contentInfo = new(Encoding.UTF8.GetBytes(message));
    SignedCms signedCms = new(contentInfo, true);
    CmsSigner cmsSigner = new(certificate)
    { 
        IncludeOption = X509IncludeOption.EndCertOnly 
    };
    signedCms.ComputeSignature(cmsSigner);
    signedCms.RemoveCertificate(certificate);

    byte[] signature = signedCms.Encode();

    AuthTokenResponse authTokenResponse = new($"{message}.{Base64UrlEncoder.Encode(signature)}", token.ValidTo, "Bearer");
    
    return Results.Ok(authTokenResponse);
});

app.Run();

record AuthTokenResponse(
    [property: JsonPropertyName("token")] string Token, 
    [property: JsonPropertyName("expires_in")] DateTimeOffset ExpiresIn,
    [property: JsonPropertyName("token_type")] string TokenType);
