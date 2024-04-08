// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Infrastructure.Utility;

/// <summary>
/// This it the Hash utility class.
/// </summary>
public static class HashUtility
{
    /// <summary>
    /// Retrieves the MD5 hash value.
    /// </summary>
    /// <param name="inputAsBase64">The input string in Base64 encoding.</param>
    /// <returns>Returns the MD5 hash value.</returns>
    public static string GetMD5Hash(string inputAsBase64)
    {
        using var md5 = MD5.Create();
        var hash = md5.ComputeHash(Convert.FromBase64String(inputAsBase64));

        var sb = new StringBuilder();
        for (var i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }

        return sb.ToString();
    }
}
