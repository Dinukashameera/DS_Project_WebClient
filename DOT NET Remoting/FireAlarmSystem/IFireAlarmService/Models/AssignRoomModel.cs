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
        private string email;
        private string mobile;

        public AssignRoomModel(int roomNo,String nic,String email,string mobile)
        {
            this.roomNo = roomNo;
            this.nic = nic;
            this.email = email;
            this.mobile = mobile;
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

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
    }
}
