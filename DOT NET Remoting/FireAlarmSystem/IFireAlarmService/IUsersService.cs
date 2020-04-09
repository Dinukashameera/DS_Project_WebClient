using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFireAlarmService
{
    public interface IUsersService
    {
       string registerUser(String Name, String Email, String Mobile, String NIC, String Password);

    }
}
