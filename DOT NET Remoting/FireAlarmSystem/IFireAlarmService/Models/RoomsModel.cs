using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarmService.Models
{
    [Serializable]
    public class Usermodel
    {
        private int roomNo;
        private int floorNo;
        private int smokeLevel;
        private int co2Level;
        private Boolean isAlarmActive;
        private Boolean isCO2Active;
        private Boolean isSmokeActive;


        public Usermodel(int roomNo, int floorNo, int smokeLevel, int co2Level, Boolean isAlarmActive)
        {
            this.roomNo = roomNo;
            this.floorNo = floorNo;
            this.smokeLevel = smokeLevel;
            this.co2Level = co2Level;
            this.isAlarmActive = isAlarmActive;
        }

        public Usermodel(int roomNo,int floorNo)
        {
            this.roomNo = roomNo;
            this.floorNo = floorNo;
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

        public Boolean IsAlarmActive
        {
            get { return isAlarmActive; }
            set { isAlarmActive = value; }
        }

        public Boolean IsCO2Active
        {
            get { return isCO2Active; }
            set { isCO2Active = value; }
        }

        public Boolean IsSmokeActive
        {
            get { return isSmokeActive; }
            set { isSmokeActive = value; }
        }
      


    }
}
