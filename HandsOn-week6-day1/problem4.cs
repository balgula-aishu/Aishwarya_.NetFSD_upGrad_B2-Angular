using System;
using System.Threading.Tasks;

namespace Dotnet_C__Demo.HandsOn_week6_day1
{
    internal class problem4
    {
        static async Task Main()
        {
            Console.WriteLine("Order processing started...\n");
            await processOrderAsync();
            Console.WriteLine("\nOrder Processing Completed!");
        }
        //main workflow method
        static async Task processOrderAsync()
        {
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOderAsync();
        }
        //step 1:payment verification
        static async  Task VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying payment...");
            await Task.Delay(2000);
            Console.WriteLine("Payment verified.\n");
        }
        //step 2: Inventory check
        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Checking Inventory...");
            await Task.Delay(2000);
        Console.WriteLine("Inventory Available.\n");
        }
    //step 3:Order confirmation
    static async Task ConfirmOderAsync()

    {
            Console.WriteLine("Confirming Order...");
            await Task.Delay(2000);
            Console.WriteLine("Order Confirmed.\n");
        }

}
}
