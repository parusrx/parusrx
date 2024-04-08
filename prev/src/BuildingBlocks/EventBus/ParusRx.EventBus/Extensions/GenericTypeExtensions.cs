// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus.Extensions;

/// <summary>
/// Helpful extensions methods on <see cref="Type"/>.
/// </summary>
public static class GenericTypeExtensions
{
    /// <summary>
    /// Returns the name of a generic type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>Returns the type name.</returns>
    public static string GetGenericTypeName(this Type type)
    {
        var typeName = string.Empty;

        if (!type.IsGenericType)
        {
            var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());
            typeName = $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
        }
        else
        {
            typeName = type.Name;
        }

        return typeName;
    }

    /// <summary>
    /// Returns the name of a generic type.
    /// </summary>
    /// <param name="obj">An objects.</param>
    /// <returns>Returns the type name.</returns>
    public static string GetGenericTypeName(this object obj)
        => obj.GetType().GetGenericTypeName();
}
