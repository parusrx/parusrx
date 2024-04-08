// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Ips.IdentityProvider;

public class IdentitySettings
{
    public const string Identity = "Identity";
    public string Url { get; set; } = default!;
    public TimeSpan TokenCacheExpiration { get; set; } = TimeSpan.FromMinutes(5);
}
