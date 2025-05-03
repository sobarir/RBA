namespace RBA.Domain;

public static class EntitiesExtensions
{

  public static string ToJson(this object value)
  {
    ArgumentNullException.ThrowIfNull(value);
    return System.Text.Json.JsonSerializer.Serialize(value);
  }

}
