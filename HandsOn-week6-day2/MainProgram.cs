using System;
using System.Collections.Generic;
using System.Linq;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem7
{
    internal class MainProgram
    {
        static void Main()
        {
            IStudentRepository repo = new StudentRepository();

            //add students
            repo.AddStudent(new Student { StudentId = 1, StudentName = "Aishwarya", Course = "Java" });
            repo.AddStudent(new Student { StudentId = 2, StudentName = "Rahul", Course = "WEB" });

            //view all students
            Console.WriteLine("All Students:");
            foreach (var s in repo.GetAllStudents())
            {
                Console.WriteLine($"{s.StudentId}-{s.StudentName}-{s.Course}");

            }
            //get student by id
            Console.WriteLine("\nSearch Student with ID=1:");
            var student = repo.GetStudentById(1);
            if (student != null)
            {
                Console.WriteLine($"{student.StudentId}-{student.StudentName}-{student.Course}");
            }

            //delete student
            repo.DeleteStudent(2);
            Console.WriteLine("\nAfter Deleting Student with ID=2:");
            foreach (var s in repo.GetAllStudents())
            {
                Console.WriteLine($"{s.StudentId}-{s.StudentName}-{s.Course}");
            }
        }
    }
}
