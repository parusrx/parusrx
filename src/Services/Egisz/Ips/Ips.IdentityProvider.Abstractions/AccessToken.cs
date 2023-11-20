// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace ParusRx.Ips.IdentityProvider;

public record AccessToken(
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("expires_in")] DateTimeOffset ExpiresIn,
    [property: JsonPropertyName("token_type")] string TokenType);

