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
    public partial class Admin : Form
    {

        IFireAlarmService.IUsersService client;
        TcpChannel channel;
        public Admin()
        {
            InitializeComponent();
            channel = GlobalVariables.RegisterChannel();

            client = (IFireAlarmService.IUsersService)Activator.GetObject
             (typeof(IFireAlarmService.IUsersService), "tcp://localhost:8080/registerAdmin"); 
            
            client = (IFireAlarmService.IUsersService)Activator.GetObject
             (typeof(IFireAlarmService.IUsersService), "tcp://localhost:8080/loginAdmin");
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            //string name,string email,string mobile,string password
            int i = client.registerAdmin(txtUsername.Text, txtEmail.Text, txtMobile.Text, txtPassword.Text);
            if(i == 200)
            {
                MessageBox.Show("Registered Successfully");
                txtUsername.Text = "";
                txtMobile.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
            }
            else if (i == 403)
            {
                MessageBox.Show("User Email Already Registered");
            }
            else
            {
                MessageBox.Show("Oops!!! Something wet wrong");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int i = client.loginAdmin(txtEmailLogin.Text, txtPasswordLogin.Text);
            if(i == 200)
            {
                channel.StopListening(null);
                RemotingServices.Disconnect(this);
                ChannelServices.UnregisterChannel(channel);
                channel = null;

                UserForm Check = new UserForm();
                Check.Show();
                this.Hide();
            }
            else if(i == 400)
            {
                MessageBox.Show("Invalid Password!!!");
            }
            else if(i == 404)
            {
                MessageBox.Show("User Does Not Exsist in the System");
            }
        }

        private void txtPasswordLogin_TextChanged(object sender, EventArgs e)
        {
            txtPasswordLogin.PasswordChar = '*';
           
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
           
        }
    }
}
