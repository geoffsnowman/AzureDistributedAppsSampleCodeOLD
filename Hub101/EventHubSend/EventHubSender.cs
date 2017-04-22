using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventHubSend
{
    class EventHubSender : IDisposable, IEventHubSender
    {
        private string _connString;
        private string _hubName;
        private EventHubClient _client;

        public EventHubSender(string connString, string hubName)
        {
            _connString = connString;
            _hubName = hubName;
            NamespaceManager mgr = NamespaceManager.CreateFromConnectionString(_connString);
            if (!mgr.EventHubExists(_hubName))
            {
                mgr.CreateEventHub(_hubName);
            }
            _client = EventHubClient.CreateFromConnectionString(_connString, _hubName);
        }

        public void Send(SomeEvent nextevent)
        {
            var json = JsonConvert.SerializeObject(nextevent);
            var eventmsg = new EventData(Encoding.UTF8.GetBytes(json));
            eventmsg.PartitionKey = nextevent.DeviceId.ToString();
            _client.Send(eventmsg);
        }

        public void Dispose()
        {
            _client.Close();
        }
    }
}
