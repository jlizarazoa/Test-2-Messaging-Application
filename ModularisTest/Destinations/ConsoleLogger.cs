using ModularisTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Models
{
    public class ConsoleLogger: ILogDestination
    {
        private ConsoleColor Color;
        public ConsoleLogger() { }
        public void Log(string message, MessageType type)
        {
            switch (type)
            {
                case MessageType.Message:
                    Color = ConsoleColor.White;
                    break;
                case MessageType.Warning:
                    Color = ConsoleColor.Yellow;
                    break;
                case MessageType.Error:
                    Color = ConsoleColor.Red;
                    break;
                default:
                    Color = ConsoleColor.White;
                    break;
            }

            Console.ForegroundColor = Color;
            Console.WriteLine(DateTime.Now.ToShortDateString() + " " + message);
            Console.ResetColor();
        }
    }
}
