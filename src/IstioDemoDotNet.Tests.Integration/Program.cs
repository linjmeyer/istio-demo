using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace IstioDemoDotNet.Tests.Integration
{
    static class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine("I am a placeholder for real integration tests!");
            Console.WriteLine("Tests starting....");
            Console.WriteLine("Results: ");

            if (ShouldFail(args)) return Fail();
            
            var tests = await DoTests();
            if (!tests) return Fail();
            
            return Pass();
        }

        static bool ShouldFail(string[] args)
        {
            return args.Any(a => string.Equals("--fail", a, StringComparison.OrdinalIgnoreCase))
                   || string.Equals(Environment.GetEnvironmentVariable("DEMO_TESTS_FAIL"), "true",
                       StringComparison.OrdinalIgnoreCase);
        }

        static int Pass()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All Tests passed!");
            return 0;
        }
        
        static int Fail()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("All Tests failed!");
            return 1;
        }

        static string GetUrl()
        {
            return Environment.GetEnvironmentVariable("DEMO_TESTS_URL");
        }

        static async Task<bool> DoTests()
        {
            using (var client = new HttpClient())
            {
                var url = GetUrl();
                for (var i = 0; i < 25; i++)
                {
                    var result = await client.GetAsync(url);
                    var resultBodyJson = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultBodyJson.RemoveNewlines());
                }
            }

            return true;
        }

        static string RemoveNewlines(this string item)
        {
            return Regex.Replace(item, @"\t|\n|\r", string.Empty);
        }
    }
}
