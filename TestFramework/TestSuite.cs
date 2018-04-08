using System;
using System.Linq;
using System.Reflection;

namespace TestFramework
{
    public class TestSuite
    {
        private readonly Assembly _assembly;

        public TestSuite(Assembly assembly)
        {
            _assembly = assembly;
        }

        public void RunAll()
        {
            RunTestFixtures();

            TestResults.WriteResultSummary();
        }

        private void RunTestFixtures()
        {
            foreach (var type in _assembly.ExportedTypes.Where(IsTest))
            {
                new TestRunner(Activator.CreateInstance(type)).RunAll();
            }
        }

        private static bool IsTest(Type type)
        {
            return type.Name.EndsWith("Tests");
        }
    }
}