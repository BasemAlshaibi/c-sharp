namespace Packt.Shared
{
    public class User
    {//this class to represent a user stored in memory, a file, or a database
        public string Name { get; set; }
        public string Salt { get; set; }
        public string SaltedHashedPassword { get; set; }
        public string[] Roles { get; set; }

    }
}