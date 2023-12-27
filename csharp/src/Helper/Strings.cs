using System.Text.RegularExpressions;

namespace Helper;

public static class Strings
{
  public static long[] ExtractNumbersFromString(string spaceSeparatedNumbers)
  {
    List<long> numbers = new List<long>();
    var numberMatches = Regex.Match(spaceSeparatedNumbers, @"\d+");

    while (numberMatches.Success)
    {
      numbers.Add(long.Parse(numberMatches.Value));
      numberMatches = numberMatches.NextMatch();
    }

    return numbers.ToArray();
  }
}
