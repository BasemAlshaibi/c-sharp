using System;
using static System.Console;
using System.IO;

namespace WorkWithFiles
{
    class Program
    {
        static void WorkWithFiles()
        {
            // define a directory path to output files
            // starting in the user's folder
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Code", "Chapter09", "OutputFiles");
            Directory.CreateDirectory(dir);
            //C:\Users\Basem\Documents\Code\Chapter09\OutputFiles
            // define file paths
            string textFile = Path.Combine(dir, "Dummy.txt");
            string backupFile = Path.Combine(dir, "Dummy.bak");
            WriteLine($"Working with: {textFile}");
            //C:\Users\Basem\Documents\Code\Chapter09\OutputFiles\Dummy.txt
            // check if a file exists
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            //False
            // create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#!");
            textWriter.Close(); // close file and release resources
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            // copy the file, and overwrite if it already exists
            File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);
            WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
            Write("Confirm the files exist, and then press ENTER: ");
            ReadLine();
            // delete file
            File.Delete(textFile);
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            // read from the text file backup
            WriteLine($"Reading contents of {backupFile}:");
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();


            // Managing paths
            WriteLine($"Folder Name: {Path.GetDirectoryName(textFile)}");
            WriteLine($"File Name: {Path.GetFileName(textFile)}");
            WriteLine("File Name without Extension: {0}", Path.GetFileNameWithoutExtension(textFile));
            WriteLine($"File Extension: {Path.GetExtension(textFile)}");
            WriteLine($"Random File Name: {Path.GetRandomFileName()}");
            WriteLine($"Temporary File Name: {Path.GetTempFileName()}");

            var info = new FileInfo(backupFile);
            WriteLine($"{backupFile}:");
            WriteLine($"Contains {info.Length} bytes");
            WriteLine($"Last accessed {info.LastAccessTime}");
            WriteLine($"Has readonly set to {info.IsReadOnly}");

        }

        static void Main(string[] args)
        {
            WorkWithFiles();
        }
    }
}
