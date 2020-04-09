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
    public partial class UsersForm : Form
    {
        IFireAlarmService.IUsersService client;
        public UsersForm()
        {
            InitializeComponent();
            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel);
            client = (IFireAlarmService.IUsersService)Activator.GetObject
                (typeof(IFireAlarmService.IUsersService), "tcp://localhost:8080/registerUser");
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
            RoomForm Check = new RoomForm();
            Check.Show();
        }
    }
}
