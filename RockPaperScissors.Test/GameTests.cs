using System;
using TestFramework;

namespace RockPaperScissors.Test
{
    public class GameTests
    {
        private SpyGameListener _listener;
        private Game _game;

        public void BeforeEach()
        {
            _listener = new SpyGameListener();
            _game = new Game(_listener);
        }

        private object[][] Parameters_TestInvalidMovesNotCounted()
        {
            return new[]
            {
                new object[] {Player.Rock, Player.Scissors, 0}
            };
        }

        public void TestInvalidMovesNotCounted(Player player1, Player player2, int expectedResult)
        {
            try
            {
                _game.PlayRound(null, null);
                _game.PlayRound(player1, player2);
            }
            catch (Exception e)
            {
            }

            var result = _listener.Winner;
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
            _game.PlayRound(player1, player2);
            _game.PlayRound(player1, player2);

            var result = _listener.Winner;
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
            _game.PlayRound(player1, player2);
            _game.PlayRound(player1, player2);

            var result = _listener.Winner;
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
            _game.PlayRound(player1, player2);
            _game.PlayRound(player1, player2);

            var result = _listener.Winner;
            Assert.Equals(result, expectedResult, "Player1 wins game");
        }
    }
}