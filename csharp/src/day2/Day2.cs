

using System.Text.RegularExpressions;
using Helper;

namespace day2;

public enum Colours
  {
    Red,
    Green,
    Blue
  }

public class GameReader
{
    private readonly IEnumerable<string> _lines;
    private List<Game> _games = new List<Game>();

  public GameReader()
  {
    _lines = FileLoader.Load("day2.txt");
    loadGames();
  }

  public GameReader(params string[] games)
  {
    _lines = new List<string>();
    _games = games.Select(game => new Game(game)).ToList();
  }

  public Game GetGameById(int id)
  {
      return _games.Single(game => game.ID == id);
  }

  public int SumMatchingGames(int red, int green, int blue)
  {
    var matchingGames = _games.Where(game => {
      if (game.ReadCubesByColour("red").Max() <= red 
        && game.ReadCubesByColour("green").Max() <= green
        && game.ReadCubesByColour("blue").Max() <= blue)
      {
        return true;
      }
      return false;
    });
    return matchingGames.Sum(game => game.ID);
  }

  public int SumPowerMinimumPossibleCubes()
  {
    return _games.Sum(game => game.ReadCubesByColour("red").Max() 
      * game.ReadCubesByColour("green").Max()
      * game.ReadCubesByColour("blue").Max());
  }

  private void loadGames()
  {
    foreach (var line in _lines)
    {
      _games.Add(new Game(line));
    }
  }
}

public class Game
{
  private Dictionary<Colours, List<int>> _cubes;
  

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

  public List<int> ReadCubesByColour(string colour)
  {
    if(_cubes.ContainsKey(GetColours(colour)))
      return _cubes[GetColours(colour)];
    else
    {
      return new List<int>(){0};
    }
  }

  private void extractGameDefinition(string game)
  {
    var separators = new string[] {":", ",", ";"};
    var splitGameString = game.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    ID = int.Parse(Regex.Match(splitGameString[0], @"\d+").Value);
    Regex myRegex = new Regex(@"\b(Red|Blue|Green|red|blue|green)");
    if(splitGameString.Length > 1)
    {
      for (int i = 1; i < splitGameString.Length; i++)
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
  }

  public static Colours GetColours(string colour)
  {
    switch (colour.ToLower())
    {
      case "red": return Colours.Red;
      case "blue": return Colours.Blue;
      case "green": return Colours.Green;
      default: return Colours.Blue;
    }
  }
}