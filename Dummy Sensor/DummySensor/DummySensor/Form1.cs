using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummySensor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SensorDataModel sensorDataModel = new SensorDataModel(Convert.ToInt32(txtRoomNo.Text.ToString()),5,8);

            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("room/addSensor/"+sensorDataModel.RoomNo,sensorDataModel).Result;
            lblCO2.Text = sensorDataModel.Co2Level.ToString();
            lblSmoke.Text = sensorDataModel.SmokeLevel.ToString();

        }
    }
}
