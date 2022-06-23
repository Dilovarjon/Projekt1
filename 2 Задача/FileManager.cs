using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FileManager
    {
        /// <summary>
        /// Метод для сохранения там данных в текстовом формате string
        /// </summary>
        /// <param name="text"></param>
        public void FileSave(string text)
        {
            text = text + "\n";
            using (FileStream stream = new FileStream("D:\\text.txt", FileMode.Append))
            {
                byte[] textArray = System.Text.Encoding.Default.GetBytes(text);
                stream.Write(textArray, 0, textArray.Length);
            }
        }
        /// <summary>
        /// Метод для чтения файла
        /// </summary>
        public string FileRead()
        {
            using(FileStream stream = File.OpenRead("D:\\text.txt"))
            {
                byte[] textArray = new byte[stream.Length];
                stream.Read(textArray, 0,textArray.Length);

                string textFromFile = Encoding.Default.GetString(textArray);
                return textFromFile;
            }
        }
        /// <summary>
        /// Метод для изменения файлов, очистки и записания новых данных
        /// </summary>
        public void FileChanges(string text)
        {
            using (FileStream stream = new FileStream("D:\\text.txt", FileMode.OpenOrCreate))
            {
                text = text + "\n";
                    byte[] textArray = System.Text.Encoding.Default.GetBytes(text);
                    stream.Write(textArray, 0, textArray.Length);
            }
        }
        /// <summary>
        /// Метод для очистки файла
        /// </summary>
        public void FileDelete()
        {
            using (FileStream stream = new FileStream("D:\\text.txt", FileMode.Create))
            {

            }     
        }
    }
}
