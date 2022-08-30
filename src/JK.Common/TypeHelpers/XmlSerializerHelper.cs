using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace JK.Common.TypeHelpers;

/// <summary>
/// Wrapper/facade for XML Serialization/Deserialization functionality of .NET.
/// </summary>
public static class XmlSerializerHelper
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
        var settings = new XmlWriterSettings
        {
            Indent = false,
            Encoding = Encoding.UTF8,
            NewLineHandling = NewLineHandling.None,
            OmitXmlDeclaration = true
        };
        var builder = new StringBuilder();
        using var writer = XmlWriter.Create(builder, settings);
        var ns = new XmlSerializerNamespaces();
        ns.Add("", "");
        var serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(writer, entity, ns);
        return builder.ToString();
    }
}
