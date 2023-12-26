
using Helper;

namespace day4;

public class LotteryReader
{
  private readonly List<int[]> _winningNumbers = new List<int[]>();
  private readonly List<int[]> _drawnNumbers = new List<int[]>();

  private int[]? _cardCounter;

  public LotteryReader(params string[] numbers)
  {
    ParseCards([.. numbers]);
  }

  public LotteryReader()
  {
    ParseCards(FileLoader.Load("day4.txt"));
  }

  private void ParseCards(IEnumerable<string> lines)
  {
    foreach (var line in lines)
    {
      var from = line.IndexOf(":");
      var to = line.IndexOf("|");
      var winningNumbersString = line.Substring(from, to - from);

      _winningNumbers.Add(Strings.ExtractNumbersFromString(winningNumbersString));

      var drawnNumbersString = line.Substring(to + 1, line.Length - to - 1);

      _drawnNumbers.Add(Strings.ExtractNumbersFromString(drawnNumbersString));
    }
    _cardCounter = new int[_winningNumbers.Count];
    for (int i = 0; i < _cardCounter.Length; i++)
    {
      _cardCounter[i] = 1;
    }
  }

  public int[] GetWinningNumbers(int card)
  {
    return _winningNumbers[card];
  }

  public int[] GetDrawnNumbers(int card)
  {
    return _drawnNumbers[card];
  }

  private int CalculatePointsOnCard(int matches)
  {
    return (int)(matches == 1 ? matches : Math.Pow(2, matches - 1));
  }

  private int MatchesOnCard(int card)
  {
    var winningList = _winningNumbers[card].ToList();
    var drawnList = _drawnNumbers[card].ToList();
    return winningList.Intersect(drawnList).Count();
  }

  public int CalculateLotteryPoints()
  {
    int sumPoints = 0;

    for (int card = 0; card < _winningNumbers.Count; card++)
    {
      sumPoints += CalculatePointsOnCard(MatchesOnCard(card));
    }
    return sumPoints;
  }

  private void CalculateLotteryCards(int card, int matches)
  {
    var currentCardCount = _cardCounter[card];
    while (currentCardCount > 0)
    {
      for (int i = card + 1; i <= card + matches; i++)
      {
        _cardCounter[i]++;
      }
      currentCardCount--;
    }
  }

  public int SumLotteryCards()
  {
    for (int card = 0; card < _winningNumbers.Count; card++)
    {
      var numMatches = MatchesOnCard(card);
      CalculateLotteryCards(card, numMatches);
    }
    return _cardCounter.Sum();
  }
}
