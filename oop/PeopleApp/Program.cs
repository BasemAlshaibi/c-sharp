using System;
using Packt.Shared;
using static System.Console;


namespace PeopleApp
{
    class Program
    {

        static void Main(string[] args)
        {

            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";
            WriteLine(
           "{0} is a valid e-mail address: {1}",
           arg0: email1,
           arg1: email1.IsValidEmail());
            WriteLine(
            "{0} is a valid e-mail address: {1}",
            arg0: email2,
            arg1: email2.IsValidEmail());

        }

    }
}