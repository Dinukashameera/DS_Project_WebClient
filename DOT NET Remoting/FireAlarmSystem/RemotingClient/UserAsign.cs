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
using System.Threading;

namespace RemotingClient
{
    public partial class UserForm : Form
    {
        IFireAlarmService.IUsersService client;
        TcpChannel channel;

        private static TimerCallback fillData;

        public UserForm()
        {
            InitializeComponent();
            //dataGridView1.Rows.Clear();
           
            channel = GlobalVariables.RegisterChannel();

           client = (IFireAlarmService.IUsersService)Activator.GetObject
           (typeof(IFireAlarmService.IUsersService), "tcp://localhost:8080/assignRoomToUser");

            client = (IFireAlarmService.IUsersService)Activator.GetObject
                    (typeof(IFireAlarmService.IUsersService), "tcp://localhost:8080/assignedRooms");

            client = (IFireAlarmService.IUsersService)Activator.GetObject
                    (typeof(IFireAlarmService.IUsersService), "tcp://localhost:8080/alertSMS");
        }

        private void btnAssignUser_Click(object sender, EventArgs e)
        {
           
            int i = client.assignRoomToUser(txtUsername.Text, txtEmail.Text, txtMobile.Text, txtNic.Text, "123456",Convert.ToInt32(txtRoomNo.Text.ToString()));
            if (i == 200)
            {
                MessageBox.Show("User Added to the Room Successfully!!!");
                txtUsername.Text = "";
                txtEmail.Text = "";
                txtMobile.Text = "";
                txtNic.Text = "";
                txtRoomNo.Text = "";
            }
            else
            {
                MessageBox.Show("Oops!!! Something went Wrong...");
            }
        }

        internal  void Run()
        {
            var autoEvent = new AutoResetEvent(false);
            int seconds = 10 * 1000;
            var timer = new System.Threading.Timer(FillData, autoEvent, 1000, seconds);
        }


        private void FillData(object state)
        {
            _ = client.alertSMS();
            string roomStatus, co2AlarmStatus, smokeAlarmStatus;
            

            IEnumerable<Usermodel> roomList = client.assignedRooms();
            dataGridView1.Rows.Clear();
            foreach (var row in roomList.ToList())
            {
                if (row.IsAlarmActive == true) roomStatus = "User In";
                else roomStatus = "User Free";

                if (row.IsCO2Active == true) co2AlarmStatus = "ON";
                else co2AlarmStatus = "OFF";

                if (row.IsSmokeActive == true) smokeAlarmStatus = "ON";
                else smokeAlarmStatus = "OFF";


                string[] userDataArray = { row.RoomNo.ToString(), row.FloorNo.ToString()+ " th Floor", row.Co2Level.ToString()+ " ml", row.SmokeLevel.ToString()+ " ml",co2AlarmStatus,smokeAlarmStatus,roomStatus };
                dataGridView1.Rows.Add(userDataArray);
                

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
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "RoomNo";
            dataGridView1.Columns[1].Name = "FloorNo";
            dataGridView1.Columns[2].Name = "CO2 Level";
            dataGridView1.Columns[3].Name = "Smoke Level";
            dataGridView1.Columns[4].Name = "CO2 Sensor";
            dataGridView1.Columns[5].Name = "Smoke Sensor";
            dataGridView1.Columns[6].Name = "Room Status";

            Run();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
