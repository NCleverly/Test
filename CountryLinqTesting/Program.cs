using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Raven.Client.Document;

namespace CountryLinqTesting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var documentStore = new DocumentStore {Url = "http://localhost:81/raven/studio.html#/collections?database=sigma-stream"};
            documentStore.Initialize();

            using (var session = documentStore.OpenSession())
            {
               
                Console.WriteLine("index creation successful");
                Console.ReadLine();
            }
        }
    }
}
            
        
    

