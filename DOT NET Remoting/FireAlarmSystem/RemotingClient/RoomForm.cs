using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using FireAlarmService.Models;
using System.Runtime.Remoting;

namespace RemotingClient
{
    public partial class RoomForm : Form
    {
        IFireAlarmService.IRoomSensorService client;
        TcpChannel channel;
        public RoomForm()
        {
            InitializeComponent();
             channel = GlobalVariables.RegisterChannel();

            client = (IFireAlarmService.IRoomSensorService)Activator.GetObject
             (typeof(IFireAlarmService.IRoomSensorService), "tcp://localhost:8080/addRoom");
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            label4.Text = client.addRoom(Convert.ToInt32(txtRoomNo.Text.ToString()), Convert.ToInt32(txtFloorNo.Text.ToString()), Convert.ToInt32(txtSmokeLevel.Text.ToString()), Convert.ToInt32(txtCO2Level.Text.ToString()));
        }

        private void btnAssignUser_Click(object sender, EventArgs e)
        {
            lblAssignMsg.Text = client.assignRoom(Convert.ToInt32(txtAssignRoomNo.Text.ToString()),txtAssignUserNic.Text.ToString(),txtEmail.Text,txtMobile.Text);
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "RoomNo";
            dataGridView1.Columns[1].Name = "FloorNo";
            dataGridView1.Columns[2].Name = "CO2 Level";
            dataGridView1.Columns[3].Name = "Smoke Level";



            fillData();
            fillData();
         fillData();
            fillData();
            
        }


        public void fillData()
        {
            IEnumerable<RoomsModel> roomList = client.viewRooms();
            foreach (var row in roomList.ToList())
            {

                if(row.IsAlarmActive == true)
                {
                    string[] userDataArray = { row.RoomNo.ToString(), row.FloorNo.ToString(), row.Co2Level.ToString(), row.SmokeLevel.ToString() };
                    dataGridView1.Rows.Add(userDataArray);
                }

             
            }
        }

        private void btnUserForm_Click(object sender, EventArgs e)
        {
            channel.StopListening(null);
            RemotingServices.Disconnect(this);
            ChannelServices.UnregisterChannel(channel);
            channel = null;

            UsersForm Check = new UsersForm();
            Check.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
