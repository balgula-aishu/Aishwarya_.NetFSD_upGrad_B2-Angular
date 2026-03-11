using System;


namespace Dotnet_C__Demo.HandsOn_week4_day3
{
    internal class problem4
    {
        static void Main()
        {
            Console.Write("Enter number:");
            int N = Convert.ToInt32(Console.ReadLine());

            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;

            for (int i = 1; i <= N; i++)
            {
                sum = sum + i;
                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }
            Console.WriteLine("Even Count:" + evenCount);
            Console.WriteLine("Odd Count:" + oddCount);
            Console.WriteLine("Sum:" + sum);
        }
    }
}
