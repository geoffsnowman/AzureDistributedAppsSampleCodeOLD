using SharedConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB101Rcv
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MessageReceiver rcvr = new MessageReceiver(Constants.CONNECTION_STR, Constants.QUEUE_NAME))
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
