using System;
using TestFramework;

namespace RockPaperScissors.Test
{
    public class GameTests
    {
        private static SpyGameListener _listener;
        private static Game _game;

        private object[][] Parameters_TestInvalidGames()
        {
            return new[]
            {
                new object[] {Player.Rock, Player.Scissors, 0, "Invalid moves not counted" }
            };
        }

        public void TestInvalidGames(Player player1, Player player2, int expectedResult, string testCase)
        {
            try
            {
                _game.PlayRound(null, null);
                _game.PlayRound(player1, player2);
            }
            catch (Exception e)
            {
            }

            Assert.Equals(expectedResult, _listener.Winner, testCase);
        }

        public void Before()
        {
            _listener = new SpyGameListener();
            _game = new Game(_listener);
        }

        public void After()
        {
            _listener = null;
            _game = null;
        }

        private object[][] Parameters_TestGames()
        {
            return new[]
            {
                new object[] {Player.Rock, Player.Rock, 0, "Draws not counted"},
                new object[] {Player.Rock, Player.Scissors, 1, "Player1 wins game"},
                new object[] {Player.Rock, Player.Paper, 2, "Player2 wins game"}
            };
        }

        public void TestGames(Player player1, Player player2, int expectedResult, string testCase)
        {
            _game.PlayRound(player1, player2);
            _game.PlayRound(player1, player2);

            Assert.Equals(expectedResult, _listener.Winner, testCase);
        }
    }
}