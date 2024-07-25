using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Logger
{
    public delegate void LoggingOperation(string message);
    public  class Logger
    {
        public void Info(string message)
        {
            Console.WriteLine("[INFO] " + message);
        }

        public void Warning(string message)
        {
            Console.WriteLine("[WARNING] " + message);
        }

        public void Error(string message)
        {
            Console.WriteLine("[ERROR] " + message);
        }
    }
}
