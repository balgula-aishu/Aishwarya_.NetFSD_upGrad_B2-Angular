using System;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem6
{
    internal class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Email sent:"+message);
        }
    }
}
