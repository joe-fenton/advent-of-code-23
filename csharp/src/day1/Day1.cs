using System.Collections;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Helper;

namespace adventofcode2023.day1;

public class Day1
{
  private static readonly ReadOnlyDictionary<string, string> _wordToDigitMap = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
  {
    ["twone"] = "21",
    ["oneight"] = "18",
    ["sevenine"] = "79",
    ["threeight"] = "38",
    ["fiveight"] = "58",
    ["nineight"] = "98",
    ["eightwo"] = "82",
    ["one"] = "1",
    ["two"] = "2",
    ["three"] = "3",
    ["four"] = "4",
    ["five"] = "5",
    ["six"] = "6",
    ["seven"] = "7",
    ["eight"] = "8",
    ["nine"] = "9",
  });
  
  private IEnumerable<string> _lines;

  public int Sum { get; set; }

  public Day1()
  {
    _lines = FileLoader.Load("day1.txt");
    calculateSum();
  }

  public Day1(params string[] lines)
  {
      var list = lines.ToList();
      _lines = list;
      
      calculateSum();
  }

  private void calculateSum()
  {
    foreach (var line in _lines)
    {
      var replaceWordsWithDigits = _wordToDigitMap.Aggregate(line, (current, value) => 
        current.Replace(value.Key, value.Value));
      Sum += ExtractFirstAndLastDigit(replaceWordsWithDigits);
    }
  }

  private static int ExtractFirstAndLastDigit(string line)
  {
      var number = string.Join(string.Empty, Regex.Matches(line, @"\d+").OfType<Match>().Select(m => m.Value));
      var firstAndLast = number[0].ToString() + number[number.Length - 1].ToString();
      return int.Parse(firstAndLast);
  }
}
