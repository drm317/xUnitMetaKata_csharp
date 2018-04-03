using System;
using TestFramework;

namespace RockPaperScissors.Test
{
    public class GameTests
    {

        private object[][] Parameters_TestInvalidMovesNotCounted()
        {
            return new[]
            {
                new object[] {Player.Rock, Player.Scissors, 0}
            };
        }

        public void TestInvalidMovesNotCounted(Player player1, Player player2, int expectedResult)
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            try
            {
                game.PlayRound(null, null);
                game.PlayRound(player1, player2);
            }
            catch (Exception e)
            {
            }

            var result = listener.Winner;
            Assert.Equals(result, expectedResult, "Invalid moves not counted");
        }

        private object[][] Parameters_TestDrawsNotCounted()
        {
            return new[]
            {
                new object[] {Player.Rock, Player.Rock, 0}
            };
        }

        public void TestDrawsNotCounted(Player player1, Player player2, int expectedResult)
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game.PlayRound(player1, player2);
            game.PlayRound(player1, player2);

            var result = listener.Winner;
            Assert.Equals(result, expectedResult, "Draw not counted");
        }

        private object[][] Parameters_TestPlayerTwoWinsGame()
        {
            return new[]
            {
                new object[] {Player.Rock, Player.Paper, 2}
            };
        }

        public void TestPlayerTwoWinsGame(Player player1, Player player2, int expectedResult)
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game.PlayRound(player1, player2);
            game.PlayRound(player1, player2);

            var result = listener.Winner;
            Assert.Equals(result, expectedResult, "Player2 wins game");
        }

        private object[][] Parameters_TestPlayerOneWinsGame()
        {
            return new[]
            {
                new object[] {Player.Rock, Player.Scissors, 1}
            };
        }

        public void TestPlayerOneWinsGame(Player player1, Player player2, int expectedResult)
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game.PlayRound(player1, player2);
            game.PlayRound(player1, player2);

            var result = listener.Winner;
            Assert.Equals(result, expectedResult, "Player1 wins game");
        }
    }
}