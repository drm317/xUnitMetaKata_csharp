using System;

namespace TestFramework
{
    public static class Assert
    {
        public static void Throws(Type exception, Type expectedException, string testCase)
        {
            if (exception == expectedException)
            {
                TestResults.AddTestsPassed();
                TestResults.WriteTestResult(testCase);
            }
            else
            {
                TestResults.AddTestsFailed();
                TestResults.WriteTestResult(expectedException, testCase);
            }
        }

        public static void Equals(int expected, int result, string testCase)
        {
            if (result == expected)
            {
                TestResults.AddTestsPassed();
                TestResults.WriteTestResult(testCase);
            }
            else
            {
                TestResults.AddTestsFailed();
                TestResults.WriteTestResult(expected, result, testCase);
            }
        }
    }
}