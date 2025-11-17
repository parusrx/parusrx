// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Services;

public interface IDocumentPrintFormFileService
{
    ValueTask<PrintFormFileResponse> GetPrintFormFileAsync(DocumentPrintFormFileRequest request, CancellationToken cancellationToken = default);
}
