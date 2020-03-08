using System;

namespace TestFramework
{
    public class TestResults
    {
        private static int _testsFailed;
        private static int _testsPassed;

        public static void AddTestsFailed()
        {
            _testsFailed++;
        }

        public static void AddTestsPassed()
        {
            _testsPassed++;
        }

        public static void WriteResultSummary()
        {
            Console.WriteLine("Tests run: {0}  Passed: {1}  Failed: {2}", _testsPassed + _testsFailed, _testsPassed,
                _testsFailed);
        }

        public static void WriteTestResult(Type expectedException, string testCase)
        {
            Console.WriteLine("{0}: FAIL - expected {1}", testCase, expectedException);
        }

        public static void WriteTestResult(string testCase)
        {
            Console.WriteLine("{0}: PASS", testCase);
        }

        public static void WriteTestResult(int expected, int result, string testCase)
        {
            Console.WriteLine("{2}: FAIL - expected {1} but was {0}", result, expected, testCase);
        }
    }
}