using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemotingClient
{
    public static class GlobalVariables
    {
        public static TcpChannel RegisterChannel()
        {
            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel);

            return channel;
        }
    }
}
