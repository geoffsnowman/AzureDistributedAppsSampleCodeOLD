using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedConstants
{
    [Serializable()]
    public class SomeEvent
    {
        public const int PAYLOAD_LENGTH = 500;

        public Byte[] Payload { get; set; }
        public DateTime SendTime { get; set; }
        public int DeviceId { get; set; }

        public static SomeEvent CreateEvent()
        {
            var random = new Random();
            var newevent = new SomeEvent
            {
                SendTime = DateTime.UtcNow,
                DeviceId = random.Next(100),
                Payload = new Byte[PAYLOAD_LENGTH]
            };
            random.NextBytes(newevent.Payload);
            return newevent;
        }
    }
}
