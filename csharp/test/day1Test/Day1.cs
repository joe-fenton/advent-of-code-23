using adventofcode2023.day1;

namespace adventofcode2023Tests;
public class Day1Test
{
    [Fact]
    public void Day1_shouldReturnFirstAndLastDigitFromString()
    {
        var day1test1 = new Day1("bsls3dks3");
        var day1test2 = new Day1("agk53,fdk9");
        
        Assert.Equal(33, day1test1.Sum);
        Assert.Equal(59, day1test2.Sum);
    }

    [Fact]
    public void Day1_shouldReturnSummedDigitsFrom2Entries()
    {
        var day1test1 = new Day1("bsls3dks3", "dadg4als8adl");
        var day1test2 = new Day1("agk53,fdk9", "shgfoi344.;dskfk900");
        
        Assert.Equal(81, day1test1.Sum);
        Assert.Equal(89, day1test2.Sum);
    }

    [Fact]
    public void Day1_shouldReadFileAndReturnSum()
    {
        var day1 = new Day1();
        
        Assert.Equal(54100, day1.Sum);
    }

    [Fact]
    public void Day1_shouldReplaceOneWith1InTheInputString()
    {
        var day1test1 = new Day1("bsonels3dks3");
        var day1test2 = new Day1("agk53,onefdk9", "shgfoi344.;dskfk900one");
        
        Assert.Equal(13, day1test1.Sum);
        Assert.Equal(90, day1test2.Sum);
    }

    [Fact]
    public void Day1_shouldReplaceTwoWith2InTheInputString()
    {
        var day1test1 = new Day1("bstwols3dks3");
        var day1test2 = new Day1("agk53,twofdk9", "shgfoi344.;dskfk900two");
        
        Assert.Equal(23, day1test1.Sum);
        Assert.Equal(91, day1test2.Sum);
    }

    [Fact]
    public void Day1_shouldReplaceThreeWith3InTheInputString()
    {
        var day1test1 = new Day1("bsthree1ls3dks3");
        var day1test2 = new Day1("agk53,threefdk9", "shgfoi344.;dskfk900three");
        
        Assert.Equal(33, day1test1.Sum);
        Assert.Equal(92, day1test2.Sum);
    }

    [Fact]
    public void Day1_shouldReplaceNineWith9InTheInputString()
    {
        var day1test1 = new Day1("bsnine1ls3dks3");
        var day1test2 = new Day1("agk53,threefdk9", "shgfoi344.;dskfk900nine");
        
        Assert.Equal(93, day1test1.Sum);
        Assert.Equal(98, day1test2.Sum);
    }

    [Fact]
    public void Day1_shouldReplaceWordsWithDigitsInTheInputString()
    {
        var day1test1 = new Day1("dpfhfeight28onefourtwo");
        var day1test2 = new Day1("1six15ninebgnzhtbmlxpnrqoneightfhp");
        
        Assert.Equal(82, day1test1.Sum);
        Assert.Equal(18, day1test2.Sum);
    }
}