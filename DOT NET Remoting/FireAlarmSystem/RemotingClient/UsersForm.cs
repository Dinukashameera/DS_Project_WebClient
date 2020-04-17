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
using FireAlarmService;

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

           // client = (IFireAlarmService.IUsersService)Activator.GetObject
                // (typeof(IFireAlarmService.IUsersService), "tcp://localhost:8080/registerUser");

            client = (IFireAlarmService.IUsersService)Activator.GetObject
           (typeof(IFireAlarmService.IUsersService), "tcp://localhost:8080/viewUsers");


            label4.Text = "";
            // label6.Text = "Stop Client " +client.ToString();
            

        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            fillData();
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            btnadd.Text = "Update";
            int i = client.registerUser(txtUserName.Text, txtEmail.Text, txtMobile.Text, txtNic.Text, textPassword.Text);

            if(i == 200)
            {
                MessageBox.Show("User Added Successfully!!!");
            }
            else
            {
                MessageBox.Show("Oops!!! Something went Wrong...");
            }

            fillData();
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
            this.Hide();
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
      

 
        }

        public void fillData()
        {
            IEnumerable<UserModel> userList = client.viewUsers();
            foreach (var row in userList.ToList())
            {
                string[] userDataArray = { row.Name.ToString(), row.Email.ToString(), row.MobileNumber.ToString(), row.Nic.ToString(), "2020/06/17", "2020/06/20" };
                dataGridView1.Rows.Add(userDataArray);
                // richTextBox1.Text = ("Name : " + row.Name.ToString() + "Email : " + row.Email.ToString());
            }
        }
    }
}
