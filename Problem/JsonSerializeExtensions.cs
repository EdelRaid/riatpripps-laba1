using Newtonsoft.Json;

namespace Problem
{
  public static class JsonSerializeExtensions
  {
    public static string JsonSerialize(this object objectInstance)
    {
      return JsonConvert.SerializeObject(objectInstance);
    }

    public static T JsonDeserialize<T>(this string objectData)
    {
      return JsonConvert.DeserializeObject<T>(objectData);
    }
  }
}