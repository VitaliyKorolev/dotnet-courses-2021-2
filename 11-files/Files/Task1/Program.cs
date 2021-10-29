using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C://Users//user//Desktop//dotnet-courses-2021-2//11-files//Files//Task1//disposable_task_file.txt";

            ProcessFile(path);
        }
        public static void ProcessFile(string path)
        {

            string[] lines = File.ReadAllLines(path);
            using (StreamWriter writer = new StreamWriter(path))
            {
                int n;
                foreach (string line in lines)
                {
                    string[] result = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in result)
                    {
                        if (int.TryParse(word, out n))
                            writer.Write($"{n * n} ");
                        else writer.Write($"{word} ");
                    }

                    writer.WriteLine();
                }
            }
        }
    }
}
