using System;
using System.IO;

namespace Dotnet_C__Demo.HandsOn_week5_day4
{
    internal class problem5
    {
        static void Main()
        {
            try
            {
                //get all drives
                DriveInfo[] drives = DriveInfo.GetDrives();
                Console.WriteLine("Drive Information:\n");

                foreach (DriveInfo drive in drives)
                {
                    //check if drive is ready
                    if (drive.IsReady)
                    {
                        long totalSize = drive.TotalSize;
                        long freeSpace = drive.AvailableFreeSpace;

                        //calculate free space percentage
                        double freePercent = (freeSpace * 100.0) / totalSize;

                        Console.WriteLine("Drive Name:" + drive.Name);
                        Console.WriteLine("Drive Type:" + drive.DriveType);
                        Console.WriteLine("Total Size:" + (totalSize / (1024 * 1024 * 1024)) + "GB");
                        Console.WriteLine("Free Space:" + (freeSpace / (1024 * 1024 * 1024)) + "GB");

                        //warning condition
                        if (freePercent < 15)
                        {
                            Console.WriteLine("⚠️Warning: Low Disk Space!");
                        }
                        Console.WriteLine("---------------------");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
    }
}
