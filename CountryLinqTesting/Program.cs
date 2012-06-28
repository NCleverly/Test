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
                documentStore.DatabaseCommands.PutIndex(
                    (session.Where(doc => doc.Category != null && doc.Data != null).Select(doc => new
                                                                                                   {
                                                                                                       __category =
                                                                                                   doc.Category,
                                                                                                       campaign =
                                                                                                   doc.Data.utm_campaign ??
                                                                                                   doc.Data.campaign ??
                                                                                                   "n/a",
                                                                                                       source =
                                                                                                   doc.Data.utm_source ??
                                                                                                   doc.Data.source ??
                                                                                                   "n/a",
                                                                                                       log_date_time =
                                                                                                   doc.Timestamp,
                                                                                                       device =
                                                                                                   doc.Data.did,
                                                                                                       app_name =
                                                                                                   doc.Data.package ??
                                                                                                   doc.Data.product,
                                                                                                       configuration_id
                                                                                                   = doc.Data.custom_tag,
                                                                                                       country =
                                                                                                   doc.Data.utm_term ??
                                                                                                   doc.Data.term ??
                                                                                                   doc.Data.locale ??
                                                                                                   "n/a",
                                                                                                       ipaddr =
                                                                                                   doc["@metadata"][
                                                                                                       "IPAddress"]
                                                                                                   })
                    )
                  );
                Console.WriteLine("index creation successful");
                Console.ReadLine();
            }
        }
    }
}
            
        
    

