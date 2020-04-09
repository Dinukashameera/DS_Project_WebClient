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

namespace RemotingClient
{
    public partial class RoomForm : Form
    {
        IFireAlarmService.IRoomSensorService client;
        public RoomForm()
        {
            InitializeComponent();
           TcpChannel channel = GlobalVariables.RegisterChannel();

            client = (IFireAlarmService.IRoomSensorService)Activator.GetObject
             (typeof(IFireAlarmService.IRoomSensorService), "tcp://localhost:8080/addRoom");
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            label4.Text = client.addRoom(Convert.ToInt32(txtRoomNo.Text.ToString()), Convert.ToInt32(txtFloorNo.Text.ToString()), Convert.ToInt32(txtSmokeLevel.Text.ToString()), Convert.ToInt32(txtCO2Level.Text.ToString()));
        }
    }
}
