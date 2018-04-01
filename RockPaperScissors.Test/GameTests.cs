using System;

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
                game.PlayRound("Blah", "Foo");
                game.PlayRound("Rock", "Scissors");
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
            game.PlayRound("Rock", "Rock");
            game.PlayRound("Rock", "Rock");

            var result = listener.Winner;
            Assert.Equals(result, 0, "Draw not counted");
        }

        public void TestPlayerTwoWinsGame()
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game = new Game(listener);
            game.PlayRound("Rock", "Paper");
            game.PlayRound("Rock", "Paper");

            var result = listener.Winner;
            Assert.Equals(result, 2, "Player2 wins game");
        }

        public void TestPlayerOneWinsGame()
        {
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game.PlayRound("Rock", "Scissors");
            game.PlayRound("Rock", "Scissors");

            var result = listener.Winner;
            Assert.Equals(result, 1, "Player1 wins game");
        }
    }
}