using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Serialization;

namespace JK.Common.Xml;

/// <summary>
/// Wrapper/facade for XML Serialization/Deserialization functionality of .NET.
/// </summary>
public static class XmlSerializationFacade
{
    /// <summary>
    /// Uses XML serialization to convert an XML string to its object representation.
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    /// <param name="xml">XML string to turn into an object</param>
    /// <returns>An object of the given type loaded from the given string.</returns>
    public static T DeserializeString<T>(string xml)
    {
        using TextReader reader = new StringReader(xml);
        var serializer = new XmlSerializer(typeof(T));
        return (T)serializer.Deserialize(reader);
    }

    /// <summary>
    /// Uses XML serialization to convert an object into its XML representation.
    /// </summary>
    /// <typeparam name="T">Type of object to turn into XML.</typeparam>
    /// <param name="entity">Object to turn into XML.</param>
    /// <returns>An XML representation of an object as a string.</returns>
    public static string Serialize<T>(in T entity)
    {
        using var stream = new MemoryStream();
        var serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(stream, entity);
        stream.Position = 0;
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
