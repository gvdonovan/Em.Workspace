using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Em.Workspace.Services;

namespace Biff.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine("Press Any Key to Fetch Data");
            System.Console.ReadKey();


            Run();

            System.Console.ReadKey();
            System.Console.WriteLine("Done");

        }

        static void Run()
        {
            System.Console.WriteLine("Fetching data...");
            var t = RunAsync();
            System.Console.WriteLine(string.Format("Data Returned - {0}", t.Status));

        }

        static async Task RunAsync()
        {
            var svc = new Em.Workspace.Services.BiffService();
            var results = await svc.GetAsync();
            var items = results.ToList();
            
            items.ForEach(i => System.Console.WriteLine(string.Format("{0}, {1}", i.LastName, i.FirstName)));
            System.Console.ReadLine();


        }        
    }
}
