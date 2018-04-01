using System;

namespace RockPaperScissors.Test
{
    public class TestSuite
    {
        private static int _testsPassed;
        private static int _testsFailed;

        public TestSuite()
        {
            _testsFailed = 0;
            _testsPassed = 0;
        }

        public void RunAll()
        {
            RoundTests();

            GameTests();

            Console.WriteLine("Tests run: {0}  Passed: {1}  Failed: {2}", _testsPassed + _testsFailed, _testsPassed, _testsFailed);
        }

        private void GameTests()
        {
            Test.GameTests.TestPlayerOneWinsGame();

            Test.GameTests.TestPlayerTwoWinsGame();

            Test.GameTests.TestDrawsNotCounted();

            Test.GameTests.TestInvalidMovesNotCounted();
        }

        private void RoundTests()
        {

            Test.RoundTests.TestRockBluntsScissors();

            Test.RoundTests.TestScissorsCutPaper();

            Test.RoundTests.TestPaperWrapsRock();

            Test.RoundTests.TestRoundIsADraw();

            Test.RoundTests.TestInvalidInputsNotAllowed();
        }

        public static void AddTestsFailed()
        {
            _testsFailed++;
        }

        public static void AddTestsPassed()
        {
            _testsPassed++;
        }


    }
}