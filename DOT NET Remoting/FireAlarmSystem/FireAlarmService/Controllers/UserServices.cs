using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarmService
{
    public class UserServices : MarshalByRefObject, IFireAlarmService.IUsersService
    {
        public string registerUser(string name, string email, string mobile, string nic, string password)
        {

            UserModel userModel = new UserModel(name, nic, email, password, mobile);

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("users/adduser", userModel).Result;
            return "My name is : " + userModel.Name;
        }
    }
}
