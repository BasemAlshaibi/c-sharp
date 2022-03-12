using System;
using static System.Console;
using Packt.Shared;

namespace AssembliesAndNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {

            Write("Enter a color value in hex: ");
            string hex = ReadLine();
            WriteLine("Is {0} a valid color value? {1}",
            arg0: hex, arg1: hex.IsValidHex());
            /* هنا صرنا نتعامل مع دالة الهكس
             التي عملناها بمكتبنا 
            وكانها من كلاسات الاسترننج نفسه
           IsValidXmlTag وبالمثل لدالتي 
            IsValidPassword و
            */
            Write("Enter a XML element: ");
            string xmlTag = ReadLine();
            WriteLine("Is {0} a valid XML element? {1}",
            arg0: xmlTag, arg1: xmlTag.IsValidXmlTag());
            Write("Enter a password: ");
            string password = ReadLine();
            WriteLine("Is {0} a valid password? {1}",
            arg0: password, arg1: password.IsValidPassword());
        }
    }
}
