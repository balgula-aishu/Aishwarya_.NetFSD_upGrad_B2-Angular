using System;
using System.Collections.Generic;
using System.Linq;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem7
{
    internal interface IStudentRepository
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void DeleteStudent(int id);
    }
}
