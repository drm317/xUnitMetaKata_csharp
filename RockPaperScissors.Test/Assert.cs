using System;

namespace RockPaperScissors.Test
{
    public class Assert
    {
        public static void Throws(Exception exception, string testCase)
        {
            if (exception is InvalidMoveException)
            {
                Program.AddTestsPassed();
                Console.WriteLine("{0}: PASS", testCase);
            }
            else
            {
                Program.AddTestsFailed();
                Console.WriteLine("{0}: FAIL - expected InvalidMoveException", testCase);
            }
        }

        public static void Equals(int result, int expected, string testCase)
        {
            if (result == expected)
            {
                Program.AddTestsPassed();
                Console.WriteLine("{0}: PASS", testCase);
            }
            else
            {
                Program.AddTestsFailed();
                Console.WriteLine("{0}: FAIL - expected {1} but was {2}", result, expected, testCase);
            }
        }
    }
}