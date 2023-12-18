using day3;

namespace day3Test;

public class Day3Test
{
    [Fact]
    public void shouldReadThePositionOfAllNonePeriodSymbolsInAGrid()
    {
        var line1 = "467..114..";
        var line2 = "...*......";

        var engine = new Engine(line1, line2);

        Assert.Equal(3, engine.GetSymbols()[1][0]);
        Assert.Equal(467, engine.GetNumbers()[0][0]);
        Assert.Equal(467, engine.GetNumbers()[0][1]);
        Assert.Equal(467, engine.GetNumbers()[0][2]);
        Assert.Equal(114, engine.GetNumbers()[0][5]);
        Assert.Equal(114, engine.GetNumbers()[0][6]);
        Assert.Equal(114, engine.GetNumbers()[0][7]);
        Assert.Single(engine.GetSymbols()[1]);
        Assert.Equal(6, engine.GetNumbers()[0].Where(number => number>=0).ToArray().Length);
    }

    [Fact]
    public void shouldReturnListOfNumbersAdjacentToSymbols()
    {
        var line1 = "467..114..";
        var line2 = "...*......";

        var engine = new Engine(line1, line2);

        Assert.Equal(467, engine.AdjacentNumbers[0]);
    }

    [Fact]
    public void shouldReturnListOfNumbersExtendedTest()
    {
        var line1 = "..35..633.";
        var line2 = "617*......";
        var line3 = "......#...";
        var line4 = ".....+.58.";
        var line5 = "..592.....";

        var engine = new Engine(line1, line2, line3, line4, line5);

        Assert.Equal(new List<int>{35, 617, 58, 592}, engine.AdjacentNumbers);
    }

    [Fact]
    public void shouldProvidePart1Answer()
    {
        var engine = new Engine();

        Assert.Equal(498559, engine.AdjacentNumbers.Sum());
    }

    [Fact]
    public void shouldReturnListOfGearsMultiplied()
    {
        var line1 = "..35..633.";
        var line2 = "617*......";
        var line3 = "......#...";
        var line4 = ".....+.58.";
        var line5 = "..592.....";

        var engine = new Engine(line1, line2, line3, line4, line5);

        Assert.Equal(21595, engine.SumOfGearPairsMultiplied());
    }

    [Fact]
    public void shouldProvidePart2Answer()
    {
        var engine = new Engine();

        Assert.Equal(72246648, engine.SumOfGearPairsMultiplied());
    }
}

