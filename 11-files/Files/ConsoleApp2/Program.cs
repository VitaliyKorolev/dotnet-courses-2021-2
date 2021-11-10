using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string SourcePath = @"C:/Users/user/Desktop/texts1";
            string DestinationPath = @"C:/Users/user/Desktop/temp1";
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            foreach (string newPath in Directory.GetFiles(SourcePath, "*.txt", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);

            foreach (string textFile in Directory.GetFiles(SourcePath, "*.txt", SearchOption.AllDirectories))
                File.Delete(textFile);

            foreach (string newPath in Directory.GetFiles(DestinationPath, "*.txt", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(DestinationPath, SourcePath), true);
        }
    }
}
