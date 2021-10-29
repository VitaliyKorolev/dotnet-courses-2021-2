using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Git g = new Git(@"C:/Users/user/Desktop/texts", $"C:/Users/user/Desktop/temp/");
            DateTime backuptime = new DateTime(2021, 10, 29, 15, 22, 00);
            g.Run();

        }

        public class Git
        {
            public FileSystemWatcher watcher;
            private string directoryToWatch;
            private string tempDirectory;

            public Git(string directoryToWatch, string tempDirectory)
            {
                watcher = new FileSystemWatcher(directoryToWatch);
                this.directoryToWatch = directoryToWatch;
                this.tempDirectory = tempDirectory;

            }
            public  void Run()
            {
                CopyToTemp();


                watcher.NotifyFilter = NotifyFilters.DirectoryName
                                     | NotifyFilters.FileName
                                     | NotifyFilters.LastWrite;


                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnDeleted);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);


                watcher.Filter = "*.txt";
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press \'Enter\' to quit the sample.");
                Console.WriteLine("Press \'1\' to go to the backupmode.");
                if (Console.ReadLine() == "1")
                {
                    watcher.EnableRaisingEvents = false;      // выключаем наблюдение

                    Console.WriteLine("Enter date in  dd.MM.yyyy HH mm s format");
                    DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH mm s", CultureInfo.InvariantCulture);

                    BackUp(dateTime);
                }


            }
            private void OnRenamed(object sender, RenamedEventArgs e)
            {
                Console.WriteLine($"Renamed: from {e.OldFullPath} to {e.FullPath}");
                CopyToTemp();
            }

            private void OnDeleted(object sender, FileSystemEventArgs e)
            {
                
                Console.WriteLine($"Deleted: {e.FullPath}");
                CopyToTemp();

            }

            private  void OnChanged(object sender, FileSystemEventArgs e)
            {

                watcher.EnableRaisingEvents = false;

                try
                {
                   

                    if (e.ChangeType != WatcherChangeTypes.Changed)
                    {
                        return;
                    }

                    CopyToTemp();

                    Console.WriteLine($"Changed: {e.FullPath}");

                }
                finally
                {
                    watcher.EnableRaisingEvents = true;
                }
                

            }

            private void CopyToTemp()    // копируем в папку с названием времени
            {
                DateTime time = DateTime.Now;
                string s = $" { time.ToShortDateString() } { time.Hour} {time.Minute} {time.Second}";  
                string fromDirectory = directoryToWatch;
                string toDirectory = tempDirectory + s;
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(fromDirectory, toDirectory);
            }
            public void BackUp(DateTime backuptime)
            {
                DirectoryInfo dir = new DirectoryInfo(tempDirectory);
                var subdirs = dir.GetDirectories();

                DateTime[] dates = new DateTime[subdirs.Length];

                int i = 0;
                foreach (var d in subdirs)
                {
                    Console.WriteLine(d.Name);
                    dates[i] = DateTime.ParseExact(d.Name, " dd.MM.yyyy HH mm s", CultureInfo.InvariantCulture);
                    i++;
                }
                DateTime[] selectedTimes = dates.Where(t => t <= backuptime).ToArray();

                if(selectedTimes.Length == 0)
                {
                    throw new Exception("Резеврных копий с такой датой нет");
                }

                DateTime backup = selectedTimes[selectedTimes.Length - 1];
                string backupdate = backup.ToString(" dd.MM.yyyy HH mm s");

                string fromDirectory = tempDirectory + backupdate;
                string toDirectory = directoryToWatch;

                Directory.Delete(toDirectory, true);
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(fromDirectory, toDirectory);
            }
        }
    }
}
