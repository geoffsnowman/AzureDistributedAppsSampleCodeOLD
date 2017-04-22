using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedConstants
{
    public class Constants
    {
        public static string CONNECTION_STR = "Endpoint=sb://gseventtest1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=q+Bm+F/dsFR+F5TcWMRiJ/1yU/x/iu1T/3mUptHqJQE=";
        public static string HUB_NAME = "testhub1";
        public static string CONSUMER_GROUP = "$Default";
        public static string STORAGE_ACCOUNT = "DefaultEndpointsProtocol=https;AccountName=gsqueuetest1;AccountKey=OH8jrrVDsa9PWfktPyZ7EYOmWPFlGeg/FCgGsrunSYinAf0c2XoQU/g5LiZd1IZrQau2CBY8ZyK9nPXvSawC/g==;EndpointSuffix=core.windows.net";
    }
}
