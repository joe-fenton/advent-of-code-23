using day5;

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
}