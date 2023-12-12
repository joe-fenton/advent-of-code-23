using day2;

namespace day2Test;

public class Day2Test
{
    [Fact]
    public void shouldReadEmptyGamesWithNoCubes()
    {
        var gameReader = new GameReader("Game 1:", "Game 2:");
        var game1 = gameReader.GetGameById(1);
        var game2 = gameReader.GetGameById(2);

        Assert.NotNull(gameReader.GetGameById(1));
        Assert.NotNull(gameReader.GetGameById(2));
        Assert.Equal(1, game1.ID);
        Assert.Equal(2, game2.ID);
    }

    [Fact]
    public void shouldReadGamesWithColouredCubes()
    {
      var gameReader = new GameReader("Game 1: 4 Red, 3 Blue", "Game 2: 6 Red, 2 Green");
      var game1 = gameReader.GetGameById(1);
      var game2 = gameReader.GetGameById(2);

      Assert.Equal(4, game1.ReadCubesByColour("Red").Sum());
      Assert.Equal(6, game2.ReadCubesByColour("Red").Sum());
      Assert.Equal(3, game1.ReadCubesByColour("Blue").Sum());
      Assert.Equal(2, game2.ReadCubesByColour("Green").Sum());
    }

    [Fact]
    public void shouldReadGamesWithColouredCubesWithSeveralPicksOfCubes()
    {
      var gameReader = new GameReader("Game 1: 4 blue, 7 red, 5 green; 3 blue, 4 red, 16 green; 3 red, 11 green",
                         "Game 2: 20 blue, 8 red, 1 green; 1 blue, 2 green, 8 red; 9 red, 4 green, 18 blue; 2 green, 7 red, 2 blue; 10 blue, 2 red, 5 green");
      var game1 = gameReader.GetGameById(1);
      var game2 = gameReader.GetGameById(2);

      Assert.Equal(14, game1.ReadCubesByColour("Red").Sum());
      Assert.Equal(34, game2.ReadCubesByColour("Red").Sum());
      Assert.Equal(7, game1.ReadCubesByColour("Blue").Sum());
      Assert.Equal(51, game2.ReadCubesByColour("Blue").Sum());
      Assert.Equal(32, game1.ReadCubesByColour("Green").Sum());
      Assert.Equal(14, game2.ReadCubesByColour("Green").Sum());
    }

    [Fact]
    public void shouldReturnIdsSummedForGamesWhichCanMeetTheCubeCriteria()
    {
      var gameReader = new GameReader("Game 1: 4 blue, 7 red, 5 green; 3 blue, 4 red, 16 green; 3 red, 11 green",
                        "Game 2: 20 blue, 8 red, 1 green; 1 blue, 2 green, 8 red; 9 red, 4 green, 18 blue; 2 green, 7 red, 2 blue; 10 blue, 2 red, 5 green",
                        "Game 3: 2 red, 5 green, 1 blue; 3 blue, 5 green; 8 blue, 13 green, 2 red; 9 green, 3 blue; 12 green, 13 blue; 3 green, 3 blue, 1 red",
                        "Game 4: 1 red, 6 green, 4 blue; 3 green, 1 blue, 1 red; 7 blue, 1 red, 2 green");

      Assert.Equal(10, gameReader.SumMatchingGames(18, 19, 27));
      Assert.Equal(4, gameReader.SumMatchingGames(7, 9, 20));
      Assert.Equal(7, gameReader.SumMatchingGames(15, 14, 14));
      Assert.Equal(9, gameReader.SumMatchingGames(22, 15, 33));
    }

    [Fact]
    public void shouldReturnSumOfPowerOfSetOfCubesMatchingMinimumPossible()
    {
      var gameReader = new GameReader("Game 1: 4 blue, 7 red, 5 green; 3 blue, 4 red, 16 green; 3 red, 11 green",
                        "Game 2: 20 blue, 8 red, 1 green; 1 blue, 2 green, 8 red; 9 red, 4 green, 18 blue; 2 green, 7 red, 2 blue; 10 blue, 2 red, 5 green",
                        "Game 3: 2 red, 5 green, 1 blue; 3 blue, 5 green; 8 blue, 13 green, 2 red; 9 green, 3 blue; 12 green, 13 blue; 3 green, 3 blue, 1 red",
                        "Game 4: 1 red, 6 green, 4 blue; 3 green, 1 blue, 1 red; 7 blue, 1 red, 2 green");

      Assert.Equal(1728, gameReader.SumPowerMinimumPossibleCubes());
      
    }

    [Fact]
    public void shouldReadTestDataAndCalculateDay2AnswerPart1and2()
    {
      var gameReader = new GameReader();

      Assert.Equal(2512, gameReader.SumMatchingGames(12, 13, 14));
      Assert.Equal(67335, gameReader.SumPowerMinimumPossibleCubes());
    }
}