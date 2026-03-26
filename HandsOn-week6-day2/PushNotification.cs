using System;

namespace Dotnet_C__Demo.HandsOn_week6_day2.problem6
{
    internal class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Push Notification sent:"+message);
        }
    }
}
