// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.MultiTenancy.Tests;

public class CurrentTenantTests
{
    [Fact]
    public void CurrentTenant_Tenant_ShouldShouldBeNullAsDefault()
    {
        // Arrange
        var moq = new Mock<ICurrentTenant>();
        var currentTenant = moq.Object;

        // Act
        var tenant = currentTenant.Tenant;

        // Assert
        Assert.Null(tenant);
    }
}