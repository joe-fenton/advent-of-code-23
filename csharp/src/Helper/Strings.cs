using System.Text.RegularExpressions;

namespace Helper;

public static class Strings
{
  public static int[] ExtractNumbersFromString(string spaceSeparatedNumbers)
  {
    List<int> numbers = new List<int>();
    var numberMatches = Regex.Match(spaceSeparatedNumbers, @"\d+");

    while (numberMatches.Success)
    {
      numbers.Add(int.Parse(numberMatches.Value));
      numberMatches = numberMatches.NextMatch();
    }

    return numbers.ToArray();
  }
}
