using FireAlarmService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarmService.Controllers
{
    public class RoomSensorService : MarshalByRefObject, IFireAlarmService.IRoomSensorService
    {
        public string addRoom(int roomNo, int floorNo, int smokeLevel, int co2Level)
        {
            RoomsModel roomsModel = new RoomsModel(roomNo,floorNo,smokeLevel,co2Level);

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("room/addroom", roomsModel).Result;
            return "My name is : " + roomsModel.RoomNo;
        }
    }
}
