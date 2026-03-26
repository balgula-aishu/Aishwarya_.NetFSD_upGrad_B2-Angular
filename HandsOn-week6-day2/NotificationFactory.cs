using System;


namespace Dotnet_C__Demo.HandsOn_week6_day2.problem6
{
    internal class NotificationFactory 
    {
        public INotification CreateNotification(string type)
        {
            switch (type.ToLower())
            {
                case "email":
                    return new EmailNotification();

                case "sms":
                    return new SMSNotification();

                case "push":
                    return new PushNotification();

                default:
                    throw new Exception("Invalid notification type");
            }
        }
    }
}
