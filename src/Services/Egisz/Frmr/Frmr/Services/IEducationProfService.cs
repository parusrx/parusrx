// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.Services;

public interface IEducationProfService
{
    public ValueTask<SingleResponse<EducationProf>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
    public ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, EducationProf educationProf, CancellationToken cancellationToken);
    public ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, EducationProf educationProf, CancellationToken cancellationToken);
    public ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
}
