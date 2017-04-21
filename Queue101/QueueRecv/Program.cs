using SharedConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueRecv
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueReceiver rcvr = new QueueReceiver(Constants.CONNECTION_STR, Constants.QUEUE_NAME);
            Console.WriteLine("Carriage return to exit");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    char ch = Console.ReadKey().KeyChar;
                    if (ch == '\r')
                    {
                        break;
                    }
                }
                string msgText = rcvr.GetMessage();
                if (!string.IsNullOrEmpty(msgText))
                {
                    Console.WriteLine(msgText);
                }
            }
        }
    }
}
