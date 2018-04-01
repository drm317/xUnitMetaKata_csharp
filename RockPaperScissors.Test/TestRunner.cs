using System.Reflection;

namespace RockPaperScissors.Test
{
    public class TestRunner
    {
        private readonly object _testFixture;

        public TestRunner(object testFixture)
        {
            this._testFixture = testFixture;
        }

        public void RunAll()
        {
            foreach (var method in _testFixture.GetType().GetMethods())
            {
                if (IsTest(method))
                {
                    InvokeTest(method);
                }
            }
        }

        private void InvokeTest(MethodInfo method)
        {
            method.Invoke(_testFixture, null);
        }

        private static bool IsTest(MethodInfo method)
        {
            return method.Name.StartsWith("Test");
        }
    }
}