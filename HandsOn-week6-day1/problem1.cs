using System;
using System.Threading.Tasks;

namespace Dotnet_C__Demo.HandsOn_week6_day1
{
    internal class problem1
    {
        static async Task Main()
        {
            Console.WriteLine("Application Started...");
            //calling async logging mutiple times
            Task log1 = WriteLogAsync("User Logged in");
            Task log2 = WriteLogAsync("File uploaded");
            Task log3 = WriteLogAsync("Error occurred");

            Console.WriteLine("Main thread is still running...");

            //wait for all logs to complete
            await Task.WhenAll(log1, log2, log3);
            Console.WriteLine("All logs written successfully.");

        }
        //asynchronous method
        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Start writing log:{message}");
            //simulating file writing delay
            await Task.Delay(2000);
            Console.WriteLine($"Finished writing log:{message}");

        }
    }
}
