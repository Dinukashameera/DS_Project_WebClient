using FireAlarmService;
using FireAlarmService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IFireAlarmService
{
    public interface IRoomSensorService
    {
        int addRoom(int roomNo, int floorNo, int smokeLevel, int co2Level);
        IEnumerable<RoomsModel> viewRooms();
        IEnumerable<RoomsModel> searchRoom(int roomNo);
        int resetRoom(int roomNo, int floorNo);
        int deleteRoom(int roomNo);

        
    }
}
