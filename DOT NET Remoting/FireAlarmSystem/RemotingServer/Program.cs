using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using FireAlarmService;

namespace RemotingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(8080);

            FireAlarmService.UserServices fireRomtingService = new FireAlarmService.UserServices();
            RoomSensorService fireSenorService = new RoomSensorService();
            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(UserServices), "registerUser", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(UserServices), "viewUsers", WellKnownObjectMode.Singleton);

         
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RoomSensorService), "addRoom", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RoomSensorService), "viewRooms", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RoomSensorService), "assignRoom", WellKnownObjectMode.Singleton);




            Console.WriteLine("Remoting server started @ " + DateTime.Now);
            Console.ReadLine();

        }
    }
}
