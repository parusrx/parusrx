// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Helpers;

/// <summary>
/// Represents a helper to calculate the status of the document.
/// </summary>
public static class CalculateDocumentStatusHelper
{
    /// <summary>
    /// Calculate the status of the document.
    /// </summary>
    /// <param name="document">The document.</param>
    /// <returns>The status of the document.</returns>
    public static int GetStatus(Document document)
        => (document.Draft, document.BaseDocumentId, document.Deleted, document.DocflowFinishedDate, document.Signed, document.Rejected, document.AnnulledDate) switch
        {
            (true, null, _, _, _, _, _) => 1,
            (false, not null, false, null, _, _, _) => 2,
            (_, not null, false, not null, true, _, _) => 4,
            (_, not null, _, not null, _, true, _) => 5,
            (_, _, true, _, _, _, _) => 6,
            (_, _, _, _, _, _, not null) => 7,
            _ => -1
        };
}
