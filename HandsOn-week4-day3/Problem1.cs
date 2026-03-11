using System;

namespace Dotnet_C__Demo.HandsOn_week4_day3
{
    internal class Problem1
    {
        static void Main()
        {
            Console.Write("Enter student name :");
            string name = Console.ReadLine();

            Console.Write("Enter marks:");
            int marks = Convert.ToInt32(Console.ReadLine());

            if(marks<0 || marks > 100)
            {
                Console.WriteLine("Invalid marks! marks should be between 0 and 100.");
            }
            else
            {
                string grade;
                if (marks >= 90)
                {
                    grade = "A";
                }else if(marks>=75){
                    grade= "B";
                }
                else if(marks>=60)
                {
                    grade = "C";
                }else if (marks >= 50)
                {
                    grade= "D";
                }
                else
                {
                    grade = "Fail";
                }
                Console.WriteLine("Student:" + name);
                Console.WriteLine("Grade:" + grade);
            }
   
        }
    }
}
