using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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
            int roomNO = Convert.ToInt32(txtRoomNo.Text.ToString());
            int count = 1;
            int smoke = 0, co2 = 10;


            for (int i = 1; i <= 10; i++)
            {
                smoke++;
                co2--;

                lblCO2.Text = co2.ToString();
                lblSmoke.Text = smoke.ToString();

                SensorDataModel sensorDataModel = new SensorDataModel(roomNO,smoke,co2);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("room/addSensor/"+sensorDataModel.RoomNo,sensorDataModel).Result;
               

                    Thread.Sleep(5000);
                
            }

         

        }
    }
}
