using System;
using System.Reflection;
using TestFramework;

namespace RockPaperScissors.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // output header
            Console.WriteLine("Running RockPaperScissors tests...");
            new TestSuite(Assembly.LoadFrom("RockPaperScissors.Test.exe")).RunAll();
            Console.ReadLine();
        }
    }
}