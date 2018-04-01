using System;
using System.Reflection;
using TestFramework;

namespace RockPaperScissors.Test
{
    public class Program
    {
        private static void Main(string[] args)
        {            
            Console.WriteLine("Running RockPaperScissors tests...");
            new TestSuite(Assembly.LoadFrom("RockPaperScissors.Test.exe")).RunAll();          
            Console.ReadLine();
        }
    }
}