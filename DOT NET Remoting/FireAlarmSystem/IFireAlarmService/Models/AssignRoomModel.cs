using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFireAlarmService.Models
{
    [Serializable]
    public class AssignRoomModel
    {
        private int roomNo;
        private string nic;

        public AssignRoomModel(int roomNo,String nic)
        {
            this.roomNo = roomNo;
            this.nic = nic;
        }

        public int RoomNo
        {
            get { return roomNo; }
            set { roomNo = value; }
        }

        public String Nic
        {
            get { return nic; }
            set { nic = value; }
        }
    }
}
