using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB101Rcv
{
    class MessageReceiver : IDisposable
    {
        private QueueClient _queueClient;

        public MessageReceiver(string connectionString, string queueName)
        {
            var mgr = NamespaceManager.CreateFromConnectionString(connectionString);
            QueueDescription qDesc;
            if (!mgr.QueueExists(queueName))
            {
                qDesc = mgr.CreateQueue(queueName);
            }
            _queueClient = QueueClient.CreateFromConnectionString(connectionString, queueName);
        }

        public void StartReceiving(Action<string> handler)
        {
            _queueClient.OnMessage(msg => ProcessMessage(msg, handler));
        }

        public void ProcessMessage(BrokeredMessage msg, Action<string> handler)
        {
            string msgText = msg.GetBody<string>();
            handler(msgText);
        }

        public void Dispose()
        {
            _queueClient.Close();
        }
    }
}
