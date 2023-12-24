using day4;

namespace day4Test;

public class Day4Test
{
  private const string _card1 = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
  private const string _card2 = "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19";
  private const string _card3 = "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1";

  [Fact]
  public void shouldRetrieveListOfWinningNumbers()
  {
    var lotteryReader = new LotteryReader(_card1);

    Assert.Equal([41, 48, 83, 86, 17], lotteryReader.GetWinningNumbers(0));
  }

  [Fact]
  public void shouldRetrieveListOfWinningNumbersGivenMultipleCards()
  {
    var lotteryReader = new LotteryReader(_card1, _card2, _card3);

    Assert.Equal([13, 32, 20, 16, 61], lotteryReader.GetWinningNumbers(1));
    Assert.Equal([1, 21, 53, 59, 44], lotteryReader.GetWinningNumbers(2));
  }

  [Fact]
  public void shouldRetrieveListOfDrawnNumbersGivenMultipleCards()
  {
    var lotteryReader = new LotteryReader(_card1, _card2, _card3);

    Assert.Equal([61, 30, 68, 82, 17, 32, 24, 19], lotteryReader.GetDrawnNumbers(1));
    Assert.Equal([69, 82, 63, 72, 16, 21, 14, 1], lotteryReader.GetDrawnNumbers(2));
  }

  [Fact]
  public void shouldCalculateLotteryScoreFromCards()
  {
    var lotteryReader = new LotteryReader(_card1, _card2, _card3);

    Assert.Equal(12, lotteryReader.CalculateLotteryPoints());
  }

  [Fact]
  public void shouldCalculateLotteryScoreFromCardsOnDay1TestData()
  {
    var lotteryReader = new LotteryReader();

    Assert.Equal(25651, lotteryReader.CalculateLotteryPoints());
  }

  [Fact]
  public void shouldCalculateTotalNumberOfLotteryCards()
  {
    var lotteryReader = new LotteryReader();

    Assert.Equal(19499881, lotteryReader.SumLotteryCards());
  }
}