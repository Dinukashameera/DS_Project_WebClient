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
        public IEnumerable<UserModel> viewUsers()
        {
            IEnumerable<UserModel> userList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("users/").Result;
            userList = response.Content.ReadAsAsync<IEnumerable<UserModel>>().Result;
            return userList;
        }

        public int registerUser(string name, string email, string mobile, string nic, string password)
        {
            UserModel userModel = new UserModel(name, nic, email, password, mobile);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("users/adduser", userModel).Result;
            return Convert.ToInt32(response.StatusCode);
        }

      


    }
}
