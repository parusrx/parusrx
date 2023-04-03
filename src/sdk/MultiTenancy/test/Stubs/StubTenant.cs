// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRX.MultiTenancy.Tests.Stubs;

internal class StubTenant : ITenant 
{ 
    public string Name { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}