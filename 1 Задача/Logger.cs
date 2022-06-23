using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Logger
    {
        /// <summary>
        /// Класс Error, выводит текст local.ERROR: Error Messate
        /// </summary>
        public void Error()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string text ="["+ dateTime +"]"+ "  local.ERROR: Error Messate\n";
            using (FileStream stream = new FileStream("D:\\error.txt", FileMode.Append))
            {
                byte[] textArray = System.Text.Encoding.Default.GetBytes(text);
                stream.Write(textArray, 0, textArray.Length);
            }
        }
        /// <summary>
        /// Класс Debug, выводит текст local.DEBUG: Debug Messate
        /// </summary>
        public void Debug()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string text = "[" + dateTime + "]" + "  local.DEBUG: Debug Messate\n";
            using (FileStream stream = new FileStream("D:\\debug.txt", FileMode.Append))
            {
                byte[] textArray = System.Text.Encoding.Default.GetBytes(text);
                stream.Write(textArray, 0, textArray.Length);
            }
        }
        /// <summary>
        /// Класс Info, выводит текст local.INFO: Info Messate
        /// </summary>
        public void Info()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string text = "[" + dateTime + "]" + "  local.INFO: Info Messate\n";
            using (FileStream stream = new FileStream("D:\\info.txt", FileMode.Append))
            {
                byte[] textArray = System.Text.Encoding.Default.GetBytes(text);
                stream.Write(textArray, 0, textArray.Length);
            }
        }
        /// <summary>
        /// Класс Alert, выводит текст local.ALERT: Alert Messate
        /// </summary>
        public void Alert()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string text = "[" + dateTime + "]" + "  local.ALERT: Alert Messate\n";
            using (FileStream stream = new FileStream("D:\\alert.txt", FileMode.Append))
            {
                byte[] textArray = System.Text.Encoding.Default.GetBytes(text);
                stream.Write(textArray, 0, textArray.Length);
            }
        }

    }
}
