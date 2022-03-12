using System;
using static System.Console;
using System.IO;

namespace WorkWithDirectories
{
    class Program
    {
        static void WorkWithDirectories()
        {
            /*define a directory path for a new folder
               starting in the user's folder*/
            var newFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            "Code", "Chapter09", "NewFolder");
            WriteLine($"Working with: {newFolder}");
            //Output will be ==> Working with: C:\Users\Basem\Documents\Code\Chapter09\NewFolder 
            // check if it exists
            WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
            // create directory
            WriteLine("Creating it...");
            Directory.CreateDirectory(newFolder);
            WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
            Write("Confirm the directory exists, and then press ENTER: ");
            ReadLine();
            // delete directory
            WriteLine("Deleting it...");
            Directory.Delete(newFolder, recursive: true);
            WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
        }
        static void Main(string[] args)
        {
            WorkWithDirectories();
        }
    }
}
