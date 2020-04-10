using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummySensor
{
    class SensorDataModel
    {
        private int roomNo;
        private int smokeLevel;
        private int co2Level;
        private int v1;
        private int v2;
        private int v3;

        public SensorDataModel(int v1, int v2, int v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
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
