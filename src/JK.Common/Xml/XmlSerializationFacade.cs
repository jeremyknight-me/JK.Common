using System.IO;
using System.Xml.Serialization;

namespace JK.Common.Xml;

/// <summary>
/// Wrapper/facade for XML Serialization/Deserialization functionality of .NET.
/// </summary>
public class XmlSerializationFacade
{
    /// <summary>
    /// Uses XML serialization to convert an object into its XML representation.
    /// </summary>
    /// <typeparam name="T">Type of object to turn into XML.</typeparam>
    /// <param name="entity">Object to turn into XML.</param>
    /// <returns>An XML representation of an object as a string.</returns>
    public string GetXmlAsString<T>(in T entity)
    {
        using var stream = new MemoryStream();
        var serializer = new XmlSerializer(entity.GetType());
        serializer.Serialize(stream, entity);
        stream.Position = 0;
        var xml = this.GetStringFromStream(stream);
        return xml;
    }

    private string GetStringFromStream(in Stream stream)
    {
        string streamString;
        using (var reader = new StreamReader(stream))
        {
            streamString = reader.ReadToEnd();
        }

        return streamString;
    }
}
