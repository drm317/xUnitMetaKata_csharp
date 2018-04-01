using System;

namespace RockPaperScissors.Test
{
    public class Assert
    {
        public static void Throws(Exception exception, string testCase)
        {
            if (exception is InvalidMoveException)
            {
                TestSuite.AddTestsPassed();
                Console.WriteLine("{0}: PASS", testCase);
            }
            else
            {
                TestSuite.AddTestsFailed();
                Console.WriteLine("{0}: FAIL - expected InvalidMoveException", testCase);
            }
        }

        public static void Equals(int result, int expected, string testCase)
        {
            if (result == expected)
            {
                TestSuite.AddTestsPassed();
                Console.WriteLine("{0}: PASS", testCase);
            }
            else
            {
                TestSuite.AddTestsFailed();
                Console.WriteLine("{2}: FAIL - expected {1} but was {0}", result, expected, testCase);
            }
        }
    }
}