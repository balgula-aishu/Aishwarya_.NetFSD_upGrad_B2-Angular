using System;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem2
{
    internal class DiscountCalculator
    {
        public double GetFinalPrice(double amount,IDiscountStrategy discountStrategy)
        {
            double discount=discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        } 
    }
}
