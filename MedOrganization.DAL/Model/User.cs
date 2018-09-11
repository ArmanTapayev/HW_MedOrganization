using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedOrganization.DAL.Model
{
    public enum Role { Admin, User }
    public class User: IUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public DateTime DoB { get; set; }

        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public User() { }
        public User(string login, string password, Role role)
        {
            Login = login;
            Password = password;
            Role = role;
        }
        public User(string fname, string lname):this(fname, lname, "") { }
        public User(string fname, string lname, string mname)
        {
            FName = fname;
            LName = lname;
            MName = mname;
        }
    }
}
