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
            FileManager fileManager = new FileManager();

            fileManager.FileChanges("hello world23");
            
            
            /*   fileManager.FileDelete();
            fileManager.FileSave("hello world");
            string b = fileManager.FileRead();
            Console.WriteLine(b);*/
        }
    }
}
