using System;

namespace RockPaperScissors.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {            
            Console.WriteLine("Running RockPaperScissors tests...");
            new TestSuite().RunAll();          
            Console.ReadLine();
        }
    }
}