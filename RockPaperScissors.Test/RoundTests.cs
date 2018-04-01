using System;

namespace RockPaperScissors.Test
{
    public class RoundTests
    {
        public static void TestInvalidInputsNotAllowed()
        {
            Exception exception = null;

            try
            {
                new Round().Play("Blah", "Foo");
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.Throws(exception, "Invalid inputs not allowed");
        }

        public static void TestRoundIsADraw()
        {
            var result = new Round().Play("Rock", "Rock");
            Assert.Equals(result, 0, "Round is a draw (Rock Rock)");

            result = new Round().Play("Scissors", "Scissors");
            Assert.Equals(result, 0, "Round is a draw (Scissors Scissors)");

            result = new Round().Play("Paper", "Paper");
            Assert.Equals(result, 0, "Round is a draw (Paper Paper)");
        }

        public static void TestPaperWrapsRock()
        {
            var result = new Round().Play("Paper", "Rock");
            Assert.Equals(result, 1, "Paper wraps rock (Paper rock)");

            result = new Round().Play("Rock", "Paper");
            Assert.Equals(result, 2, "Paper wraps rock (Rock Paper)");
        }

        public static void TestScissorsCutPaper()
        {
            var result = new Round().Play("Scissors", "Paper");
            Assert.Equals(result, 1, "Scissors cut paper (Scissors Paper)");

            result = new Round().Play("Paper", "Scissors");
            Assert.Equals(result, 2, "Scissors cut paper (Paper Scissors)");
        }

        public static void TestRockBluntsScissors()
        {
            var result = new Round().Play("Rock", "Scissors");
            Assert.Equals(result, 1, "Rock blunts scissors (Rock Scissors)");

            result = new Round().Play("Scissors", "Rock");
            Assert.Equals(result, 2, "Rock blunts scissors (Scissors Rock)");
        }
    }
}