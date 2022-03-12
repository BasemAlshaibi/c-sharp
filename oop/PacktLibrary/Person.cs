using System;
using System.Collections.Generic;
using static System.Console;
namespace Packt.Shared
{
    public partial class Person
    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();

        // methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        public void TimeTravel(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                throw new PersonException("If you travel back in time to a date earlier than your own birth, then the universe will explode!");
            }
            else
            {
                WriteLine($"Welcome to {when:yyyy}!");
            }
        }


    }
}