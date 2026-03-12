using Dotnet_C__Demo.HandsOn_week4_day4;
using System;


namespace Dotnet_C__Demo.HandsOn_week4_day4
{
    class Calculator
    {
        public int Add(int a,int b) {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b; 
        }

        }
    }
    internal class problem1
    {
        static void Main()
        {
        Console.Write("Enter first number:");
        int num1=Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number:");
        int num2=Convert.ToInt32(Console.ReadLine());

        //creating object of calculator class
        Calculator calculator = new Calculator();

        int addition=calculator.Add(num1,num2);
        int subtraction=calculator.Subtract(num1,num2);

        Console.WriteLine("Addition:" + addition);
        Console.WriteLine("Subtraction:" + subtraction);
        }
    }

