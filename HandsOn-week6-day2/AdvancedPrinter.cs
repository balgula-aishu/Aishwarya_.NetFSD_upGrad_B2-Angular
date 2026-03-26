using System;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem4
{
    internal class AdvancedPrinter : IPrinter,IScanner,IFax
    {
        public void Print()
        {
            Console.WriteLine("Advanced Printer: Printing document...");
        }
        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning document...");
        }
        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Sending fax...");
        }
    }
}
