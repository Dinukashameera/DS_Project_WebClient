using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarmService
{
    class UserModel
    {

        private String name;
        private String nic;
        private String email;
        private String password;
        private String mobileNumber;


        public UserModel(String a_name, String a_NIC, String a_email, String a_password, String a_mobileNumber)
        {
            name = a_name;
            nic = a_NIC;
            email = a_email;
            password = a_password;
            mobileNumber = a_mobileNumber;
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

        public string MobileNumber
        {
            get { return mobileNumber; }
            set { mobileNumber = value; }
        }
    }
}
