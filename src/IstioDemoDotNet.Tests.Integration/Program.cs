using System;
using System.Linq;
using System.Threading;

namespace IstioDemoDotNet.Tests.Integration
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("I am a placeholder for real integration tests!");
            Console.WriteLine("Tests starting....");
            Console.WriteLine("Results: ");
            if (args.Any(a => string.Equals("--fail", a, StringComparison.OrdinalIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("All Tests failed!");
                return 1;
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All Tests passed!");
            return 0;
        }
    }
}
