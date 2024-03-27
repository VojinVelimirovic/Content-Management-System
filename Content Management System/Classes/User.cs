using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content_Management_System.Classes
{
    public class User
    {
        public enum UserRole { Visitor, Admin };
        private UserRole usersRole;
        private string username;
        private string password;

        public UserRole UsersRole { get => usersRole; set => usersRole = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public User() {}
        public User(UserRole usersRole, string username, string password)
        {
            this.UsersRole = usersRole;
            this.Username = username;
            this.Password = password;
        }
    }
}
