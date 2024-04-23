public static class Origins
{
  public static readonly IDictionary<string, string[]> KnownOrigins = new Dictionary<string, string[]>()
  {
    { "Development", new string[] { "http://localhost:3000", "https://localhost:3000"} },
    { "Production", new string[] {} }
  };
}