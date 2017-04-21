using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sb101Chat
{
    public class ChatEngine : IDisposable
    {
        private string _connString;
        private string _topicName;
        private string _userName;
        Action<string, string> _handler;
        private NamespaceManager _namespaceMgr;
        private TopicClient _topicClient;
        private string _subName;
        private SubscriptionClient _subClient;

        public ChatEngine(string connectionString, string topicName, 
            string userName, Action<string, string> handler)
        {
            _connString = connectionString;
            _topicName = topicName;
            _userName = userName;
            _handler = handler;
            CreateNameSpaceManager();
            CreateTopic();
            CreateTopicClient();
            CreateSubscription();
            CreateSubscriptionClient();
        }

        private void CreateNameSpaceManager()
        {
            _namespaceMgr = NamespaceManager.CreateFromConnectionString(_connString);
        }

        private void CreateTopic()
        {
            if (!_namespaceMgr.TopicExists(_topicName))
            {
                _namespaceMgr.CreateTopic(_topicName);
            }
        }

        private void CreateTopicClient()
        {
            _topicClient = TopicClient.CreateFromConnectionString(_connString, _topicName);
        }

        private void CreateSubscription()
        {
            _subName = Guid.NewGuid().ToString();
            var sub = new SubscriptionDescription(_topicName, _subName);
            sub.AutoDeleteOnIdle = TimeSpan.FromSeconds(1200);
            _namespaceMgr.CreateSubscription(sub);
        }

        private void CreateSubscriptionClient()
        {
            _subClient = SubscriptionClient.CreateFromConnectionString(_connString, _topicName, _subName);
            _subClient.OnMessage(msg => ProcessMessage(msg));
        }

        public void ProcessMessage(BrokeredMessage msg)
        {
            string msgText = msg.GetBody<string>();
            string senderName = msg.Label;
            if (msg.Label != _userName)
            {
                _handler(senderName, msgText);
            }
        }

        public void Send(string msgText)
        {
            var msg = new BrokeredMessage(msgText);
            msg.Label = _userName;
            _topicClient.Send(msg);
        }

        public void Dispose()
        {
            _topicClient.Close();
        }
    }
}
