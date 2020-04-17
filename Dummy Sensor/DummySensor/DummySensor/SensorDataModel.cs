using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummySensor
{
    [Serializable]
    public class SensorDataModel
    {
        private int roomNo;
        private int smokeLevel;
        private int co2Level;
     

        public SensorDataModel(int roomNo, int smokeLevel, int co2Level)
        {
            this.roomNo = roomNo;
            this.smokeLevel = smokeLevel;
            this.co2Level = co2Level;
        }

        public int RoomNo 
        {
            get { return roomNo; }
            set { roomNo = value; }
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
    }
}
