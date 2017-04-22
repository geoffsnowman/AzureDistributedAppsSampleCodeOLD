using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharedConstants;

namespace EventHubRecv
{
    public class EventProcessor : IEventProcessor
    {
        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Console.WriteLine("Close Async");
            return Task.FromResult<object>(null);
        }

        public Task OpenAsync(PartitionContext context)
        {
            Console.WriteLine("Open Async");
            return Task.FromResult<object>(null);
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            int messageCount = 0;
            foreach (EventData msg in messages)
            {
                messageCount++;
                var json = Encoding.UTF8.GetString(msg.GetBytes());
                var nextevent = JsonConvert.DeserializeObject<SomeEvent>(json);
                ProcessSomehow(nextevent);
                if (messageCount > 100)
                {
                    context.CheckpointAsync();
                    Console.WriteLine("{0}: Partition {1} Processed {2} Messages", 
                        DateTime.Now,
			context.Lease.PartitionId,
			messages.Count<EventData>());
                    messageCount = 0;
                }
            }
            context.CheckpointAsync();
            Console.WriteLine("{0}: Partition {1} Processed {2} Messages", 
                DateTime.Now,
		context.Lease.PartitionId,
		messages.Count<EventData>());
            return Task.FromResult<object>(null);
        }

        private void ProcessSomehow(SomeEvent theevent)
        {
            ;
        }
    }
}
