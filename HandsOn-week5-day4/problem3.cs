using System;


namespace Dotnet_C__Demo.HandsOn_week5_day4
{
    internal class problem3
    {
        static void Main()
        {
            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Monthly Sales Amount");
            double sales=Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Customer Rating (1-5):");
            int rating=Convert.ToInt32(Console.ReadLine());

            //call method that returns tuple
            var result = GetPerformaceData(sales, rating);

            //pattern matching using switch
            string performance = result switch
            {
                ( >= 100000, >= 4) => "High Performer",
                ( >= 50000, >= 3) => "Average Performer",
                _ => "Needs Improvement"
            };
            Console.WriteLine("\n-----Employee Details---");
            Console.WriteLine("Name:" + name);
            Console.WriteLine("Sales Amount:" + result.sales);
            Console.WriteLine("Rating:" + result.rating);
            Console.WriteLine("Performance:" + performance);

        }
        //method that returning tuple
        static (double sales,int rating) GetPerformaceData(double sales,int rating)
        {
            return (sales,rating);
        }

        
    }
}
