using System;
using static System.Console;
using System.IO;


namespace WorkWithDrives
{
    class Program
    {


        static void WorkWithDrives()
        {    // الكود التالي يطبع الهيد حق الحق المخرجات اي مجرد نص منسق
             // الارقام اللي بجوار الاندكسس حق البرميترات النصية تشير للمحاذاة بالمسافة 
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
            "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady) // اذا وجد العنصر
                {
                    WriteLine(
                    "{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
                    d.Name, d.DriveType, d.DriveFormat,d.TotalSize, d.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0,-30} | {1,-10}", d.Name, d.DriveType);
                }
            }
        }


        static void Main(string[] args)
        {
            WorkWithDrives();
        }
    }
}
