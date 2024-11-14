using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace tema1
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public static bool Authenticate(string username, string password)
        {
            string[] lines = File.ReadAllLines("users.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && parts[0] == username && parts[1] == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
