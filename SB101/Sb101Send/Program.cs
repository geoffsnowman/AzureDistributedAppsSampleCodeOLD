using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sb101Send
{
    class Program
    {
        private const string CONNECTION_STR = "Endpoint=sb://gssbtest1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gXoKasqpjOtrVwel+4FKrG/N2BJ2JTHufqIeUHszv4Q=";
        private const string QUEUE_NAME = "mytestqueue";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a line of text to send a message");
            Console.WriteLine("Carriage return to exit");
            using (MessageSender sndr = new MessageSender(CONNECTION_STR, QUEUE_NAME))
                {
                string msgText = Console.ReadLine();
                while (!string.IsNullOrEmpty(msgText))
                {
                    sndr.Send(msgText);
                    msgText = Console.ReadLine();
                }
            }
        }
    }
}
