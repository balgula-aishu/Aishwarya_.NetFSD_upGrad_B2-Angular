using System;


namespace Dotnet_C__Demo.HandsOn_week4_day4
{
    class PowerCalculator
    {
        //recursive method to calculate power
        public int CalculatorPower(int baseNum, int exponent)
        {
            //base case
            if (exponent == 0)
            {
                return 1;
            }
            //recursive call
            return baseNum * CalculatorPower(baseNum, exponent - 1);
        }

    }
    internal class problem5
    {
        static void Main()
        {
            Console.Write("Enter base number:");
            int baseNum=Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter exponent:");
            int exponent = Convert.ToInt32(Console.ReadLine());
             PowerCalculator powerCalculator = new PowerCalculator();

            int result=powerCalculator.CalculatorPower(baseNum,exponent);

            Console.WriteLine("Base:" + baseNum);
            Console.WriteLine("Exponent:"+exponent);
            Console.WriteLine("Result:"+ result);
           
        }
    }
}
