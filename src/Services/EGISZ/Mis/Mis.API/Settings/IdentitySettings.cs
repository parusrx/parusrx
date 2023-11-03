// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API;

public class IdentitySettings
{
    public const string Identity = "Identity";
    public string Url { get; set; } = default!;
    public TimeSpan TokenCacheExpiration { get; set; } = TimeSpan.FromMinutes(5);
}
