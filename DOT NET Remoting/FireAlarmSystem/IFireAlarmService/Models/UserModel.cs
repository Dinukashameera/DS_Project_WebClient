using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarmService
{
    [Serializable]
    public class UserModel
    {
        private String name;
        private String nic;
        private String email;
        private String password;
        private String mobile;


        public UserModel(String name, String nic, String email, String password, String mobile)
        {
            this.name = name;
            this.nic = nic;
            this.email = email;
            this.password = password;
            this.mobile= mobile;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Nic
        {
            get { return nic; }
            set { nic = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

     

    

    }
}
