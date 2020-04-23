using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFireAlarmService.Models
{
    [Serializable]
    public class AdminModel
    {

        private String name;
        private String email;
        private String mobile;
        private String password;


        public AdminModel(string name,string email,string mobile,string password)
        {
            this.name = name;
            this.email = email;
            this.mobile = mobile;
            this.password = password;
        }

        public AdminModel(string email,string password)
        {
            this.email = email;
            this.password = password;
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public String Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
