using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger Logger = new Logger();
            Logger.Error();
            Logger.Alert();
            Logger.Debug();
            Logger.Info();
        }
    }
}
