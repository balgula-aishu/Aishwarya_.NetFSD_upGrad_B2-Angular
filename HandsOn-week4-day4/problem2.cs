using System;


namespace Dotnet_C__Demo.HandsOn_week4_day4
{
    class Student
    {
        public double CalculateAverage(int m1, int m2, int m3)
        {
            double avg = (m1 + m2 + m3) / 3.0;
            return avg;
        }
    }

    internal class problem2
    {
        static void Main()
        {
            Console.Write("Enter Mark1:");
            int m1=Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Mark2:");
            int m2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Mark3:");
            int m3 = Convert.ToInt32(Console.ReadLine());

            Student student = new Student();
            double average=student.CalculateAverage(m1, m2, m3);

            String grade;
            if (average >= 80)
            {
                grade = "A";
            }else if (average >= 60)
            {
                grade = "B";
            }else if(average >= 50)
            {
                grade= "C";
            }
            else
            {
                grade = "Fail";
            }
            Console.WriteLine("Average=" + average);
            Console.WriteLine("Grade="+grade);
        }
    }
}
