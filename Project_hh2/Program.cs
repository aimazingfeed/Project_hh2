using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace HelloApp
{
    class Program
    {


        static void Main(string[] args)
        {




            string readPath = @"L:\Загрузки\hdd.txt";
            string writePath = @".\output.txt";
            var list = new List<string>();
            using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.UTF8))
            {
                char[] marks = { ' ', ',', '!', '?', '\n', '.', ';', ':', ')', '(', '"', '#', '*', '—', '\0', '\"', '–', '»', '«', '…', '•' };
                while (!sr.EndOfStream)
                {

                    var word = sr.ReadLine().ToLower();
                    string[] words = word.Split(marks);
                    foreach (string element in words)
                    {
                        if (!string.IsNullOrEmpty(element) && !string.IsNullOrWhiteSpace(element))
                            list.Add(element);
                    }
                }

            }

            var reList = list.GroupBy(word => word).OrderByDescending(elem => elem.Count()).Select(elem => elem.Key+" "+elem.Count());

            StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.UTF8);

            foreach (var i in reList)
            {
                sw.WriteLine(i);
            }
        }
    }
}