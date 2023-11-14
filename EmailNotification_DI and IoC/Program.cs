using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailNotification_DI_and_IoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances of notification services
            var emailNotificationService = new EmailNotificationService();
            var smsNotificationService = new SmsNotificationService();
            var telephoneNotificationService = new TelephoneNotificationService();

            // Use dependency injection to create NotificationClient instances
            var emailNotificationClient = new NotificationClient(emailNotificationService);
            var smsNotificationClient = new NotificationClient(smsNotificationService);
            var telephoneNotificationClient = new NotificationClient(telephoneNotificationService);

            // Send notifications
            emailNotificationClient.NotifyUser("New email received");
            smsNotificationClient.NotifyUser("You have a new SMS");
            telephoneNotificationClient.NotifyUser("Telepthone is ringing");

            Console.ReadLine(); // Keep the console window open
        }
    }

    public interface INotificationService
    {
        void SendNotification(string message);
    }
    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Sending email notification: {message}");
        }
    }
    public class SmsNotificationService : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Sending SMS notification: {message}");
        }
    }
    public class TelephoneNotificationService : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Calling : {message}");
        }
    }
    public class NotificationClient
    {
        private readonly INotificationService _notificationService;

        public NotificationClient(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void NotifyUser(string message)
        {
            _notificationService.SendNotification(message);
        }
    }
}
