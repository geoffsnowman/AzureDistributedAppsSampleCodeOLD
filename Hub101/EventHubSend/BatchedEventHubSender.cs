using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharedConstants;


namespace EventHubSend
{
    class BatchedEventHubSender : IDisposable, IEventHubSender
    {
        private string _connString;
        private string _hubName;
        private EventHubClient _client;
        private List<EventData> _events;

        public BatchedEventHubSender(string connString, string hubName)
        {
            _connString = connString;
            _hubName = hubName;
            NamespaceManager mgr = NamespaceManager.CreateFromConnectionString(_connString);
            if (!mgr.EventHubExists(_hubName))
            {
                mgr.CreateEventHub(_hubName);
            }
            _client = EventHubClient.CreateFromConnectionString(_connString, _hubName);
            _events = new List<EventData>();
        }

        public void Send(SomeEvent nextevent)
        {
            var json = JsonConvert.SerializeObject(nextevent);
            var eventmsg = new EventData(Encoding.UTF8.GetBytes(json));
            //Can't specify partition key
            //eventmsg.PartitionKey = nextevent.DeviceId.ToString();
            _events.Add(eventmsg);
            if (_events.Count > 8)
            {
                _client.SendBatch(_events);
                _events.Clear();
            }
        }

        public void Dispose()
        {
            _client.Close();
        }
    }
}
