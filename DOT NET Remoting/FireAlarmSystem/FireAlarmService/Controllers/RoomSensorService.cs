using FireAlarmService.Models;
using IFireAlarmService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarmService
{
    public class RoomSensorService : MarshalByRefObject, IFireAlarmService.IRoomSensorService
    {
        public int addRoom(int roomNo, int floorNo, int smokeLevel, int co2Level)
        {
            Usermodel roomsModel = new Models.Usermodel(roomNo,floorNo,smokeLevel,co2Level,false);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("room/addroom", roomsModel).Result;
            return Convert.ToInt32(response.StatusCode);
        }

    
        public IEnumerable<Usermodel> viewRooms()
        {
            IEnumerable<Usermodel> roomList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("room/").Result;
            roomList = response.Content.ReadAsAsync<IEnumerable<Usermodel>>().Result;
            return roomList;
        }

        public int deleteRoom(int roomNo)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("room/deleteRoom/" + roomNo).Result;
            return Convert.ToInt32(response.StatusCode);
        }

        public IEnumerable<Usermodel> searchRoom(int roomNo)
        {
            IEnumerable<Usermodel> singleRoom;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("room/getSingleRoom/" + roomNo).Result;
            singleRoom = response.Content.ReadAsAsync<IEnumerable<Usermodel>>().Result;
            return singleRoom;
        }

        public int resetRoom(int roomNo, int floorNo)
        {
            Usermodel roomsModel = new Usermodel(roomNo,floorNo);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("room/removeUser/" + roomNo, roomsModel).Result;
            return Convert.ToInt32(response.StatusCode);
        }

        public IEnumerable<Usermodel> alert()
        {
            IEnumerable<Usermodel> alert;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("room/alert/").Result;
            alert = response.Content.ReadAsAsync<IEnumerable<Usermodel>>().Result;
            return alert;
        }


    }
}
