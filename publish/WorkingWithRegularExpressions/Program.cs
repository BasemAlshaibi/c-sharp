using System;
using static System.Console;
using System.Text.RegularExpressions;

namespace WorkingWithRegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter your age: ");
            string input = ReadLine();
            Regex ageChecker = new Regex(@"^\d{,3}$");
            if (ageChecker.IsMatch(input))
            {
                WriteLine("Thank you!");
            }
            else
            {
                WriteLine($"This is not a valid age: {input}");
            }
        }
    }
}
