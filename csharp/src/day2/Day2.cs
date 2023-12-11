

using System.Text.RegularExpressions;

namespace day2;

public class Class1
{

}

public class GameReader
{
  private IEnumerable<Game> _games;

  public GameReader(params string[] games)
  {
    _games = games.Select(game => new Game(game));
  }

  public Game GetGameById(int id)
  {
      return _games.Single(game => game.ID == id);
  }

  
}

public class Game
{
  private Dictionary<Colours, List<int>> _cubes;
  public enum Colours
  {
    Red,
    Green,
    Blue
  }

  public Game(string gameString)
  {
      _cubes = new Dictionary<Colours, List<int>>();
      extractGameDefinition(gameString);
  }

  public int ID
  {
    get;
    private set;
  }

  public int ReadCubeByColour(string colour)
  {
    return _cubes[GetColours(colour)][0];
  }

  private void extractGameDefinition(string game)
  {
    var separators = new string[] {":", ","};
    var splitGameString = game.Split(separators, StringSplitOptions.TrimEntries);
    ID = int.Parse(Regex.Match(splitGameString[0], @"\d+").Value);
    Regex myRegex = new Regex(@"\b(Red|Blue|Green)");
    for (int i = 1; i < splitGameString.Length - 1; i++)
    {
      
      var results = myRegex.Split(splitGameString[i]);
      Colours cubeColour = GetColours(results[1]);
      if(_cubes.ContainsKey(cubeColour))
      {
        _cubes[cubeColour].Add(int.Parse(results[0]));
      } 
      else
      {
        _cubes.Add(cubeColour, new List<int>{int.Parse(results[0])});
      }
    }
  }

  private static Colours GetColours(string colour)
  {
    switch (colour)
    {
      case "Red": return Colours.Red;
      case "Blue": return Colours.Blue;
      case "Green": return Colours.Green;
      default: return Colours.Blue;
    }
  }
}