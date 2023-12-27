
using Helper;

namespace day5;

public class SeedMapper
{
  private const string SSM = "ssm";
  private const string SFM = "sfm";
  private const string FWM = "fwm";
  private const string WLM = "wlm";
  private const string LTM = "ltm";
  private const string THM = "thm";
  private const string HLM = "hlm";

  public List<long> Seeds
  {
    private set;
    get;
  } = new List<long>();

  public List<long> SeedsMappedToSoil
  {
    private set;
    get;
  } = new List<long>();

  public List<long> SoilMappedToFertiliser
  {
    private set;
    get;
  } = new List<long>();

  public List<long> FertiliserMappedToWater
  {
    private set;
    get;
  } = new List<long>();

  public List<long> WaterMappedToLight
  {
    private set;
    get;
  } = new List<long>();

  public List<long> LightMappedToTemp
  {
    private set;
    get;
  } = new List<long>();

  public List<long> TempMappedToHumidity
  {
    private set;
    get;
  } = new List<long>();

  public List<long> HumidityMappedToLocation
  {
    private set;
    get;
  } = new List<long>();

  private bool[] _alreadyMapped = null;

  private sealed class Mapping
  {
    public Mapping(long destination, long source, long length)
    {
      Destination = destination;
      Source = source;
      Length = length;
    }

    public long Destination
    {
      private set;
      get;
    }

    public long Source
    {
      private set;
      get;
    }

    public long Length
    {
      private set;
      get;
    }
  }

  public SeedMapper()
  {
    InitialiseFarm(FileLoader.Load("day5.txt"));
  }

  public SeedMapper(params string[] farmingConfiguration)
  {
    InitialiseFarm([.. farmingConfiguration]);
  }

  private void InitialiseMapped()
  {
    for (int i = 0; i < Seeds.Count; i++)
    {
      _alreadyMapped[i] = false;
    }
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
        _alreadyMapped = new bool[Seeds.Count];
        InitialiseMapped();
      }

      state = UpdateMappingState(line, state);

      switch (state)
      {
        case SSM:
          SeedsMappedToSoil = PerformMapping(line, Seeds, SeedsMappedToSoil);
          break;
        case SFM:
          SoilMappedToFertiliser = PerformMapping(line, SeedsMappedToSoil, SoilMappedToFertiliser);
          break;
        case FWM:
          FertiliserMappedToWater = PerformMapping(line, SoilMappedToFertiliser, FertiliserMappedToWater);
          break;
        case WLM:
          WaterMappedToLight = PerformMapping(line, FertiliserMappedToWater, WaterMappedToLight);
          break;
        case LTM:
          LightMappedToTemp = PerformMapping(line, WaterMappedToLight, LightMappedToTemp);
          break;
        case THM:
          TempMappedToHumidity = PerformMapping(line, LightMappedToTemp, TempMappedToHumidity);
          break;
        case HLM:
          HumidityMappedToLocation = PerformMapping(line, TempMappedToHumidity, HumidityMappedToLocation);
          break;
      }
    }
  }

  private string UpdateMappingState(string line, string currentState)
  {
    if (line.Contains("seed-to-soil map:"))
    {
      InitialiseMapped();
      return SSM;
    }

    if (line.Contains("soil-to-fertilizer map:"))
    {
      InitialiseMapped();
      return SFM;
    }

    if (line.Contains("fertilizer-to-water map:"))
    {
      InitialiseMapped();
      return FWM;
    }
    if (line.Contains("water-to-light map:"))
    {
      InitialiseMapped();
      return WLM;
    }
    if (line.Contains("light-to-temperature map:"))
    {
      InitialiseMapped();
      return LTM;
    }
    if (line.Contains("temperature-to-humidity map:"))
    {
      InitialiseMapped();
      return THM;
    }
    if (line.Contains("humidity-to-location map:"))
    {
      InitialiseMapped();
      return HLM;
    }
    return currentState;
  }

  private List<long> PerformMapping(string currentMap, List<long> source, List<long> destination)
  {
    var ssMap = Strings.ExtractNumbersFromString(currentMap);
    List<long> newlyMapped = new List<long>();
    if (ssMap.Length == 3)
    {
      var aMap = new Mapping(ssMap[0], ssMap[1], ssMap[2]);
      List<long>? seedsToMap = null;
      if (destination.Count == 0)
      {
        seedsToMap = source;
      }
      else
      {
        seedsToMap = destination;
      }

      int i = 0;
      seedsToMap.ForEach(seed =>
      {
        if (seed >= aMap.Source && seed < aMap.Source + aMap.Length)
        {
          if (!_alreadyMapped[i])
          {
            var difference = seed - aMap.Source;
            newlyMapped.Add(aMap.Destination + difference);
            _alreadyMapped[i] = true;
          }
          else
          {
            newlyMapped.Add(seed);
          }
        }
        else
        {
          newlyMapped.Add(seed);
        }
        i++;
      });
      return newlyMapped;
    }
    return destination;
  }
}
