using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet_C__Demo.HandsOn_week6_day1
{
    internal class problem3
    {
        static async Task Main()
        {
            Console.WriteLine("Report Generation Started....\n");

            //run all reports concurrently
            Task salesTask = Task.Run(() => GenerateSalesReport());
            Task inventoryTask = Task.Run(() => GenerateInventoryReport());
            Task customerTask = Task.Run(() => GenerateCustomerReport());

            //wait for all tasks to complete
            await Task.WhenAll(salesTask, inventoryTask, customerTask);
            Console.WriteLine("\nAll reports generated successfully!");
        }
        static void GenerateSalesReport()
        {
            Console.WriteLine("sales Report Started...");
            Thread.Sleep(3000);  //simulating work(3sec)
            Console.WriteLine("Sales Report Completed!");
        }
        static void GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report Started...");
            Thread.Sleep(2000);  //simulating work(2sec)
            Console.WriteLine("Inventory Report Completed!");
        }
        static void GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report Started...");
            Thread.Sleep(2500);  //simulating work(2.5sec)
            Console.WriteLine("Customer Report Completed!");
        }

    }
    }

