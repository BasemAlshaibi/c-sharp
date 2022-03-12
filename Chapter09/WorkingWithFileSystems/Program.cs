using System;
using System.IO; // types for managing the filesystem
using static System.Console;


namespace WorkingWithFileSystems
{
    class Program
    {
        static void OutputFileSystemInfo()
        {
            WriteLine("{0,-33} {1}", "Path.PathSeparator", Path.PathSeparator);
            WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar", Path.DirectorySeparatorChar);
            // Path.DirectorySeparatorChar=\
            // Path.PathSeparator=;
            //also we have Path.VolumeSeparatorChar=:
           // Path.AltDirectorySeparatorChar=/

            WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory()", Directory.GetCurrentDirectory());
            //D:\Learn WEB\c sharp\Chapter09\WorkingWithFileSystems
            WriteLine("{0,-33} {1}", "Environment.CurrentDirectory", Environment.CurrentDirectory);
            //D:\Learn WEB\c sharp\Chapter09\WorkingWithFileSystems
            WriteLine("{0,-33} {1}", "Environment.SystemDirectory", Environment.SystemDirectory);
            // C:\Windows\system32
            WriteLine("{0,-33} {1}", "Path.GetTempPath()", Path.GetTempPath());
            // C:\Users\Basem\AppData\Local\Temp\
            WriteLine("GetFolderPath(SpecialFolder");
            WriteLine("{0,-33} {1}", " .System)", Environment.GetFolderPath(Environment.SpecialFolder.System));
            //C:\Windows\system32
            WriteLine("{0,-33} {1}", " .ApplicationData)", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            //C:\Users\Basem\AppData\Roaming
            WriteLine("{0,-33} {1}", " .MyDocuments)", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            // C:\Users\Basem\Documents
            WriteLine("{0,-33} {1}", " .Personal)", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            // C:\Users\Basem\Documents
        }
        static void Main(string[] args)
        {
            OutputFileSystemInfo();
        }
    }
}
