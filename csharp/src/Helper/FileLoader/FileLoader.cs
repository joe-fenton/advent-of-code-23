namespace Helper;

public static class FileLoader
{
  public static readonly string DataLocation = @"../../../../../data/";
  public static IEnumerable<string> Load(string fileName)
  {
    return File.ReadLines(DataLocation + fileName);
  }
}
