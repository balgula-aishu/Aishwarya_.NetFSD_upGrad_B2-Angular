using System;
using System.IO;

namespace Dotnet_C__Demo.HandsOn_week5_day4
{
    internal class problem2
    {
        static void Main()
        {
            Console.WriteLine("Enter folder path");
            string folderPath=Console.ReadLine();
            try
            {
                //check if directory exists
                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid folder path!");
                    return;
                }
                //get all files in the directory
                string[] files = Directory.GetFiles(folderPath);
                int fileCount = 0;
                Console.WriteLine("\nFile Details:\n");
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine("File Name:" + fileInfo.Name);
                    Console.WriteLine("File Size:" + fileInfo.Length + "bytes");
                    Console.WriteLine("Created On:" + fileInfo.CreationTime);
                    Console.WriteLine("----------------------------");
                    fileCount++;

                }
                Console.WriteLine("\nTotal Files:" + fileCount);
            }
            catch (Exception ex) { 
            Console.WriteLine("Error:"+ex.Message);
            }
        }
    }
}
