﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarmService.Models
{
    [Serializable]
    public class RoomsModel
    {
        private int roomNo;
        private int floorNo;
        private Boolean isAlarmActive;
        private int smokeLevel;
        private int co2Level;
        private string user;

        public RoomsModel(int roomNo, int floorNo, int smokeLevel, int co2Level,string user,Boolean isAlarmActive)
        {
            this.roomNo = roomNo;
            this.floorNo = floorNo;
            this.smokeLevel = smokeLevel;
            this.co2Level = co2Level;
            this.user = user;
            this.isAlarmActive = isAlarmActive;
        }

        public int RoomNo
        {
            get { return roomNo; }
            set { roomNo = value; }
        }

        public int FloorNo
        {
            get { return floorNo; }
            set { floorNo = value; }
        }

        public int SmokeLevel
        {
            get { return smokeLevel; }
            set { smokeLevel = value; }
        }

        public int Co2Level
        {
            get { return co2Level; }
            set { co2Level = value; }
        }

        public string User
        {
            get { return user ; }
            set { user = value; }
        }

        public Boolean IsAlarmActive
        {
            get { return isAlarmActive; }
            set { isAlarmActive = value; }
        }


    }
}
