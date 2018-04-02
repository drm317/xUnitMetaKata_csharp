using System;
using TestFramework;

namespace RockPaperScissors.Test
{
    public class RoundTests
    {
        public void TestInvalidInputsNotAllowed()
        {
            Exception exception = null;

            try
            {
                new Round().Play(null, null);
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.Throws(exception?.GetType(), typeof(InvalidMoveException), "Invalid inputs not allowed");
        }

        public void TestRoundIsADraw()
        {
            var result = new Round().Play(Player.Rock, Player.Rock);
            Assert.Equals(result, 0, "Round is a draw (Rock Rock)");

            result = new Round().Play(Player.Scissors, Player.Scissors);
            Assert.Equals(result, 0, "Round is a draw (Scissors Scissors)");

            result = new Round().Play(Player.Paper, Player.Paper);
            Assert.Equals(result, 0, "Round is a draw (Paper Paper)");
        }

        public void TestPaperWrapsRock()
        {
            var result = new Round().Play(Player.Paper, Player.Rock);
            Assert.Equals(result, 1, "Paper wraps rock (Paper rock)");

            result = new Round().Play(Player.Rock, Player.Paper);
            Assert.Equals(result, 2, "Paper wraps rock (Rock Paper)");
        }

        public void TestScissorsCutPaper()
        {
            var result = new Round().Play(Player.Scissors, Player.Paper);
            Assert.Equals(result, 1, "Scissors cut paper (Scissors Paper)");

            result = new Round().Play(Player.Paper, Player.Scissors);
            Assert.Equals(result, 2, "Scissors cut paper (Paper Scissors)");
        }

        public void TestRockBluntsScissors()
        {
            var result = new Round().Play(Player.Rock, Player.Scissors);
            Assert.Equals(result, 1, "Rock blunts scissors (Rock Scissors)");

            result = new Round().Play(Player.Scissors, Player.Rock);
            Assert.Equals(result, 2, "Rock blunts scissors (Scissors Rock)");
        }
    }
}