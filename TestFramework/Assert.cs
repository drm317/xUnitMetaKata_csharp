using System;

namespace TestFramework
{
    public class Assert
    {
        public static void Throws(Type exception, Type expectedException, string testCase)
        {
            if (expectedException == exception)
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