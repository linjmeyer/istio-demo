using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IstioDemoDotNet.Tests.Integration
{
    static class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine("I am a placeholder for real integration tests!");
            Console.WriteLine("Tests starting....");

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
            
            var url = GetUrl();
            for (var i = 0; i < 50; i++)
            {
                using var client = new HttpClient();
                var result = await client.GetAsync(url);
                var resultBodyJson = await result.Content.ReadAsStringAsync();
                var serverHeader = result.Headers.Server.ToString();
                Console.WriteLine($"Content: {resultBodyJson.RemoveNewlines()}, Server: {serverHeader}");
            }

            return true;
        }

        static string RemoveNewlines(this string item)
        {
            return Regex.Replace(item, @"\t|\n|\r", string.Empty);
        }
    }
}
