using day5;
using Helper;

namespace day5Test;

public class Day5Test
{
  [Fact]
  public void shouldReadSeeds()
  {
    var seeds = "seeds: 79 14 55 13";

    var seedMapper = new SeedMapper(seeds);

    Assert.Equal(79, seedMapper.Seeds[0]);
    Assert.Equal(13, seedMapper.Seeds[3]);
    Assert.Equal(4, seedMapper.Seeds.Count);
  }

  [Fact]
  public void shouldReadSeedToSoilMap()
  {
    var seeds = "seeds: 79 14 55 13";
    var line1 = "";
    var seedToSoilTitle = "seed-to-soil map:";
    var seedToSoil1 = "50 98 2";
    var seedToSoil2 = "52 50 48";
    var line2 = "\n";

    var seedMapper = new SeedMapper(seeds, line1, seedToSoilTitle, seedToSoil1, seedToSoil2, line2);

    Assert.Equal(81, seedMapper.SeedsMappedToSoil[0]);
    Assert.Equal(14, seedMapper.SeedsMappedToSoil[1]);
    Assert.Equal(57, seedMapper.SeedsMappedToSoil[2]);
    Assert.Equal(13, seedMapper.SeedsMappedToSoil[3]);
  }

  [Fact]
  public void shouldReadSoilToFertiliserMap()
  {
    var seeds = "seeds: 79 14 55 13";
    var line1 = "";
    var seedToSoilTitle = "seed-to-soil map:";
    var seedToSoil1 = "50 98 2";
    var seedToSoil2 = "52 50 48";
    var line2 = "\n";
    var soilToFertTitle = "soil-to-fertilizer map:";
    var soilToFert1 = "0 15 37";
    var soilToFert2 = "37 52 2";
    var soilToFert3 = "39 0 15";
    var line3 = "\n";

    var seedMapper = new SeedMapper(seeds, line1, seedToSoilTitle, seedToSoil1, seedToSoil2, line2, soilToFertTitle, soilToFert1, soilToFert2, soilToFert3, line3);

    Assert.Equal(81, seedMapper.SoilMappedToFertiliser[0]);
    Assert.Equal(53, seedMapper.SoilMappedToFertiliser[1]);
    Assert.Equal(57, seedMapper.SoilMappedToFertiliser[2]);
    Assert.Equal(52, seedMapper.SoilMappedToFertiliser[3]);
  }

  [Fact]
  public void shouldReadFertiliserToWaterMap()
  {
    var seedMapper = new SeedMapper(FileLoader.Load("day5Simplified.txt").ToArray());

    Assert.Equal(81, seedMapper.FertiliserMappedToWater[0]);
    Assert.Equal(49, seedMapper.FertiliserMappedToWater[1]);
    Assert.Equal(53, seedMapper.FertiliserMappedToWater[2]);
    Assert.Equal(41, seedMapper.FertiliserMappedToWater[3]);
  }

  [Fact]
  public void shouldCalculateLowestLocationForSimpleTestData()
  {
    var seedMapper = new SeedMapper(FileLoader.Load("day5Simplified.txt").ToArray());

    Assert.Equal(35, seedMapper.HumidityMappedToLocation.Min());
  }

  [Fact]
  public void shouldCalculateLowestLocationForDay5Part1()
  {
    var seedMapper = new SeedMapper();

    Assert.Equal(178159714, seedMapper.HumidityMappedToLocation.Min());
  }
}