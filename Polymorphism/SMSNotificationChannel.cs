namespace Polymorphism
{
    public class SMSNotificationChannel : INotificationChannel
    {
        public void Send(Message message)
        {
            System.Console.WriteLine("Sending SMS...");
        }
    }
}