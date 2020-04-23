using FireAlarmService.Models;
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
            RoomsModel roomsModel = new Models.RoomsModel(roomNo,floorNo,smokeLevel,co2Level,false);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("room/addroom", roomsModel).Result;
            return Convert.ToInt32(response.StatusCode);
        }

    
        public IEnumerable<RoomsModel> viewRooms()
        {
            IEnumerable<RoomsModel> roomList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("room/").Result;
            roomList = response.Content.ReadAsAsync<IEnumerable<RoomsModel>>().Result;
            return roomList;
        }
    }
}
