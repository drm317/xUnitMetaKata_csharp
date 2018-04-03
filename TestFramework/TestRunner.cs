using System.Reflection;

namespace TestFramework
{
    public class TestRunner
    {
        private readonly object _testFixture;

        public TestRunner(object testFixture)
        {
            _testFixture = testFixture;
        }

        public void RunAll()
        {
            foreach (var method in _testFixture.GetType().GetMethods())
                if (IsTest(method))
                    InvokeTest(method);
        }

        private void InvokeTest(MethodInfo method)
        {
            if (IsParameterisedTest(method))
                InvokeParameterised(method);
            else
                method.Invoke(_testFixture, null);
        }

        private void InvokeParameterised(MethodBase method)
        {
            var parametersMethod = _testFixture.GetType()
                .GetMethod("Parameters_" + method.Name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (parametersMethod == null) return;
            var scenarios = (object[][]) parametersMethod.Invoke(_testFixture, null);
            foreach (var parameters in scenarios) method.Invoke(_testFixture, parameters);
        }

        private static bool IsParameterisedTest(MethodInfo method)
        {
            return method.GetParameters().Length > 0;
        }

        private static bool IsTest(MethodInfo method)
        {
            return method.Name.StartsWith("Test");
        }
    }
}