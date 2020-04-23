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
using System.Runtime.Remoting;
using FireAlarmService.Models;

namespace RemotingClient
{
    public partial class UserForm : Form
    {
        IFireAlarmService.IUsersService client;
        TcpChannel channel;
        public UserForm()
        {
            InitializeComponent();
            //fillData();
            channel = GlobalVariables.RegisterChannel();


           client = (IFireAlarmService.IUsersService)Activator.GetObject
           (typeof(IFireAlarmService.IUsersService), "tcp://localhost:8080/assignRoomToUser");

            client = (IFireAlarmService.IUsersService)Activator.GetObject
                    (typeof(IFireAlarmService.IUsersService), "tcp://localhost:8080/assignedRooms");
        }

        private void btnAssignUser_Click(object sender, EventArgs e)
        {
           
            int i = client.assignRoomToUser(txtUsername.Text, txtEmail.Text, txtMobile.Text, txtNic.Text, "123456",Convert.ToInt32(txtRoomNo.Text.ToString()));
            if (i == 200)
            {
                MessageBox.Show("User Added to the Room Successfully!!!");
            }
            else
            {
                MessageBox.Show("Oops!!! Something went Wrong...");
            }
        }


        public void fillData()
        {
            IEnumerable<RoomsModel> roomList = client.assignedRooms();
            foreach (var row in roomList.ToList())
            {

                if (row.IsAlarmActive == true)
                {
                    string[] userDataArray = { row.RoomNo.ToString(), row.FloorNo.ToString(), row.Co2Level.ToString(), row.SmokeLevel.ToString() };
                    dataGridView1.Rows.Add(userDataArray);
                }


            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            channel.StopListening(null);
            RemotingServices.Disconnect(this);
            ChannelServices.UnregisterChannel(channel);
            channel = null;

            AddRooms Check = new AddRooms();
            Check.Show();
            this.Hide();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "RoomNo";
            dataGridView1.Columns[1].Name = "FloorNo";
            dataGridView1.Columns[2].Name = "CO2 Level";
            dataGridView1.Columns[3].Name = "Smoke Level";

            
        }
    }
}
