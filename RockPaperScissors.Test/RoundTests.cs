using System;
using TestFramework;

namespace RockPaperScissors.Test
{
    public class RoundTests
    {
        public static void TestInvalidInputsNotAllowed()
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

        private object[][] Parameters_TestRounds()
        {
            return new[]
            {
                new object[] {Player.Rock, Player.Rock, 0, "Round is a draw"},
                new object[] {Player.Scissors, Player.Scissors, 0, "Round is a draw"},
                new object[] {Player.Paper, Player.Paper, 0, "Round is a draw" },
                new object[] {Player.Paper, Player.Rock, 1, "Paper wraps rock"},
                new object[] {Player.Rock, Player.Paper, 2, "Paper wraps rock" },
                new object[] {Player.Scissors, Player.Paper, 1, "Scissors cut paper"},
                new object[] {Player.Paper, Player.Scissors, 2, "Scissors cut paper" },
                new object[] {Player.Rock, Player.Scissors, 1, "Rock blunts scissors"},
                new object[] {Player.Scissors, Player.Rock, 2, "Rock blunts scissors" }
            };
        }

        public void TestRounds(Player player1, Player player2, int expectedResult, string testCase)
        {
            var result = new Round().Play(player1, player2);
            Assert.Equals(result, expectedResult, $"{testCase} ({player1} {player2})");
        }
    }
}