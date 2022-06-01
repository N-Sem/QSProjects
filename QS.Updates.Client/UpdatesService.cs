using System;
using Grpc.Core;

namespace QS.Updates
{
    public class UpdatesService: IDisposable
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();
        
        public static string ServiceAddress = "updates.cloud.qsolution.ru";
        public static int ServicePort = 4203;

        public UpdatesService()
        {
        }
        
        private Channel channel;
        private Channel Channel {
            get {
                if(channel == null || channel.State == ChannelState.Shutdown)
                    channel = new Channel(ServiceAddress, ServicePort, ChannelCredentials.Insecure);
                if (channel.State == ChannelState.TransientFailure)
                    channel.ConnectAsync();
                return channel;
            }
        }
        
        public void Dispose()
        {
            channel?.ShutdownAsync();
        }
    }
}
