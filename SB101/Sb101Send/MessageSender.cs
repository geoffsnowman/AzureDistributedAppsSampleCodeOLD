using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sb101Send
{
    public class MessageSender : IDisposable
    {
        private QueueClient _queueClient;

        public MessageSender(string connectionString, string queueName)
        {
            var mgr = NamespaceManager.CreateFromConnectionString(connectionString);
            if (!mgr.QueueExists(queueName))
            {
                mgr.CreateQueue(queueName);
            }
            _queueClient = QueueClient.CreateFromConnectionString(connectionString, queueName);
        }

        public void Send(string msgText)
        {
            var msg = new BrokeredMessage(msgText);
            _queueClient.Send(msg);
        }

        public void Dispose()
        {
            _queueClient.Close();
        }
    }
}
