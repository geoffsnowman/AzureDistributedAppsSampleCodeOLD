using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedConstants
{
    public class Constants
    {
        public static string CONNECTION_STR = "Endpoint=sb://gstest3.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=j5t7c6HNtJskm9ehXmbtRWQvq6P+g4+SUzppZTiUzyQ=";
        public static string QUEUE_NAME = "mytestqueue";
        public static string TOPIC_NAME = "mytesttopic";
    }
}
