
using System.Text.RegularExpressions;
using Helper;

namespace day3;

public class Engine
{
  private readonly IEnumerable<string> _lines;
  private readonly List<List<int>> _symbols = new List<List<int>>();
  private readonly List<int[]> _numbers = new List<int[]>();

  private readonly List<List<int>> _gears = new List<List<int>>();
  private readonly List<List<int>> _gearPairs = new List<List<int>>();

  public Engine()
  {
    _lines = FileLoader.Load("day3.txt");
    AdjacentNumbers = new List<int>();
    ReadSchematic();
  }

    public Engine(params string[] engine)
    {
        _lines = [.. engine];
        AdjacentNumbers = new List<int>();
        ReadSchematic();
    }

    public void CalculateAdjacentNumbers()
    {
        List<int> adjacentNumbers = new List<int>();
        for (int row = 0; row < _symbols.Count; row++)
        {
          for (int symbol = 0; symbol < _symbols[row].Count; symbol++)
            {
                var indexOfSymbol = _symbols[row][symbol];
                var adjacentNumbersToCurrentSymbol = adjacentNumbersToSymbol(row, indexOfSymbol);
                if(symbolIsStar(row, indexOfSymbol) && adjacentNumbersToCurrentSymbol.Count == 2)
                {
                  _gearPairs.Add(adjacentNumbersToCurrentSymbol);
                }

                adjacentNumbers.AddRange(adjacentNumbersToCurrentSymbol);
            }
        }
        AdjacentNumbers = adjacentNumbers;
    }

    public List<int> AdjacentNumbers
    {
      private set;
      get;
    }

    public int SumOfGearPairsMultiplied()
    {
      int acc = 0;
      foreach (var gearPair in _gearPairs)
      {
        var multiplied = gearPair[0] * gearPair[1];
        acc += multiplied;
      }
      return acc;
    }

    private bool symbolIsStar(int row, int indexOfSymbol)
    {
        if(_gears[row].Contains(indexOfSymbol))
          return true;
        return false;
    }

    private List<int> adjacentNumbersToSymbol(int i, int indexOfSymbol)
    {
      var adjacentNumbers = new List<int>();
        for (int row = i - 1; row <= i + 1; row++)
        {
            for (int column = indexOfSymbol - 1; column <= indexOfSymbol + 1; column++)
            {
              if (checkAdjactIndexValid(row, column))
              {
                var adjacentNumberCheck = _numbers[row][column];
                if (adjacentNumberCheck != -1 && !adjacentNumbers.Contains(adjacentNumberCheck))
                {
                    adjacentNumbers.Add(adjacentNumberCheck);
                }
                
              }
            }
        }
        return adjacentNumbers;
    }

    private bool checkAdjactIndexValid(int row, int column)
    {
      if (row != -1 && row != _numbers.Count
        && !(row == 0 && column == 0)
        && column != -1 && column != _numbers[row].Count())
      {
        return true;
      }
      return false;
    }

    public List<int[]> GetNumbers()
    {
        return _numbers;
    }

    public List<List<int>> GetSymbols()
    {
        return _symbols;
    }

    private void ReadSchematic()
    {
      foreach (var line in _lines)
        {
            ExtractSymbol(line);
            ExtractGears(line);
            ExtractNumbers(line);
        }
        CalculateAdjacentNumbers();
    }

    private void ExtractNumbers(string line)
    {
        var numbers = new int[line.Length];
        for (int i = 0; i < line.Length; i++)
        {
            numbers[i] = -1;
        }
        var numberMatch = Regex.Match(line, @"\d+");
        while (numberMatch.Success)
        {
            for (int i = 0; i < numberMatch.Value.Length; i++)
            {
                numbers[numberMatch.Index + i] = int.Parse(numberMatch.Value);
            }

            numberMatch = numberMatch.NextMatch();
        }
        _numbers.Add(numbers);
    }

    private void ExtractSymbol(string line)
    {
        var symbols = new List<int>();
        var match = Regex.Match(line, @"[^A-Za-z0-9.]");
        while (match.Success)
        {
            symbols.Add(match.Index);
            match = match.NextMatch();
        }
        _symbols.Add(symbols);
    }

    private void ExtractGears(string line)
    {
        var gears = new List<int>();
        var match = Regex.Match(line, @"[*]");
        while (match.Success)
        {
            gears.Add(match.Index);
            match = match.NextMatch();
        }
        _gears.Add(gears);
    }
}
