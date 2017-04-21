using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB101Rcv
{
    class Program
    {
        private const string CONNECTION_STR = "Endpoint=sb://gssbtest1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gXoKasqpjOtrVwel+4FKrG/N2BJ2JTHufqIeUHszv4Q=";
        private const string QUEUE_NAME = "mytestqueue";
        static void Main(string[] args)
        {
            using (MessageReceiver rcvr = new MessageReceiver(CONNECTION_STR, QUEUE_NAME))
            {
                Console.WriteLine("Carriage return to exit.");
                rcvr.StartReceiving(PrintMessage);
                Console.ReadLine();
            }
        }

        static void PrintMessage(string msgText)
        {
            Console.WriteLine(msgText);
        }
    }
}
