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
using System.Threading;

namespace RemotingClient
{
    public partial class AddRooms : Form
    {
        IFireAlarmService.IRoomSensorService client;
        TcpChannel channel;
        public AddRooms()
        {
            InitializeComponent();
            channel = GlobalVariables.RegisterChannel();

            client = (IFireAlarmService.IRoomSensorService)Activator.GetObject
             (typeof(IFireAlarmService.IRoomSensorService), "tcp://localhost:8080/addRoom");

            client = (IFireAlarmService.IRoomSensorService)Activator.GetObject
                (typeof(IFireAlarmService.IRoomSensorService), "tcp://localhost:8080/viewRooms");


            client = (IFireAlarmService.IRoomSensorService)Activator.GetObject
                (typeof(IFireAlarmService.IRoomSensorService), "tcp://localhost:8080/searchRoom");


            client = (IFireAlarmService.IRoomSensorService)Activator.GetObject
                (typeof(IFireAlarmService.IRoomSensorService), "tcp://localhost:8080/deleteRoom");


            client = (IFireAlarmService.IRoomSensorService)Activator.GetObject
                (typeof(IFireAlarmService.IRoomSensorService), "tcp://localhost:8080/resetRoom");

            client = (IFireAlarmService.IRoomSensorService)Activator.GetObject
                (typeof(IFireAlarmService.IRoomSensorService), "tcp://localhost:8080/alert");
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            int i = client.addRoom(Convert.ToInt32(txtRoomNo.Text.ToString()), Convert.ToInt32(txtFloorNo.Text.ToString()),0,0);

            if (i == 200)
            {
                MessageBox.Show("Room added Successfully!!!");
                txtRoomNo.Text = "";
                txtFloorNo.Text = "";
            }
            else
            {
                MessageBox.Show("Room Already Exists...");
            }
        }

        private void btnUserForm_Click(object sender, EventArgs e)
        {
            channel.StopListening(null);
            RemotingServices.Disconnect(this);
            ChannelServices.UnregisterChannel(channel);
            channel = null;

            UserForm Check = new UserForm();
            Check.Show();
            this.Hide();
        }

        internal void Run()
        {
            var autoEvent = new AutoResetEvent(false);
            int seconds = 10 * 1000;
            var timer = new System.Threading.Timer(FillData, autoEvent, 1000, seconds);
        }


        private void FillData(object state)
        {
            string roomStatus;
            _ = client.alert();

            IEnumerable<Usermodel> roomList = client.viewRooms();
            dataGridView1.Rows.Clear();


            foreach (var row in roomList.ToList())
            {
              dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
              if (row.IsAlarmActive == true)
              {
                roomStatus = "User In";
              }
              else
              {
                roomStatus = "User Free";
              }
               string[] userDataArray = { row.RoomNo.ToString(), row.FloorNo.ToString() + " th Floor", row.Co2Level.ToString() + " ml", row.SmokeLevel.ToString() + " ml" , roomStatus };
               dataGridView1.Rows.Add(userDataArray);

            }
        }


        private void AddRooms_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "RoomNo";
            dataGridView1.Columns[1].Name = "FloorNo";
            dataGridView1.Columns[2].Name = "CO2 Level";
            dataGridView1.Columns[3].Name = "Smoke Level";
            dataGridView1.Columns[4].Name = "Status";
            dataGridView1.ScrollBars = ScrollBars.Both;
            Run();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IEnumerable<Usermodel> singleRoom = client.searchRoom(Convert.ToInt32(txtSearch.Text.ToString()));

            if(singleRoom.ToList().Count == 1)
            {
                foreach (var row in singleRoom.ToList())
                {
                    txtRoomNo.Text = row.RoomNo.ToString();
                    txtFloorNo.Text = row.FloorNo.ToString();
                }
            }
            else
            {
                MessageBox.Show("Room Not Found");
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = client.deleteRoom(Convert.ToInt32(txtRoomNo.Text.ToString()));
            if(i == 200)
            {
                MessageBox.Show("Room Deleted Successfully");
                txtSearch.Text = "";
                txtRoomNo.Text = "";
                txtFloorNo.Text = "";
            }
            else if(i == 404)
            {
                MessageBox.Show("Room Not Found");
            }
            else
            {
                MessageBox.Show("Oops!!! Something went Wrong");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            int i = client.resetRoom(Convert.ToInt32(txtRoomNo.Text.ToString()), Convert.ToInt32(txtFloorNo.Text.ToString()));
            if(i == 200)
            {
                MessageBox.Show("Room Reset is Successfuly Done");
                txtSearch.Text = "";
                txtRoomNo.Text = "";
                txtFloorNo.Text = "";


            }else if(i == 404)
            {
                MessageBox.Show("Invalid Room Number!!!");
            }
            else
            {
                MessageBox.Show("Oops!!! Something Went Wrong!!!");
            }
        }
    }
}
