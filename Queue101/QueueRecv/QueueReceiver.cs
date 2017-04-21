using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Threading;

namespace QueueRecv
{
    class QueueReceiver
    {

        private CloudQueueClient _queueClient;
        private CloudQueue _queue;

        public QueueReceiver(string connectionString, string queueName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            _queueClient = storageAccount.CreateCloudQueueClient();
            _queue = _queueClient.GetQueueReference(queueName);
            _queue.CreateIfNotExists();
        }

        public string GetMessage()
        {
            var msg = _queue.GetMessage();
            if (msg != null)
            {
                _queue.DeleteMessage(msg);
                return msg.AsString;
            }
            else
            {
                return null;
            }
        }
    }

}
