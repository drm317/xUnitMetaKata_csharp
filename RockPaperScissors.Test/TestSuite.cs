using System;
using System.Linq;
using System.Reflection;

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
            RunTestFixtures();

            Console.WriteLine("Tests run: {0}  Passed: {1}  Failed: {2}", _testsPassed + _testsFailed, _testsPassed, _testsFailed);
        }

        private void RunTestFixtures()
        {
            foreach (var type in Assembly.GetExecutingAssembly().ExportedTypes.Where(IsFixture))
            {
                new TestRunner(Activator.CreateInstance(type)).RunAll();
            }
        }

        private bool IsFixture(Type type)
        {
            return type.Name.EndsWith("Tests");
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