// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Services;

/// <summary>
/// Provides methods allowing to work with files in HRlink.
/// </summary>
/// <param name="httpClient">The <see cref="HttpClient"/>.</param>
public sealed class FileService(HttpClient httpClient) : IFileService
{
    /// </inheritdoc>
    public async ValueTask<FilesUploadResponse?> UploadAsync(FilesUploadRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        string uri = $"{request.Authorization.Url}/api/v1/files";
        httpClient.DefaultRequestHeaders.Add("User-Api-Token", request.Authorization.ApiToken);

        using var content = new MultipartFormDataContent();
        List<File> files = request.Files.Select(file => new File(file.FileName, Convert.FromBase64String(file.Content))).ToList();
        foreach (File file in files)
        {
            content.Add(new ByteArrayContent(file.Content.ToArray()), "files", file.FileName);
        }

        var response = await httpClient.PostAsync(uri, content, cancellationToken);

        response.EnsureSuccessStatusCode();

        var filesUploadResponse = await response.Content.ReadFromJsonAsync<FilesUploadResponse>(cancellationToken: cancellationToken);
        return filesUploadResponse;
    }

    record File(string FileName, ReadOnlyMemory<byte> Content);
}