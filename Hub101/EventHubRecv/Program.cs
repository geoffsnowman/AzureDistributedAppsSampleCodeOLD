using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using SharedConstants;

namespace EventHubRecv
{
    class Program
    {
        private static EventProcessorHost _host;

        static void Main(string[] args)
        {
            StartListening();
            Console.WriteLine("Two Carriage Returns to Exit.");
            Console.ReadLine();
            StopListening();
            Console.ReadLine();
        }

        async static void StartListening()
        {
            _host = new EventProcessorHost(Constants.HUB_NAME, Constants.CONSUMER_GROUP,
                Constants.CONNECTION_STR, Constants.STORAGE_ACCOUNT);
            await _host.RegisterEventProcessorAsync<EventProcessor>();
        }

        async static void StopListening()
        {
            await _host.UnregisterEventProcessorAsync();
            _host.ResetAllConnections();
        }

    }
}
