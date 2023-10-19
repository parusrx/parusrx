// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.IPS.IdentityProvider.API.Settings;

internal class JwtSettings 
{
    public const string Jwt = "Jwt";
    public AuthSettings Auth { get; set; } = default!;
    public CertificateSettings Certificate { get; set; } = default!;
}

internal class AuthSettings
{
    public string Subject { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public TimeSpan TokenLifetime { get; set; } = default!;
}

internal class CertificateSettings
{
    public string Path { get; set; } = default!;
    public string Password { get; set; } = default!;
}
