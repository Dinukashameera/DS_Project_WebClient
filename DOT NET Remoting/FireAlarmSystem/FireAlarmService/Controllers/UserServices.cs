using FireAlarmService.Models;
using IFireAlarmService.Models;
using IFireAlarmService;
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
      

        public int assignRoomToUser(string username, string email, string mobile, string nic, string password,int roomNo)
        {
            UserModel userModel = new UserModel(username, nic, email, password, mobile);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("room/addCustomer/" + roomNo, userModel).Result;
            return Convert.ToInt32(response.StatusCode);
        }

        public IEnumerable<RoomsModel> assignedRooms()
        {
            IEnumerable<RoomsModel> roomList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("room/").Result;
            roomList = response.Content.ReadAsAsync<IEnumerable<RoomsModel>>().Result;
            return roomList;
        }

      
        public int registerAdmin(string name, string email, string mobile, string password)
        {
            AdminModel adminModel = new AdminModel(name, email, mobile, password);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("users/register",adminModel).Result;
            return Convert.ToInt32(response.StatusCode);
        }



        public int loginAdmin(string email, string password)
        {
            AdminModel adminModel = new AdminModel(email,password);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("users/login",adminModel).Result;
            return Convert.ToInt32(response.StatusCode);
        }
    }
}
