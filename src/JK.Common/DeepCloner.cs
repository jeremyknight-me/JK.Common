﻿using System;
using System.IO;
using System.Xml.Serialization;

namespace JK.Common;

/// <summary>
/// Object used to create deep clones using XML serialization.
/// </summary>
public static class DeepCloner
{
    /// <summary>
    /// Clones the given object.
    /// </summary>
    /// <param name="valueToClone">Object to clone.</param>
    /// <returns>Exact clone of an object.</returns>
    public static object Clone(in object valueToClone)
    {
        if (valueToClone is null)
        {
            throw new ArgumentNullException(nameof(valueToClone));
        }

        using var stream = new MemoryStream();
        var serializer = new XmlSerializer(valueToClone.GetType());
        serializer.Serialize(stream, valueToClone);
        stream.Position = 0;
        return serializer.Deserialize(stream);
    }
}
