using System;
using System.Diagnostics;

namespace Dotnet_C__Demo.HandsOn_week6_day1
{
    internal class problem2
    {
        static void Main()
        {
            Console.WriteLine("Enter product Name:");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter product Price:");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter discount Percentage:");
            double discount = Convert.ToDouble(Console.ReadLine());

            //correct formula
            double finalPrice = price - (price * discount / 100);

            Console.WriteLine("\n-----BILLS DETAILS----");
            Console.WriteLine("Product:" + productName);
            Console.WriteLine("Original Price:" + price);
            Console.WriteLine("Discount:" + discount + "%");
            Console.WriteLine("Final Price:" + finalPrice);

        
        }
    }
}
