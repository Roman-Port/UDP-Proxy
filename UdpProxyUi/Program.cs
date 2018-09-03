using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace UdpProxyUi
{
    static class Program
    {
        static MainView view;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            view = new MainView();
            

            

            Application.Run(view);
        }

        public static void StartProxy()
        {
            //Start proxy
            //A proxy for TCP.
            //Captures data.
            //Create server
            proxyServer = new UdpClient(new IPEndPoint(IPAddress.Any, proxy_port));
            //Connect to the remote server.
            remoteServer = new UdpClient();
            remoteServer.Connect(dest, remoteserver_port);
            //We've connected to the remote server.
            //Subscribe to events coming from both.
            proxyServer.BeginReceive(new AsyncCallback(OnClientSentData), null);
            remoteServer.BeginReceive(new AsyncCallback(OnServerSentData), null);
        }

        public const int BUFFER_SIZE = 1;

        public static UdpClient proxyServer;
        public static UdpClient remoteServer;
        public static IPEndPoint client;

        public static int proxy_port = 4649;
        public static int remoteserver_port = 7790;
        public static IPAddress dest = IPAddress.Parse("52.209.23.207");

        //Buffers
        public static byte[] client_rec_buffer = new byte[BUFFER_SIZE];
        public static byte[] server_rec_buffer = new byte[BUFFER_SIZE];

        static void OnClientSentData(IAsyncResult ar)
        {
            //For proxyServer
            IPEndPoint endpoint = null;
            byte[] data = proxyServer.EndReceive(ar, ref endpoint);
            //Resubscribe
            proxyServer.BeginReceive(new AsyncCallback(OnClientSentData), null);
            //We now know the endpoint.
            client = endpoint;
            //Echo this to the server.
            remoteServer.Send(data, data.Length);
            //Console
            view.AddItemToPacketList(new Packet(PacketSource.Client, data, DateTime.Now));
        }

        static void OnServerSentData(IAsyncResult ar)
        {
            //For remoteServer  
            IPEndPoint endpoint = null;
            byte[] data = remoteServer.EndReceive(ar, ref endpoint);
            //Resubscribe
            remoteServer.BeginReceive(new AsyncCallback(OnServerSentData), null);
            //Echo this to the client.
            proxyServer.Send(data, data.Length, client);
            //Console
            view.AddItemToPacketList(new Packet(PacketSource.RemoteServer, data, DateTime.Now));
        }
    }
}
