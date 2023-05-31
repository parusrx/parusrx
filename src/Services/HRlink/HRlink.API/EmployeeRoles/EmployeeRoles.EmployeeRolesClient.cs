// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRLink.API.EmployeeRoles;

/// <summary>
/// The employee role client.
/// </summary>
public interface IEmployeeRolesClient
{
    /// <summary>
    /// Gets the employee roles from the HRLink API.
    /// </summary>
    /// <param name="url">The URL to the employee roles on the HRLink API.</param>
    /// <param name="apiToken">The API token used to authenticate the request.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> used to abort the request.</param>
    /// <returns>The <see cref="EmployeeRolesResponse"/> or <see langword="null"/> if the employee roles are not found.</returns>
    Task<EmployeeRolesResponse?> GetEmployeeRolesAsync(string url, string apiToken, CancellationToken cancellationToken = default);
}

/// <summary>
/// The default employee role client.
/// <para>
/// This implementation uses <see cref="HttpClient"/> to retrieve the employee roles from the HRLink API.
/// </para>
/// </summary>
internal sealed class EmployeeRolesClient : IEmployeeRolesClient
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeRolesClient"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public EmployeeRolesClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc/>
    public async Task<EmployeeRolesResponse?> GetEmployeeRolesAsync(string url, string apiToken, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentNullException(nameof(url));
        }

        if (string.IsNullOrWhiteSpace(apiToken))
        {
            throw new ArgumentNullException(nameof(apiToken));
        }

        _httpClient.BaseAddress = new Uri(url);
        _httpClient.DefaultRequestHeaders.Add("User-Api-Token", apiToken);

        var employeeResponse = await _httpClient.GetFromJsonAsync<EmployeeRolesResponse?>("api/v1/employeeRoles", cancellationToken);
        return employeeResponse;
    }
}
