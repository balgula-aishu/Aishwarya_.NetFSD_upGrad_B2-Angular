using System;
using System.IO;
using System.Diagnostics;

namespace Dotnet_C__Demo.HandsOn_week6_day1
{
    internal class problem5
    {
        static void Main()
        {
            //configure trace to write into a file
            Trace.Listeners.Add(new TextWriterTraceListener("OrderLog.txt"));
            Trace.AutoFlush = true;

            Console.WriteLine("Order Processing Started...\n");

            try
            {
                ValidateOrder();
                ProcessPayment();
                UpdateInventory();
                GenerateInvoice();

                Trace.TraceInformation("Oder processed successfully.");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ERROR:" + ex.Message);
            }
            Console.WriteLine("Processing Completed. Check OrderLog.txt for details.");
        }
        static void ValidateOrder()
        {
            Trace.WriteLine("Step 1 :Validating order...");
            //simulate success
        }
        static void ProcessPayment()
        {
            Trace.WriteLine("Step 2: Processing payment...");
            //simulate success
        }
        static void UpdateInventory()
        {
            Trace.WriteLine("Step 3 :Updating Inventory...");
            //simulate failure(for debugging purpose)
            throw new Exception("Inventory update failed!");
        }
        static void GenerateInvoice()
        {
            Trace.WriteLine("Step 4: Generating Invoice...");
        }
    }
}
