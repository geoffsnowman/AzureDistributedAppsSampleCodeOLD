using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedConstants
{
    public class Constants
    {
        public static string CONNECTION_STR = "Endpoint=sb://gssbtest1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gXoKasqpjOtrVwel+4FKrG/N2BJ2JTHufqIeUHszv4Q=";
        public static string QUEUE_NAME = "mytestqueue";
        public static string TOPIC_NAME = "mytesttopic";
    }
}
