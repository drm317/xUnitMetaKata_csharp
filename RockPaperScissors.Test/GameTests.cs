using System;
using TestFramework;

namespace RockPaperScissors.Test
{
    public class GameTests
    {
        public void TestInvalidMovesNotCounted()
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            try
            {
                game.PlayRound(null, null);
                game.PlayRound(Player.Rock, Player.Scissors);
            }
            catch (Exception e)
            {
            }

            var result = listener.Winner;
            Assert.Equals(result, 0, "Invalid moves not counted");
        }

        public void TestDrawsNotCounted()
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game.PlayRound(Player.Rock, Player.Rock);
            game.PlayRound(Player.Rock, Player.Rock);

            var result = listener.Winner;
            Assert.Equals(result, 0, "Draw not counted");
        }

        public void TestPlayerTwoWinsGame()
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game.PlayRound(Player.Rock, Player.Paper);
            game.PlayRound(Player.Rock, Player.Paper);

            var result = listener.Winner;
            Assert.Equals(result, 2, "Player2 wins game");
        }

        public void TestPlayerOneWinsGame()
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game.PlayRound(Player.Rock, Player.Scissors);
            game.PlayRound(Player.Rock, Player.Scissors);

            var result = listener.Winner;
            Assert.Equals(result, 1, "Player1 wins game");
        }
    }
}