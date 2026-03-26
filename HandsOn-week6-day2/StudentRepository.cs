using System;
using System.Collections.Generic;
using System.Linq;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem7
{
    internal class StudentRepository : IStudentRepository
    {
        private List<Student> students=new List<Student>();
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public List<Student> GetAllStudents()
        {
            return students; 
        }
        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.StudentId == id);
        }
        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                students.Remove(student);
            }
        }
    }
}
