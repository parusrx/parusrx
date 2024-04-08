// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text.Json.Serialization;

namespace ParusRx.Egisz.Ips.IdentityProvider;

public record AccessToken(
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("expires_in")] DateTimeOffset ExpiresIn,
    [property: JsonPropertyName("token_type")] string TokenType);

