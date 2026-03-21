using System;

namespace Dotnet_C__Demo.HandsOn_week5_day2
{
    public record Student(int RollNo, string Name, string Course, int Marks);
    internal class problem1
    {
        static void Main()
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            Student[] students = new Student[n];

            // Input student details
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter details for Student {i + 1}:");

                int rollNo = ReadValidInt("Enter Roll Number: ");
                string name = ReadNonEmpty("Enter Name: ");
                string course = ReadNonEmpty("Enter Course: ");
                int marks = ReadValidMarks("Enter Marks (0-100): ");

                students[i] = new Student(rollNo, name, course, marks);
            }

            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Display All Students");
                Console.WriteLine("2. Search by Roll Number");
                Console.WriteLine("3. Exit");
                Console.Write("Choose option: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayStudents(students);
                        break;

                    case 2:
                        Console.Write("Enter Roll Number to search: ");
                        int searchRoll = int.Parse(Console.ReadLine());
                        SearchStudent(students, searchRoll);
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // Display all students
        static void DisplayStudents(Student[] students)
        {
            Console.WriteLine("\nStudent Records:");
            foreach (var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }
        }

        // Search student
        static void SearchStudent(Student[] students, int rollNo)
        {
            foreach (var s in students)
            {
                if (s.RollNo == rollNo)
                {
                    Console.WriteLine("\nStudent Found:");
                    Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                    return;
                }
            }

            Console.WriteLine("Student not found.");
        }

        // Input validation methods
        static int ReadValidInt(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                    return value;

                Console.WriteLine("Invalid input. Enter a positive number.");
            }
        }

        static int ReadValidMarks(string message)
        {
            int marks;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                    return marks;

                Console.WriteLine("Invalid marks. Enter value between 0 and 100.");
            }
        }

        static string ReadNonEmpty(string message)
        {
            string input;
            while (true)
            {
                Console.Write(message);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Input cannot be empty.");
            }
        }
    }
}
