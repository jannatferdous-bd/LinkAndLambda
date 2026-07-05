using LinkAndLambda.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkAndLambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
				DoTask();
			}
			catch (Exception ex )
			{

                Console.WriteLine(ex.Message );
			}
			finally
		    {
                Console .ReadLine ();
			}
        }

        private static void DoTask()
        {
            var customers = new[]
            {
                    new { CustomerID = 1, FirstName = "Kim", LastName =
                      "Abercrombie", CompanyName = "Alpine Ski House" },
                    new { CustomerID = 2, FirstName = "Jeff", LastName = "Hay",
                          CompanyName = "Coho Winery" },
                    new { CustomerID = 3, FirstName = "Charlie", LastName =
                         "Herb",
                          CompanyName = "Alpine Ski House" },
                    new { CustomerID = 4, FirstName = "Chris", LastName =
                         "Preston",
                          CompanyName = "Trey Research" },
                    new { CustomerID = 5, FirstName = "Dave", LastName =
                         "Barnett",
                          CompanyName = "Wingtip Toys" },
                    new { CustomerID = 6, FirstName = "Ann", LastName = "Beebe",
                          CompanyName = "Coho Winery" },
                    new { CustomerID = 7, FirstName = "John", LastName = "Kane",
                          CompanyName = "Wingtip Toys" },
                    new { CustomerID = 8, FirstName = "David", LastName =
                          "Simpson",
                          CompanyName = "Trey Research" },
                    new { CustomerID = 9, FirstName = "Greg", LastName =
                         "Chapman",
                          CompanyName = "Wingtip Toys" },
                    new { CustomerID = 10, FirstName = "Tim", LastName = "Litton",CompanyName = "Wide World Importers" }
            };

            var addresses = new[]
            {
                    new { CompanyName = "Alpine Ski House", City = "Berne",
                          Country = "Switzerland"},
                    new { CompanyName = "Coho Winery", City = "San Francisco",
                          Country = "United States"},
                    new { CompanyName = "Trey Research", City = "New York",
                          Country = "United States"},
                    new { CompanyName = "Wingtip Toys", City = "London",
                          Country = "United Kingdom"},
                    new { CompanyName = "Wide World Importers", City = "Tetbury",
                          Country = "United Kingdom"}
            };


            Console.WriteLine();
            Console.WriteLine("=========Linq========");
            var cNames = from cust in customers select cust.FirstName ;
            foreach (var fName in cNames )
            {
                Console.WriteLine(fName);
            }
            Console.WriteLine();
            var cusNames=from cust in customers select new { cust.FirstName, cust.LastName };
            foreach (var fName in cusNames )
            { 
                Console.WriteLine($"{fName .LastName }{fName .FirstName }"); 
            }
            Console.WriteLine();
            var coms=from a in addresses where String .Equals (a.Country,"United States") select a.CompanyName;
            foreach (var item in coms )
            { 
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("DESC");
            var order=from a in addresses orderby a.CompanyName select  a.CompanyName;
            foreach (var item in coms)
            {
                Console.WriteLine(item);
            }

            var orderDesc = from a in addresses orderby a.CompanyName descending select a.CompanyName;
            foreach (var item in orderDesc )
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Groupping");
            var comps = from a in addresses group a by a.Country;
            foreach (var companiesPerCountry  in comps )
            {
                Console.WriteLine($"{companiesPerCountry .Key} \t {companiesPerCountry.Count()}");
                foreach (var item in companiesPerCountry )
                {
                    Console.WriteLine($"\t {item .CompanyName }");
                }
                Console.WriteLine();

            }
            Console.WriteLine();
            Console.WriteLine("Count");
            int nums=(from a in addresses select a.CompanyName).Count();
            Console.WriteLine(nums );


            int disnums = (from a in addresses select a.CompanyName).Distinct ().Count();
            Console.WriteLine(disnums);
            Console.WriteLine();
            Console.WriteLine("Join");
           // var candA






            Console.WriteLine();
            Console.WriteLine("================Lambda=========");








            Console.WriteLine("=====================");
            Console.WriteLine("Us Companies");
            Console.WriteLine("Filtering");
            Console.WriteLine("==========================");

            IEnumerable <string > usCompanies=addresses .Where(addr=>String .Equals(addr.Country,"United States")).Select (usComp=> usComp.CompanyName);
            foreach (var usComp in usCompanies)
            {
                Console.WriteLine(usComp);
            }
            Console.WriteLine();
            Console.WriteLine("========================");
            Console.WriteLine("Ordering");
            Console.WriteLine();
            Console.WriteLine("ASC");
            IEnumerable<string> comNames = addresses.OrderBy(addr=>addr.CompanyName).Select (comp=>comp.CompanyName);
            foreach (var comName in comNames)
            {
                Console.WriteLine(comName);
            }
            Console.WriteLine();
            Console.WriteLine("DESC");
            IEnumerable<string> comDesc = addresses.OrderByDescending(addr => addr.CompanyName).Select(comp => comp.CompanyName);
            foreach (string item in comDesc)
            {
                Console.WriteLine(item );
            }
            Console.WriteLine();
            Console.WriteLine("Grouping");

            var companiesByGroup = addresses.GroupBy(addr => addr.Country);
            foreach (var companyPerCountry in companiesByGroup)
            {
                Console.WriteLine($"Country :{companyPerCountry .Key }\t {companyPerCountry .Count ()}companies ");
                foreach (var item in companyPerCountry )
                {
                    Console.WriteLine($"\t {item .CompanyName}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Grouping using select");
            int numOfCompanies=addresses .Select (addr => addr.CompanyName).Count();
            Console.WriteLine($"Number of Companies: {numOfCompanies}");
            Console.WriteLine();

            int numberOfDistinctCountries=addresses .Select (addr => addr.Country ).Distinct ().Count();
            Console.WriteLine($"Distinct Countries:{numberOfDistinctCountries}");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Joining");
            var companiesAndAddress= customers .Select (c=> new {c.FirstName ,c.LastName ,c.CompanyName }).Join (addresses,custs=> custs.CompanyName ,addrs=>addrs.CompanyName ,(custs,addrs)=> new {custs.FirstName ,custs.LastName ,addrs.CompanyName ,addrs.Country });
            foreach (var row in companiesAndAddress)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine();



            Console.WriteLine("Selection");
            Console.WriteLine();

            IEnumerable<string> custFirstNames = customers.Select(cust => cust.FirstName);
            foreach (string fName in custFirstNames)
            {
                Console.WriteLine(fName);
            }
            Console.WriteLine();
            IEnumerable<string> names = customers.Select(cust => $"{cust.FirstName}{cust.LastName}");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            IEnumerable<FullName> custFullNames = customers.Select(must => new FullName
            {
                FirstName = must.FirstName,
                LastName = must.LastName
            });
            Console.WriteLine();
            Console.WriteLine("Using name param ");
            foreach (FullName name in custFullNames)
            {
                Console.WriteLine(name.LastName + " " + name.FirstName);
            }
            Console.WriteLine();
            foreach (FullName name in custFullNames)
            {
                Console.WriteLine($"{name.FirstName}{name.LastName}");
            }
            var customersName = customers.Select(cust => new
            {
                CustFirstName = cust.FirstName,
                CustLastName = cust.LastName,
            });
            foreach (var name in customersName)
            {
                Console.WriteLine($"{name.CustLastName }{name.CustFirstName }");
            }
        }
    }
}
