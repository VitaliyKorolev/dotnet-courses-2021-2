using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime backuptime = new DateTime(2021, 10, 29, 15, 22, 00);
            string tempDirectory = $"C:/Users/user/Desktop/temp/";

            DirectoryInfo dir = new DirectoryInfo(tempDirectory);
            var subdirs = dir.GetDirectories();
            DateTime[] dates = new DateTime[subdirs.Length];
            int i = 0;
            foreach(var d in subdirs)
            {
                Console.WriteLine(d.Name);
                dates[i] = DateTime.ParseExact(d.Name, " dd.MM.yyyy HH mm s", CultureInfo.InvariantCulture);
                i++;
            }
            DateTime[] selectedTimes = dates.Where(t => t <= backuptime).ToArray();
            
            DateTime backup = selectedTimes [selectedTimes.Length-1];
            string backupdate = backup.ToString(" dd.MM.yyyy HH mm s");

        }
    }
}
