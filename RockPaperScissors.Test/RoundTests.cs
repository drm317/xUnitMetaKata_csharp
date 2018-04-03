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

        private object[][] Parameters_TestRoundIsADraw()
        {
            return new[]
            {
                new object[] {Player.Rock, Player.Rock, 0},
                new object[] {Player.Scissors, Player.Scissors, 0},
                new object[] {Player.Paper, Player.Paper, 0},
            };
        }

        public void TestRoundIsADraw(Player player1, Player player2, int expectedResult)
        {
            var result = new Round().Play(player1, player1);
            Assert.Equals(result, expectedResult, $"Round is a draw ({player1} {player2})");
        }

        private object[][] Parameters_TestPaperWrapsRock()
        {
            return new[]
            {
                new object[] {Player.Paper, Player.Rock, 1},
                new object[] {Player.Rock, Player.Paper, 2}
            };
        }

        public void TestPaperWrapsRock(Player player1, Player player2, int expectedResult)
        {
            var result = new Round().Play(player1, player2);
            Assert.Equals(result, expectedResult, $"Paper wraps rock ({player1} {player2})");
        }

        private object[][] Parameters_TestScissorsCutPaper()
        {
            return new[]
            {
                new object[] {Player.Scissors, Player.Paper, 1},
                new object[] {Player.Paper, Player.Scissors, 2}
            };
        }

        public void TestScissorsCutPaper(Player player1, Player player2, int expectedResult)
        {
            var result = new Round().Play(player1, player2);
            Assert.Equals(result, expectedResult, $"Scissors cut paper ({player1} {player2})");
        }

        private object[][] Parameters_TestRockBluntsScissors()
        {
            return new[]
            {
                new object[] {Player.Rock, Player.Scissors, 1},
                new object[] {Player.Scissors, Player.Rock, 2}
            };
        }

        public void TestRockBluntsScissors(Player player1, Player player2, int expectedResult)
        {
            var result = new Round().Play(player1, player2);
            Assert.Equals(result, expectedResult, $"Rock blunts scissors ({player1} {player2})");
        }
    }
}