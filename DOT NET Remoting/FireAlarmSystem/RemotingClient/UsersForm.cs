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

namespace RemotingClient
{
    public partial class UsersForm : Form,IDisposable
    {
        IFireAlarmService.IUsersService client;
        TcpChannel channel;
        public UsersForm()
        {
            InitializeComponent();

            channel = GlobalVariables.RegisterChannel();

           // label5.Text = "Start Client : " +client.ToString();

            client = (IFireAlarmService.IUsersService)Activator.GetObject
                 (typeof(IFireAlarmService.IUsersService), "tcp://localhost:8080/registerUser");

           // label6.Text = "Stop Client " +client.ToString();

        

           

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            btnadd.Text = "Update";
            label4.Text = client.registerUser(txtUserName.Text, txtEmail.Text, txtMobile.Text, txtNic.Text, textPassword.Text);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {

            channel.StopListening(null);
            RemotingServices.Disconnect(this);
            ChannelServices.UnregisterChannel(channel);
            channel = null;

            RoomForm Check = new RoomForm();
            Check.Show();
        }
    }
}
