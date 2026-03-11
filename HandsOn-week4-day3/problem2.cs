using System;


namespace Dotnet_C__Demo.HandsOn_week4_day3
{
    internal class problem2
    {
        static void Main()
        {
            Console.Write("Enter first Number:");
            double num1=Convert.ToDouble (Console.ReadLine());

            Console.Write("Enter second Number:");
            double num2=Convert.ToDouble (Console.ReadLine());

            Console.Write("Enter Operator(+,-,*,/):");
            char op=Convert.ToChar (Console.ReadLine());

            double result = 0;
            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    Console.WriteLine("Result:" + result);
                        break;
                case '-':
                    result = num1 - num2;
                    Console.WriteLine("Result:" + result);
                    break;
                case '*':
                    result = num1 * num2;
                    Console.WriteLine("Result:" + result);
                    break;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error:Division by zero is not allowed");
                            
                    }
                    else
                    {
                        result = num1 / num2;
                        Console.WriteLine("Result:" + result);
                    }
                    break;
                default: Console.WriteLine("Invalid operator entered");
                    break;

            }

        }
    }
}
