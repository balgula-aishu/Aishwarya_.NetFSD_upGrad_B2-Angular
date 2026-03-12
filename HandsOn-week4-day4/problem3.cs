using System;

namespace Dotnet_C__Demo.HandsOn_week4_day4
{
    class StudentResult
    {
        public void CalculateResult(int m1, int m2, int m3, out int totalMarks, out double averageMarks)
        {
            totalMarks = m1 + m2 + m3;
            averageMarks = totalMarks / 3.0;
        }

    }
    internal class problem3
    {
        static void Main()
        {
            char choice;
            do
            {
                Console.Write("Enter marks for subject1:");
                int m1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter marks for subject2:");
                int m2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter marks for subject3:");
                int m3 = Convert.ToInt32(Console.ReadLine());

                if (m1 < 0 || m1 > 100 || m2 < 0 || m2 > 100 || m3 < 0 || m3 > 100)
                {
                    Console.WriteLine("Invalid marks! Marks must be between 0 and 100.");

                }
                else
                {
                    StudentResult sr = new StudentResult();
                    int total = 0;
                    double average;

                    sr.CalculateResult(m1, m2, m3, out total, out average);
                    string result = average >= 40 ? "Pass" : "Fail";
                    Console.WriteLine("Total Marks:" + total);
                    Console.WriteLine("Average Marks:" + average);
                    Console.WriteLine("Result Status:" + result);


                }
                Console.Write("\nDo you want to enter another student?(y/n):");
                choice = Convert.ToChar(Console.ReadLine());
            } while (choice == 'y' || choice == 'Y');
        }
    }
}
