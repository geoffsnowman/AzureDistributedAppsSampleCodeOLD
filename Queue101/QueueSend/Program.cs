using SharedConstants;
using System;

namespace Queue101Send
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a line of text to send a message");
            Console.WriteLine("Carriage return to exit");
            QueueSender sndr = new QueueSender(Constants.CONNECTION_STR, Constants.QUEUE_NAME);
            string msgText = Console.ReadLine();
            while (!string.IsNullOrEmpty(msgText))
            {
                sndr.Send(msgText);
                msgText = Console.ReadLine();
            }
        }
    }
}
