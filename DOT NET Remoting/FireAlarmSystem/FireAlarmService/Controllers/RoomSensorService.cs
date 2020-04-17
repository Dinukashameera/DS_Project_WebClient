using FireAlarmService.Models;
using IFireAlarmService.Models;
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
        public string addRoom(int roomNo, int floorNo, int smokeLevel, int co2Level)
        {
            RoomsModel roomsModel = new Models.RoomsModel(roomNo,floorNo,smokeLevel,co2Level);

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("room/addroom", roomsModel).Result;
            return "My name is : " + roomsModel.RoomNo;
        }

        public string assignRoom(int roomNo, string nic)
        {
            AssignRoomModel assignRoomsModel = new AssignRoomModel(roomNo,nic);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("room/addCustomer/" +roomNo, assignRoomsModel).Result;
            return "Successfully Assigned" + assignRoomsModel.Nic;
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
