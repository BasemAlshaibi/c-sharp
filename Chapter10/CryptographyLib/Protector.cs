using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;
using static System.Convert;
namespace Packt.Shared
{
    public static class Protector
    {
        // salt size must be at least 8 bytes, we will use 16 bytes
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("7BANANAS");
        //Encoding.Unicode.GetBytes ==>Encodes a set of characters into a sequence of bytes.

        // iterations must be at least 1000, we will use 2000
        private static readonly int iterations = 2000;
        // We used double the recommended salt size and iteration count.
        /*  the salt and iteration count can be hardcoded,
         the password must be passed at runtimewhen calling the Encrypt and Decrypt methods.
        */
        public static string Encrypt(string plainText, string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            /*
            we  will always use an abstract class like Aes and its Create factory method to get an
            instance of an algorithm
            */
            var aes = Aes.Create();
            /*
            now we reliably generate a key and IV using a password-based key derivation function
            (PBKDF2). A good one is the Rfc2898DeriveBytes class, which takes a password, a salt, and an
            iteration count, and then generates keys and IVs by making calls to its GetBytes method 
            */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32); // set a 256-bit key
            aes.IV = pbkdf2.GetBytes(16); // set a 128-bit IV 

            using (var ms = new MemoryStream())//Bytes stored in memory in the current process
            {  /*Symmetric encryption algorithms use CryptoStream to encrypt or decrypt large amounts of
                 bytes efficiently. 
                */
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
                /*We use a temporary MemoryStream type to store the results of encrypting and
                decrypting, and then call ToArray to fitch the stream into a byte array
                */
            }
            return Convert.ToBase64String(encryptedBytes);
            /*We convert the encrypted byte arrays to and from a Base64 encoding to make
              them easier to read.
            */
        }
        public static string Decrypt(string cryptoText, string password)
        {
            byte[] plainBytes;
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);

            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }
                plainBytes = ms.ToArray();
            }
            return Encoding.Unicode.GetString(plainBytes);
        }


        // this code for Hashing with the commonly used SHA256
        //We will use a dictionary to store multiple users in memory:
        private static Dictionary<string, User> Users = new Dictionary<string, User>();
        //method to register a new user 
        public static User Register(string username, string password, string[] roles = null)
        {
            // generate a random salt
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            /* بعد توليد الرقم العشوائي وانشاء مصفوفة البايت
            يقوم الامر الثالثب بملئ مصفوفة  البايت اللي اسمها سالت بايت 
            بسلسلة  عشوائية قوية من القيم واللي هي ار ان جي.
               */
            var saltText = Convert.ToBase64String(saltBytes);
            // generate the salted and hashed password
            var saltedhashedPassword = SaltAndHashPassword(password, saltText);
            var user = new User
            {
                Name = username,
                Salt = saltText,
                SaltedHashedPassword = saltedhashedPassword,
                Roles = roles
            };
            Users.Add(user.Name, user);
            return user;
        }
        public static bool CheckPassword(string username, string password)
        {
            if (!Users.ContainsKey(username))
            {
                return false;
            }
            var user = Users[username];
            // re-generate the salted and hashed password
            var saltedhashedPassword = SaltAndHashPassword(password, user.Salt);
            return (saltedhashedPassword == user.SaltedHashedPassword);
        }
        private static string SaltAndHashPassword(string password, string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + salt;
            return Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
        }

        public static byte[] GetRandomKeyOrIV(int size)
        {
            var r = RandomNumberGenerator.Create();
            var data = new byte[size];
            r.GetNonZeroBytes(data);
            // data is an array now filled with
            // cryptographically strong random bytes
            return data;
        }

        public static void LogIn(string username, string password)
        {
            if (CheckPassword(username, password))
            {
                var identity = new GenericIdentity(username, "PacktAuth");
                var principal = new GenericPrincipal(identity, Users[username].Roles);
                System.Threading.Thread.CurrentPrincipal = principal;
            }
        }





    }
}