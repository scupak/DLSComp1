using System;
using System.Collections.Generic;
using System.Net.Http;
using Common;
using Newtonsoft.Json;

namespace ConsoleSearch
{
    public class App
    {
        public void Run()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5218");
            Console.WriteLine("Console Search");
            
            while (true)
            {
                Console.WriteLine("enter search terms - q for quit");
                string input = Console.ReadLine() ?? string.Empty;
                if (input.Equals("q")) break;
                
                string resultString = string.Empty;
                client.GetStringAsync("/Search?terms=" + input + "&numberOfResults=" + 10).ContinueWith(
                    (task) =>
                    {
                        resultString = task.Result;
                    }).Wait();
                SearchResult result = JsonConvert.DeserializeObject<SearchResult>(resultString);

                foreach (var ignored in result.IgnoredTerms)
                {
                    Console.WriteLine(ignored + " will be ignored");
                }

                foreach (var doc in result.Documents)
                {
                    Console.WriteLine(doc.Id + ": " + doc.Path + " -- contains " + doc.NumberOfAppearances + " search terms");
                }
                
                Console.WriteLine("Documents: " + result.Documents.Count + ". Time: " + result.EllapsedMiliseconds + " ms");

            }
        }
    }
}
