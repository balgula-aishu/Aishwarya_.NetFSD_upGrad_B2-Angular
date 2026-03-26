using System;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem2
{
    internal class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.10;  //10% discount
        }
    }
}
