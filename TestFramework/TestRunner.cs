using System.Reflection;

namespace TestFramework
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
            if (IsParameterised(method))
            {
                MethodInfo parametersMethod = _testFixture.GetType().GetMethod("Parameters_" + method.Name, BindingFlags.NonPublic | BindingFlags.Instance);
                if (parametersMethod != null)
                {
                    object[] parameters = (object[]) parametersMethod.Invoke(_testFixture, null);
                    method.Invoke(_testFixture, parameters);
                }
            }
            else
            {
                method.Invoke(_testFixture, null);
            }
            
        }

        private bool IsParameterised(MethodInfo method)
        {
            return method.GetParameters().Length > 0;
        }

        private static bool IsTest(MethodInfo method)
        {
            return method.Name.StartsWith("Test");
        }
    }
}