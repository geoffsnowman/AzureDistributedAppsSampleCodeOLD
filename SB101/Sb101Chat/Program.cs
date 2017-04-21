using SharedConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sb101Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            using (ChatEngine chat = new ChatEngine(Constants.CONNECTION_STR, Constants.TOPIC_NAME, 
                userName, DisplayMessage))
            {
                chat.Send(string.Format("(entered chat)", userName));
                Console.WriteLine("Enter a message");
                Console.WriteLine("Carriage return to exit.");
                string msgText = Console.ReadLine();
                while (!string.IsNullOrEmpty(msgText))
                {
                    chat.Send(msgText);
                    msgText = Console.ReadLine();
                }
            }
        }

        static void DisplayMessage(string name, string text)
        {
            Console.WriteLine("{0}: {1}", name, text);
        }
    }
}
