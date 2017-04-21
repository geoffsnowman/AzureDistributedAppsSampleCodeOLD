
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Queue101Send
{
    public class QueueSender
    {
        private CloudQueueClient _queueClient;
        private CloudQueue _queue;

        public QueueSender(string connectionString, string queueName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            _queueClient = storageAccount.CreateCloudQueueClient();
            _queue = _queueClient.GetQueueReference(queueName);
            _queue.CreateIfNotExists();
        }

        public void Send(string msgText)
        {
            var msg = new CloudQueueMessage(msgText);
            _queue.AddMessage(msg);
        }
    }
}
