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

        private object[] Parameters_TestRoundIsADraw()
        {
            return new object[]
            {
                Player.Rock,
                Player.Scissors,
                Player.Paper
            };
        }

        public void TestRoundIsADraw(Player playerRock, Player playerScissors, Player playerPaper)
        {
            var result = new Round().Play(playerRock, playerRock);
            Assert.Equals(result, 0, "Round is a draw (Rock Rock)");

            result = new Round().Play(playerScissors, playerScissors);
            Assert.Equals(result, 0, "Round is a draw (Scissors Scissors)");

            result = new Round().Play(playerPaper, playerPaper);
            Assert.Equals(result, 0, "Round is a draw (Paper Paper)");
        }

        private object[] Parameters_TestPaperWrapsRock()
        {
            return new object[]
            {
                Player.Paper,
                Player.Rock
            };
        }

        public void TestPaperWrapsRock(Player playerPaper, Player playerRock)
        {
            var result = new Round().Play(playerPaper, playerRock);
            Assert.Equals(result, 1, "Paper wraps rock (Paper rock)");

            result = new Round().Play(playerRock, playerPaper);
            Assert.Equals(result, 2, "Paper wraps rock (Rock Paper)");
        }

        private object[] Parameters_TestScissorsCutPaper()
        {
            return new object[]
            {
                Player.Scissors,
                Player.Paper
            };
        }

        public void TestScissorsCutPaper(Player playerScissors, Player playerPaper)
        {
            var result = new Round().Play(playerScissors, playerPaper);
            Assert.Equals(result, 1, "Scissors cut paper (Scissors Paper)");

            result = new Round().Play(playerPaper, playerScissors);
            Assert.Equals(result, 2, "Scissors cut paper (Paper Scissors)");
        }

        private object[] Parameters_TestRockBluntsScissors()
        {
            return new object[]
            {
                Player.Rock,
                Player.Scissors
            };
        }

        public void TestRockBluntsScissors(Player playerRock, Player playerScissors)
        {
            var result = new Round().Play(playerRock, playerScissors);
            Assert.Equals(result, 1, "Rock blunts scissors (Rock Scissors)");

            result = new Round().Play(playerScissors, playerRock);
            Assert.Equals(result, 2, "Rock blunts scissors (Scissors Rock)");
        }
    }
}