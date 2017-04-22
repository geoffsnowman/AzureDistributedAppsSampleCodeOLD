using SharedConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHubSend
{
    class Program
    {
        private static int SEND_COUNT = 1000;

        static void Main(string[] args)
        {
            // 1. Use unbatched events
            using (var unbatched = new EventHubSender(Constants.CONNECTION_STR, 
                Constants.HUB_NAME))
            {
                SendItems(unbatched);
            }

            // 2. Use batched events
            using (var batched = new BatchedEventHubSender(Constants.CONNECTION_STR,
                Constants.HUB_NAME))
            {
                SendItems(batched);
            }
            Console.WriteLine("Carriage Return to Exit");
            Console.ReadLine();
        }

        private static void SendItems(IEventHubSender sender)
        {
            Console.WriteLine("sending {0} items...", SEND_COUNT);
            DateTime start = DateTime.Now;
            for (int i = 0; i < SEND_COUNT; i++)
            {
                if (i%50 == 0)
                {
                    Console.WriteLine(i);
                }
                SomeEvent nextevent = SomeEvent.CreateEvent();
                sender.Send(nextevent);
            }
            DateTime end = DateTime.Now;
            Console.WriteLine("Duration: {0}", end - start);
        }
    }
}
