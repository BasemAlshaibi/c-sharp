using System;
using System.Linq;

namespace LinqWithObjects
{
    class Program
    {

        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
           
        }
        static void LinqWithArrayOfStrings()
        {
            var names = new string[] { "elias", "Bassem", "Nani", "Akram", "Aleen", "Ahmen mohsen", "Amal", "Saeed" };
           //  var query = names.Where(new Func<string, bool>(NameLongerThanFour));
          // var query = names.Where(NameLongerThanFour);
            var query = names
             .Where( n => n.Length > 4)
             .OrderByDescending(n => n.Length)
             .ThenBy(n=>n);

 
            foreach (string item in query)
            {
                Console.WriteLine(item);
            }

        }
        static void Main(string[] args)
        {
            LinqWithArrayOfStrings();
        }
    }
}
