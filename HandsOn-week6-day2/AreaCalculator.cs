using System;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem3
{
    internal class AreaCalculator
    {
        public void PrintArea(Shape shape)
        {
            Console.WriteLine("Area:" + shape.CalculateArea());
        }
    }
}
