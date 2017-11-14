using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Problem
{
  public static class XmlSerializeExtensions
  {
    public static string XmlSerialize(this object objectInstance)
    {
      var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
      var serializer = new XmlSerializer(objectInstance.GetType());
      var settings = new XmlWriterSettings();
      settings.Indent = false;
      settings.OmitXmlDeclaration = true;
      settings.NewLineHandling = NewLineHandling.None;

      using (var stream = new StringWriter())
      using (var writer = XmlWriter.Create(stream, settings))
      {
        serializer.Serialize(writer, objectInstance, emptyNamepsaces);
        return stream.ToString();
      }
    }

    public static T XmlDeserialize<T>(this string objectData)
    {
      using (TextReader reader = new StringReader(objectData))
      {
        return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
      }
    }
  }
}