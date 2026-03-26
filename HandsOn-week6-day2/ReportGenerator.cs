using System;
using System.Collections.Generic;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem1
{
    internal class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("\n----STUDENT REPORT----");
            foreach(var Student in students)
            {
                Console.WriteLine($"ID:{Student.StudentId}");
                Console.WriteLine($"Name:{Student.StudentName}");
                Console.WriteLine($"Marks:{Student.Marks}");

                string result = Student.Marks >= 40 ? "Pass" : "Fail";
                Console.WriteLine($"Result:{result}");

                Console.WriteLine("--------------");
            }
        }
    }
}
