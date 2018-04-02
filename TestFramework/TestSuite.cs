using System;
using System.Linq;
using System.Reflection;

namespace TestFramework
{
    public class TestSuite
    {
        private static int _testsPassed;
        private static int _testsFailed;
        private readonly Assembly _assembly;

        public TestSuite(Assembly assembly)
        {
            _testsFailed = 0;
            _testsPassed = 0;
            _assembly = assembly;
        }

        public void RunAll()
        {
            RunTestFixtures();

            Console.WriteLine("Tests run: {0}  Passed: {1}  Failed: {2}", _testsPassed + _testsFailed, _testsPassed, _testsFailed);
        }

        private void RunTestFixtures()
        {
            foreach (var type in _assembly.ExportedTypes.Where(IsTest))
            {
                new TestRunner(Activator.CreateInstance(type)).RunAll();
            }
        }

        private bool IsTest(Type type)
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