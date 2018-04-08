using System.Collections.Generic;
using System.Linq;
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
            var methods = _testFixture.GetType().GetMethods();
            var beforeEachMethod = GetBeforeEachMethod(methods);
            var afterEachMethod = GetAfterEachMethod(methods);
            foreach (var method in methods)
                if (IsTest(method))
                {
                    if (beforeEachMethod != null) beforeEachMethod.Invoke(_testFixture, null);
                    InvokeTest(method);
                    if (afterEachMethod != null) afterEachMethod.Invoke(_testFixture, null);
                }
        }

        private static MethodInfo GetAfterEachMethod(IEnumerable<MethodInfo> methods)
        {
            return methods.FirstOrDefault(IsAfterEachMethod);
        }

        private static bool IsAfterEachMethod(MethodInfo method)
        {
            return method.Name.Equals("AfterEach");
        }

        private static MethodInfo GetBeforeEachMethod(IEnumerable<MethodInfo> methods)
        {
            return methods.FirstOrDefault(IsBeforeEachMethod);
        }

        private static bool IsBeforeEachMethod(MethodInfo method)
        {
            return method.Name.Equals("BeforeEach");
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
            if (parametersMethod == null)
                return;
            var scenarios = (object[][]) parametersMethod.Invoke(_testFixture, null);
            foreach (var parameters in scenarios)
                method.Invoke(_testFixture, parameters);
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