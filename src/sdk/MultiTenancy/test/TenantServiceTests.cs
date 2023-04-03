// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRX.MultiTenancy.Tests;

public class TenantServiceTests
{
    [Fact]
    public void TenantService_Tenant_ShouldShouldBeNullAsDefault()
    {
        // Arrange
        var tenantService = new TenantService();

        // Act
        var tenant = tenantService.Tenant;

        // Assert
        Assert.Null(tenant);
    }

    [Fact]
    public void TenantService_Tenant_ShouldShouldBeSet()
    {
        // Arrange
        var tenantService = new TenantService();
        var tenant = new StubTenant
        {
            Name = "Test"
        };

        // Act
        tenantService.SetTenant(tenant);

        // Assert
        Assert.Equal(tenant, tenantService.Tenant);
    }
}