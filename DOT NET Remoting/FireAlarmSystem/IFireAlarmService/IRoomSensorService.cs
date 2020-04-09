using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFireAlarmService
{
    public interface IRoomSensorService
    {
        string addRoom(int roomNo, int floorNo, int smokeLevel, int co2Level);
    }
}
