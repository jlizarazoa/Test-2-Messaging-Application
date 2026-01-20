using ModularisTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Interfaces
{
    public interface ILogDestination
    {
        void Log(string message, MessageType type); 
    }
}
