using System;


namespace Dotnet_C__Demo.HandsOn_week4_day4
{
    class OrderCalculator
    {
        public void CalculateFinalAmount(double price,int quantity,double discountPercent=0,double shippingCharge = 50)
        {
            double subtotal = price * quantity;
            double discountAmount = subtotal * discountPercent / 100;
            double amountAfterDiscount = subtotal - discountAmount;
            double finalAmount = amountAfterDiscount + shippingCharge;

            Console.WriteLine("Subtotal:"+subtotal);
            Console.WriteLine("Discount Applied:"+discountAmount);
            Console.WriteLine("Shipping Charge:" + shippingCharge);
            Console.WriteLine("Final Amount:" + finalAmount);
        }
    }
    internal class problem4
    {
        static void Main()
        {
            OrderCalculator order=new OrderCalculator();
            Console.Write("Enter Product Price:");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n---without discount(default shipping)---");
            order.CalculateFinalAmount(price, quantity);

            Console.WriteLine("\n---with discount only---");
            order.CalculateFinalAmount(price, quantity, 10);

            Console.WriteLine("\n---with discount and custom shipping---");
            order.CalculateFinalAmount(price, quantity, 10, 100);

        }
    }
}
