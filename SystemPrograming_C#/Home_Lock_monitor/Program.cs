using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor_Lock
{
    internal class Program
    {
        class FileReaderThread
        {
            public int count_Words;
            public int count_Row;
            public int count_PunctMark;
            public int cheack_count;
            public FileReaderThread()
            {
                count_Words = 0;
                count_Row = 0;
                count_PunctMark = 0;
                cheack_count = 0;
            }
            public void Work(object text)
            {
                string res = text.ToString();
                lock (this)
                {
                    Console.WriteLine(res);
                    string[] lines = res.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    count_Row += lines.Length;

                    char[] Punct_Marks = { ',', '.', '\'', '?', '!' };

                    count_PunctMark += CountDelimiters(res, Punct_Marks);

                    string[] words = res.Split(new[] { '\n', '\r', ',', '.', '\'', '?', '!', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    count_Words += words.Length;
                }
            }
            public void C()
            {
                lock (this)
                {
                    for (global::System.Int32 i = 0; i < 1000000; i++)
                    {
                        cheack_count++;
                    }
                }
            }
        }
        static int CountDelimiters(string text, char[] delimiters)
        {
            int count = 0;
            foreach (char delimiter in delimiters)
            {
                count += text.Split(delimiter).Length - 1;
            }
            return count;
        }
        static string getText(string strings)
        {
            string str = String.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(strings))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        str += line + '\n';
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error read file: " + e.Message);
            }
            return str;
        }
        static void Main(string[] args)
        {
            //FileReaderThread fileReader = new FileReaderThread();
            FileReaderThread fileRes = new FileReaderThread();
            string folder_path = "D:\\C#\\SystemPrograming_C#\\Process_01\\Monitor_Lock\\Folder_txt";

            if (Directory.Exists(folder_path))
            {
                string[] txt_files = Directory.GetFiles(folder_path);
                string[] texts = new string[txt_files.Length];
                for (global::System.Int32 i = 0; i < txt_files.Length; i++)
                {
                    texts[i] = getText(txt_files[i]);
                }
                Thread[] threads = new Thread[txt_files.Length];

                for (global::System.Int32 i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(fileRes.Work);
                    threads[i].Start(texts[i]);
                }
                for (global::System.Int32 i = 0; i < threads.Length; i++)
                {
                    threads[i].Join();
                }
            }
            Console.WriteLine($"Total Words {fileRes.count_Words} Total lines {fileRes.count_Row} Total Marks {fileRes.count_PunctMark}");
            //Thread[] thread = new Thread[10];
            //for (int i = 0; i < 2; i++)
            //{
            //    thread[i] = new Thread(fileReader.C);
            //    thread[i].Start();
            //}
            //for (int i = 0; i < 2; i++)
            //{
            //    thread[i].Join();
            //}
            //Console.WriteLine(fileReader.cheack_count);
        }
    }
}
