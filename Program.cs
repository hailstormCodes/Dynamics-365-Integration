using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk.Query;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Authenticate
            string connectionString = @"AuthType=OAuth;

                Username=username;

                Password=password;

                Url=url;

                AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;

                RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";

            CrmServiceClient service = new CrmServiceClient(connectionString);
                //Create a contact record

                //LINQ using Early Binding

            using (svcContext context = new svcContext(service))
            {
                //Get accounts from Seattle
                var accounts = from a in context.AccountSet
                               where a.Address1_City == "Seattle"
                               select a;
            }
                

            //LINQ Query - Late Binding
            //    using (OrganizationServiceContext context = new OrganizationServiceContext(service))
            //{
            //    var records = from c in context.CreateQuery("contact")
            //                  join
            //                  a in context.CreateQuery("account")
            //                  on c["parentcustomerid"] equals a["accountid"]
            //                  where c["parentcustomerid"] != null
            //                  select new
            //                  {
            //                      FullName = c["fullname"],
            //                      AccountName = a["name"]
            //                  };

            //    foreach (var record in records)
            //    {
            //        Console.WriteLine(record.FullName + " " + record.AccountName);
            //    }


                //LINQ Query 


                //{
                //    // Pull contacts where city == "Redmond"
                //    var records = from contact in context.CreateQuery("contact")
                //                  where contact["address1_city"].Equals("Redmond")
                //                  select contact;

                //    foreach (var record in records)
                //    {
                //        Console.WriteLine(record.Attributes["fullname"].ToString() + " " + record.Attributes["address1_city"].ToString());
                //    }
                //}


                //Counting Leads

                //string query = @"<fetch distinct = 'false' mapping='logical' aggregate='true'>
                //<entity name='contact'>
                //<attribute name='contactid' aggregate='count' alias='NumberOfContacts'/>
                //</entity>
                //</fetch>";

                //EntityCollection collection = service.RetrieveMultiple(new FetchExpression(query));

                //foreach(Entity item in collection.Entities)
                //{
                //    Console.WriteLine(((AliasedValue)item.Attributes["NumberOfContacts"]).Value.ToString());
                //}


                Console.Read();
            }
        }
    }
}
