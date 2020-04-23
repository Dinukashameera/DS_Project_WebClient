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
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            int i = client.addRoom(Convert.ToInt32(txtRoomNo.Text.ToString()), Convert.ToInt32(txtFloorNo.Text.ToString()), Convert.ToInt32(txtSmokeLevel.Text.ToString()), Convert.ToInt32(txtCO2Level.Text.ToString()));

            if (i == 200)
            {
                MessageBox.Show("Room added Successfully!!!");
            }
            else
            {
                MessageBox.Show("Oops!!! Something went Wrong...");
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
    }
}
