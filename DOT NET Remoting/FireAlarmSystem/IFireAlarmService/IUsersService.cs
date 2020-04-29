
using FireAlarmService;
using FireAlarmService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFireAlarmService
{
    public interface IUsersService
    {
       int assignRoomToUser(string username, string email, string mobile, string nic, string password, int roomNo);
       IEnumerable<Usermodel> assignedRooms();
       int registerAdmin(string name, string email, string mobile, string password);
       int loginAdmin(string email, string password);
       IEnumerable<UserModel> alertSMS();
    }
}
