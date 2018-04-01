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
            // player 1 wins game
            var listener = new SpyGameListener();
            var game = new Game(listener);
            game.PlayRound("Rock", "Scissors");
            game.PlayRound("Rock", "Scissors");

            var result = listener.Winner;
            Equals(result, 1, "Player1 wins game");

            // player 2 wins game
            listener = new SpyGameListener();
            game = new Game(listener);
            game.PlayRound("Rock", "Paper");
            game.PlayRound("Rock", "Paper");

            result = listener.Winner;
            Equals(result, 2, "Player2 wins game");

            // drawers not counted
            listener = new SpyGameListener();
            game = new Game(listener);
            game.PlayRound("Rock", "Rock");
            game.PlayRound("Rock", "Rock");

            result = listener.Winner;
            Equals(result, 0, "Draw not counted");

            //invalid moves not counted
            listener = new SpyGameListener();
            game = new Game(listener);
            try
            {
                game.PlayRound("Blah", "Foo");
                game.PlayRound("Rock", "Scissors");
            }
            catch (Exception e)
            {
            }

            result = listener.Winner;
            Equals(result, 0, "Invalid n");
        }

        private static void RoundTests()
        {
            // Round tests
            Console.WriteLine("Round tests...");

            // rock blunts scissors
            var result = new Round().Play("Rock", "Scissors");
            Equals(result, 1, "Rock blunts scissors (Rock Scissors)");

            result = new Round().Play("Scissors", "Rock");
            Equals(result, 2, "Rock blunts scissors (Scissors Rock)");

            // scissors cut paper
            result = new Round().Play("Scissors", "Paper");
            Equals(result, 1, "Scissors cut paper (Scissors Paper)");

            result = new Round().Play("Paper", "Scissors");
            Equals(result, 2, "Scissors cut paper (Paper Scissors)");

            // paper wraps rock
            result = new Round().Play("Paper", "Rock");
            Equals(result, 1, "Paper wraps rock (Paper rock)");

            result = new Round().Play("Rock", "Paper");
            Equals(result, 2, "Paper wraps rock (Rock Paper)");

            // round is a draw
            result = new Round().Play("Rock", "Rock");
            Equals(result, 0, "Round is a draw (Rock Rock)");

            result = new Round().Play("Scissors", "Scissors");
            Equals(result, 0, "Round is a draw (Scissors Scissors)");

            result = new Round().Play("Paper", "Paper");
            Equals(result, 0, "Round is a draw (Paper Paper)");

            // invalid inputs not allowed
            Exception exception = null;

            try
            {
                new Round().Play("Blah", "Foo");
            }
            catch (Exception e)
            {
                exception = e;
            }

            Throws(exception, "Invalid inputs not allowed");
        }

        private static void Throws(Exception exception, string testCase)
        {
            if (exception is InvalidMoveException)
            {
                AddTestsPassed();
                Console.WriteLine("{0}: PASS", testCase);
            }
            else
            {
                AddTestsFailed();
                Console.WriteLine("{0}: FAIL - expected InvalidMoveException", testCase);
            }
        }

        private static void Equals(int result, int expected, string testCase)
        {
            if (result == expected)
            {
                AddTestsPassed();
                Console.WriteLine("{0}: PASS", testCase);
            }
            else
            {
                AddTestsFailed();
                Console.WriteLine("{0}: FAIL - expected {1} but was {2}", result, expected, testCase);
            }
        }

        private static void AddTestsFailed()
        {
            _testsFailed++;
        }

        private static void AddTestsPassed()
        {
            _testsPassed++;
        }
    }


}