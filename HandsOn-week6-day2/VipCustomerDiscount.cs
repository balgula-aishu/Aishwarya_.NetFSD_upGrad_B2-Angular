using System;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem2
{
    internal class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20;  //20% discount
        }
    }
}
