using System;

namespace RockPaperScissors.Test
{
    internal class Program
    {
        private static int _testsPassed;
        private static int _testsFailed;

        private static void Main(string[] args)
        {
            _testsPassed = 0;
            _testsFailed = 0;

            // output header
            Console.WriteLine("Running RockPaperScissors tests...");

            RoundTests();

            // Game tests
            Console.WriteLine("Game tests...");

            GameTests();

            Console.WriteLine("Tests run: {0}  Passed: {1}  Failed: {2}", _testsPassed + _testsFailed, _testsPassed,
                _testsFailed);
            Console.ReadLine();
        }

        private static void GameTests()
        {
            Test.GameTests.TestPlayerOneWinsGame();

            Test.GameTests.TestPlayerTwoWinsGame();

            Test.GameTests.TestDrawsNotCounted();

            Test.GameTests.TestInvalidMovesNotCounted();
        }

        private static void RoundTests()
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