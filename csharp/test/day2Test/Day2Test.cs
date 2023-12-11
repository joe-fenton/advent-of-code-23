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
    public void shouldReadGamesWithRedColours()
    {
      var gameReader = new GameReader("Game 1: 4 Red, 3 Blue", "Game 2: 6 Red, 2 Yellow");
      var game1 = gameReader.GetGameById(1);
      var game2 = gameReader.GetGameById(2);

      Assert.Equal(4, game1.ReadCubeByColour("Red"));
      Assert.Equal(6, game2.ReadCubeByColour("Red"));
    }
}