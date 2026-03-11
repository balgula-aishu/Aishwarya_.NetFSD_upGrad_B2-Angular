using System;



namespace Dotnet_C__Demo.HandsOn_week4_day3
{
    internal class problem3
    {
        static void Main()
        {
            Console.Write("Enter Name:");
            string name = Console.ReadLine();

            Console.Write("Enter salary:");
            double salary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Experience(years):");
            int experience = Convert.ToInt32(Console.ReadLine());

            double bonusPercent;

            //determine bonus percentage using if else
            if (experience < 2)
            {
                bonusPercent = 0.05;
            }
            else if (experience < 5)
            {
                bonusPercent = 0.10;
            }
            else
            {
                bonusPercent = 0.15;
            }
            double bonus = salary > 0 ? salary * bonusPercent : 0;
            double finalSalary = salary + bonus;
            Console.WriteLine("\nEmployee:" + name);
            Console.WriteLine("Bonus:" + bonus.ToString("F2"));
            Console.WriteLine("Final Salary:" + finalSalary.ToString("F2"));

        }
    }
}
