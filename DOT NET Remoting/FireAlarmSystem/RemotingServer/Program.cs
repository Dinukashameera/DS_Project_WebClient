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



            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(UserServices), "assignRoomToUser", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(UserServices), "assignedRooms", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(UserServices), "registerAdmin", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(UserServices), "loginAdmin", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(UserServices), "alertSMS", WellKnownObjectMode.Singleton);



            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RoomSensorService), "addRoom", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RoomSensorService), "viewRooms", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RoomSensorService), "searchRoom", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RoomSensorService), "deleteRoom", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RoomSensorService), "resetRoom", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RoomSensorService), "alert", WellKnownObjectMode.Singleton);


            Console.WriteLine("Remoting server started @ " + DateTime.Now);
            Console.ReadLine();

        }
    }
}
