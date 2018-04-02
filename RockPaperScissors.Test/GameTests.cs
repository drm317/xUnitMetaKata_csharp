using System;
using TestFramework;

namespace RockPaperScissors.Test
{
    public class GameTests
    {

        private object[] Parameters_TestInvalidMovesNotCounted()
        {
            return new object[]
            {
                Player.Rock,
                Player.Scissors
            };
        }

        public void TestInvalidMovesNotCounted(Player player1, Player player2)
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
            Assert.Equals(result, 0, "Invalid moves not counted");
        }

        private object[] Parameters_TestDrawsNotCounted()
        {
            return new object[]
            {
                Player.Rock,
                Player.Rock
            };
        }

        public void TestDrawsNotCounted(Player player1, Player player2)
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game.PlayRound(player1, player2);
            game.PlayRound(player1, player2);

            var result = listener.Winner;
            Assert.Equals(result, 0, "Draw not counted");
        }

        private object[] Parameters_TestPlayerTwoWinsGame()
        {
            return new object[]
            {
                Player.Rock,
                Player.Paper
            };
        }

        public void TestPlayerTwoWinsGame(Player player1, Player player2)
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game.PlayRound(player1, player2);
            game.PlayRound(player1, player2);

            var result = listener.Winner;
            Assert.Equals(result, 2, "Player2 wins game");
        }

        private object[] Parameters_TestPlayerOneWinsGame()
        {
            return new object[]
            {
                Player.Rock,
                Player.Scissors
            };
        }

        public void TestPlayerOneWinsGame(Player player1, Player player2)
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game.PlayRound(player1, player2);
            game.PlayRound(player1, player2);

            var result = listener.Winner;
            Assert.Equals(result, 1, "Player1 wins game");
        }
    }
}