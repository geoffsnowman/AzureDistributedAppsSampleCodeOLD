using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sb101Chat
{
    class Program
    {
        private const string CONNECTION_STR = "Endpoint=sb://gssbtest1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gXoKasqpjOtrVwel+4FKrG/N2BJ2JTHufqIeUHszv4Q=";
        private const string TOPIC_NAME = "mytesttopic";
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            using (ChatEngine chat = new ChatEngine(CONNECTION_STR, TOPIC_NAME, userName, DisplayMessage))
            {
                chat.Send(string.Format("(entered chat)", userName));
                Console.WriteLine("Enter a message");
                Console.WriteLine("Carriage return to exit.");
                string msgText = Console.ReadLine();
                while (!string.IsNullOrEmpty(msgText))
                {
                    chat.Send(msgText);
                    msgText = Console.ReadLine();
                }
            }
        }

        static void DisplayMessage(string name, string text)
        {
            Console.WriteLine("{0}: {1}", name, text);
        }
    }
}
