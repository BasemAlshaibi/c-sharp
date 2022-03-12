using System;
using System.Net;
using static System.Console;


namespace WorkingWithNetworkResources
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a valid web address: ");
            string url = ReadLine();
            if (string.IsNullOrWhiteSpace(url))
            { // هنا للتسهيل بحيث المستخدم لو دق انتر بدون ما يدخل رابط معين
              // يقوم البرنامج بالاعتماد على القيمة المسنودة ادناه ويجزئها 
                url = "https://world.episerver.com/cms/?q=pagetype";
            }
            var uri = new Uri(url);
            WriteLine($"URL: {url}");
            WriteLine($"Scheme: {uri.Scheme}");
            WriteLine($"Port: {uri.Port}");
            WriteLine($"Host: {uri.Host}");
            WriteLine($"Path: {uri.AbsolutePath}");
            WriteLine($"Query: {uri.Query}");

            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            WriteLine($"{entry.HostName} has the following IP addresses:");
            foreach (IPAddress address in entry.AddressList)
            {
                WriteLine($" {address}");
            }


        }
    }
}
