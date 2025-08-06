// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Services;

public interface IPersonAccreditationService
{
    public ValueTask<SingleResponse<PersonAccreditation>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
}
