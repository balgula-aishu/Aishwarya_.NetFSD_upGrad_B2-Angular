using System;
using System.Collections.Generic;
using System.Linq;


namespace Dotnet_C__Demo.HandsOn_week5_day1
{
    internal class problem1
    {
        static void Main()
        {
            int[] marks = { 78, 85, 90, 67, 88 };
            int threshold = 80;
            AnalyzeScores(marks, threshold);

        }
        static void AnalyzeScores(int[] marks, int threshold)
        {
            //1.total marks using linq
            int totalMarks = marks.Sum();

            //2.average marks
            double averageMarks = (double)totalMarks / marks.Length;

            //3.highest score
            int highestScore = marks.Max();

            //4.student above threshold
            var abovethreshold = marks.Where(m => m > threshold).ToArray();
            int countAbovethreshold = abovethreshold.Length;

            //5.dictionary for subject-wise marks
            string[] subjects = { "Math", "Science", "English", "History", "Computer" };
            Dictionary<string, int> subjectMarks = new Dictionary<string, int>();

            for (int i = 0; i < marks.Length; i++)
            {
                subjectMarks[subjects[i]] = marks[i];

            }
            //6.display result
            Console.WriteLine("Total Marks:" + totalMarks);
            Console.WriteLine("Average Marks:" + averageMarks);
            Console.WriteLine("Students above:" + threshold + ":" + countAbovethreshold);
            Console.WriteLine("Highest Score:" + highestScore);

            Console.WriteLine("\nSubject-wise Marks:");
            foreach (var item in subjectMarks)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}
