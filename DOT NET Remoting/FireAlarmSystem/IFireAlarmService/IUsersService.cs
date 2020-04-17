
using FireAlarmService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFireAlarmService
{
    public interface IUsersService
    {
       int registerUser(String Name, String Email, String Mobile, String NIC, String Password);

       IEnumerable<UserModel> viewUsers();

    }
}
