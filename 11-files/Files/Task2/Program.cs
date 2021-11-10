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
            Git g = new Git(@"C:/Users/user/Desktop/texts", $"C:/Users/user/Desktop/temp");
            
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
                CopyTextToTemp();


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

                    Console.WriteLine("Enter date in  \"dd.MM.yyyy HH mm ss\" format");
                    DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH mm ss", CultureInfo.InvariantCulture);

                    BackUp(dateTime);
                }


            }
            private void OnRenamed(object sender, RenamedEventArgs e)
            {
                Console.WriteLine($"Renamed: from {e.OldFullPath} to {e.FullPath}");
                CopyTextToTemp();
            }

            private void OnDeleted(object sender, FileSystemEventArgs e)
            {
                
                Console.WriteLine($"Deleted: {e.FullPath}");
                CopyTextToTemp();

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

                    CopyTextToTemp();

                    Console.WriteLine($"Changed: {e.FullPath}");

                }
                finally
                {
                    watcher.EnableRaisingEvents = true;
                }
                

            }

            private void CopyTextToTemp()    // копируем в папку с названием времени
            {
                DateTime time = DateTime.Now;
                string s = time.ToString("dd.MM.yyyy HH mm ss");
                string SourcePath = directoryToWatch;
                string DestinationPath = Path.Combine(tempDirectory, s);

                if (!Directory.Exists(DestinationPath))
                {
                    Directory.CreateDirectory(DestinationPath);
                }

                foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))  //создание дерева каталогов в папке temp/date
                    Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

                foreach (string newPath in Directory.GetFiles(SourcePath, "*.txt", SearchOption.AllDirectories))   //копирование текстовых файлов в папку temp/date
                    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
            }
            public void BackUp(DateTime backuptime)
            {
                DirectoryInfo dir = new DirectoryInfo(tempDirectory);
                var subdirs = dir.GetDirectories();

                DateTime[] dates = new DateTime[subdirs.Length];

                int i = 0;
                foreach (var d in subdirs)
                {
                    
                    dates[i] = DateTime.ParseExact(d.Name, "dd.MM.yyyy HH mm ss", CultureInfo.InvariantCulture);
                    i++;
                }
                DateTime[] selectedTimes = dates.Where(t => t <= backuptime).ToArray();

                if(selectedTimes.Length == 0)
                {
                    throw new Exception("Резеврных копий с такой датой нет");
                }

                DateTime backup = selectedTimes[selectedTimes.Length - 1];
                string backupdate = backup.ToString("dd.MM.yyyy HH mm ss");

                Console.WriteLine($"Date of backup {backupdate}");

                string fromDirectory = Path.Combine(tempDirectory, backupdate);
                string toDirectory = directoryToWatch;

                foreach (string textFile in Directory.GetFiles(directoryToWatch, "*.txt", SearchOption.AllDirectories)) // удаление текстовых файлов в папке наблюдения
                    File.Delete(textFile);

                foreach (string newPath in Directory.GetFiles(fromDirectory, "*.txt", SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(fromDirectory, toDirectory), true);
            }
        }
    }
}
