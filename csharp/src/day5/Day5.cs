
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

      if (line.Contains("seed-to-soil map:"))
      {
        state = "ssm";
      }

      switch (state)
      {
        case "ssm":
          var ssMap = Strings.ExtractNumbersFromString(line);
          if (ssMap.Length == 3)
          {
            var aMap = new Mapping(ssMap[0], ssMap[1], ssMap[2]);
            List<int>? seedsToMap = null;
            if (SeedsMappedToSoil.Count == 0)
            {
              seedsToMap = Seeds;
            }
            else
            {
              seedsToMap = SeedsMappedToSoil;
            }
            List<int> newlyMapped = new List<int>();
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
            SeedsMappedToSoil = newlyMapped;
          }
          break;
      }
    }
  }
}
