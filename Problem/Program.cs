using System;

namespace Problem
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var serializationType = Console.ReadLine();
      var serializedInput = Console.ReadLine();
      var input = serializationType.ToUpperInvariant() == "XML" ? serializedInput.XmlDeserialize<Input>() : serializedInput.JsonDeserialize<Input>();
      var output = new Output(input);
      var serializedOutput = serializationType.ToUpperInvariant() == "XML" ? output.XmlSerialize() : output.JsonSerialize();
      Console.WriteLine(serializedOutput);
    }
  }
}