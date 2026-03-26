using System;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem3
{
    internal class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width; 
        }
        public override double CalculateArea()
        {
            return Length * Width;
        }
    }
}
