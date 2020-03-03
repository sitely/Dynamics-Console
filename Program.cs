using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace ConsoleApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Autenticate
            string connection_string = "AuthType=Office365;Url = https://tahlesssss2201.crm.dynamics.com/; Username = aya@tahlesssss2201.onmicrosoft.com;Password = 7Peace&7Love";
            CrmServiceClient service_client = new CrmServiceClient(connection_string);

            //Create contact 
            //Entity contact = new Entity("contact");
            //contact.Attributes.Add("firstname", "Console");
            //contact.Attributes.Add("lastname", "App");
            //contact.Attributes.Add("emailaddress1", "bla@bla.bla");
            //Guid guid = service_client.Create(contact);
            //Console.WriteLine("New Contact Created" + guid);
            //FetchXml
            //string fetch = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
            //                <entity name='contact'>
            //                <attribute name='fullname' />
            //                <attribute name='telephone1' />
            //                <attribute name='contactid' />
            //                <order attribute='fullname' descending='false' />
            //                <filter type='and'>
            //                  <condition attribute='address1_city' operator='eq' value='Los Angeles' />
            //                </filter>
            //              </entity>
            //            </fetch>";
            //EntityCollection collection = service_client.RetrieveMultiple(new FetchExpression(fetch));
            //foreach(Entity entity in collection.Entities)
            //{
            //    Console.WriteLine(entity.Attributes["fullname"].ToString());
            //}

            //Fetch Agregation
            //string fetch = @"<fetch distinct='false' mapping='logical' aggregate='true'>   
            //                   <entity name='lead'>   
            //                      <attribute name='leadid' aggregate='count' alias='leadcount'/>   
            //                   </entity>   
            //                </fetch>";
            //EntityCollection collection = service_client.RetrieveMultiple(new FetchExpression(fetch));
            //foreach (Entity item in collection.Entities)
            //{
            //    Console.WriteLine("Number of leads in system " + ((AliasedValue)item.Attributes["leadcount"]).Value.ToString());
            //}

            //Linq query
            using (OrganizationServiceContext context = new OrganizationServiceContext(service_client))
            {
                var records = from contact in context.CreateQuery("contact")
                             select contact;
                foreach (var record in records )
                {
                    if (record.Attributes.Contains("fullname"))
                        Console.WriteLine(record.Attributes["fullname"].ToString());
                }
            }
                Console.Read();
        }
    }
}
