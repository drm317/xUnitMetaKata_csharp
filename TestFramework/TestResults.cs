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

        public static void ShowResults()
        {
            Console.WriteLine("Tests run: {0}  Passed: {1}  Failed: {2}", _testsPassed + _testsFailed, _testsPassed, _testsFailed);
        }
    }
}