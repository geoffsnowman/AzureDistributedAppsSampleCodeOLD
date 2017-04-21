using SharedConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sb101Send
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a line of text to send a message");
            Console.WriteLine("Carriage return to exit");
            using (MessageSender sndr = new MessageSender(Constants.CONNECTION_STR, 
                Constants.QUEUE_NAME))
                {
                string msgText = Console.ReadLine();
                while (!string.IsNullOrEmpty(msgText))
                {
                    sndr.Send(msgText);
                    msgText = Console.ReadLine();
                }
            }
        }
    }
}
