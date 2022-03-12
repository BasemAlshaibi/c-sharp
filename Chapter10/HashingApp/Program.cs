 
using System;
using System.Security.Cryptography; // CryptographicException
using Packt.Shared; // Protector
using static System.Console;

namespace HashingApp
{
    class Program
    {
        static void Main(string[] args)
        {
//  register a user by code
            WriteLine("Registering elias with Pa$$w0rd.");
            var elias = Protector.Register("elias", "Pa$$w0rd");
            WriteLine($"Name: {elias.Name}");
            WriteLine($"Salt: {elias.Salt}");
            WriteLine("Password (salted and hashed): {0}",arg0: elias.SaltedHashedPassword);
            WriteLine();
            // prompt user to register a second one at runtime
            Write("Enter a new user to register: ");
            string username = ReadLine();
            Write($"Enter a password for {username}: ");
            string password = ReadLine();
            var user = Protector.Register(username, password);
            WriteLine($"Name: {user.Name}");
            WriteLine($"Salt: {user.Salt}");
            WriteLine("Password (salted and hashed): {0}",arg0: user.SaltedHashedPassword);
            WriteLine();
            bool correctPassword = false;
            while (!correctPassword)
            {
                Write("Enter a username to log in: ");
                string loginUsername = ReadLine();
                Write("Enter a password to log in: ");
                string loginPassword = ReadLine();
                correctPassword = Protector.CheckPassword(loginUsername, loginPassword);
                if (correctPassword)
                {
                    WriteLine($"Correct! {loginUsername} has been logged in.");
                }
                else
                {
                    WriteLine("Invalid username or password. Try again.");
                }
            }        }
    }
}
