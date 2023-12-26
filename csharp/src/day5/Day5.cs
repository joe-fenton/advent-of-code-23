
using Helper;

namespace day5;

public class SeedMapper
{
  public List<int> Seeds
  {
    private set;
    get;
  }

  public List<int> SeedsMappedToSoil
  {
    private set;
    get;
  }

  public List<int> SoilMappedToFertiliser
  {
    private set;
    get;
  }

  private sealed class Mapping
  {
    public Mapping(int destination, int source, int length)
    {
      Destination = destination;
      Source = source;
      Length = length;
    }

    public int Destination
    {
      private set;
      get;
    }

    public int Source
    {
      private set;
      get;
    }

    public int Length
    {
      private set;
      get;
    }
  }

  public SeedMapper(params string[] farmingConfiguration)
  {
    SeedsMappedToSoil = new List<int>();
    SoilMappedToFertiliser = new List<int>();
    Seeds = new List<int>();
    InitialiseFarm([.. farmingConfiguration]);
  }

  private void InitialiseFarm(IEnumerable<string> lines)
  {
    var state = "";
    foreach (var line in lines)
    {
      if (line.Contains("seeds"))
      {
        var startsAt = line.IndexOf(':');
        var seeds = line.Substring(startsAt, line.Length - startsAt);
        Seeds = Strings.ExtractNumbersFromString(seeds).ToList();

      }

      state = UpdateMappingState(line, state);

      switch (state)
      {
        case "ssm":
          SeedsMappedToSoil = PerformMapping(line, Seeds, SeedsMappedToSoil);
          break;
        case "sfm":
          SoilMappedToFertiliser = PerformMapping(line, SeedsMappedToSoil, SoilMappedToFertiliser);
          break;
      }
    }
  }

  private string UpdateMappingState(string line, string currentState)
  {
    if (line.Contains("seed-to-soil map:"))
    {
      return "ssm";
    }

    if (line.Contains("soil-to-fertilizer map:"))
    {
      return "sfm";
    }

    if (line.Contains("fertilizer-to-water map:"))
    {
      return "fmm";
    }
    if (line.Contains("water-to-light map:"))
    {
      return "wlm";
    }
    if (line.Contains("light-to-temperature map:"))
    {
      return "ltm";
    }
    if (line.Contains("temperature-to-humidity map:"))
    {
      return "thm";
    }
    if (line.Contains("humidity-to-location map:"))
    {
      return "hlm";
    }
    return currentState;
  }

  private List<int> PerformMapping(string currentMap, List<int> source, List<int> destination)
  {
    var ssMap = Strings.ExtractNumbersFromString(currentMap);
    List<int> newlyMapped = new List<int>();
    if (ssMap.Length == 3)
    {
      var aMap = new Mapping(ssMap[0], ssMap[1], ssMap[2]);
      List<int>? seedsToMap = null;
      if (destination.Count == 0)
      {
        seedsToMap = source;
      }
      else
      {
        seedsToMap = destination;
      }

      seedsToMap.ForEach(seed =>
      {
        if (seed >= aMap.Source && seed < aMap.Source + aMap.Length)
        {
          var difference = seed - aMap.Source;
          newlyMapped.Add(aMap.Destination + difference);
        }
        else
        {
          newlyMapped.Add(seed);
        }
      });
      return newlyMapped;
    }
    return destination;
  }
}
