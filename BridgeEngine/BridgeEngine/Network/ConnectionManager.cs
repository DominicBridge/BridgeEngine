using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace BridgeEngine.Network
{
    public class ConnectionManager : Module
    {
        public static string name = "ConnectionManager";
        private Socket socket;

        private ConnectionStatus connectionStatus;
        private int port;
        private string ip;

        private Guid guid;
        public ConnectionManager(bool enabled, int port, string ip) : base(name)
        {
            this.port = port;
            this.ip = ip;
            connectionStatus = ConnectionStatus.WAITING;
         
            if (enabled)
            {
                Connect();
            }
        }

        public void Connect()
        {
            Connect(port, ip);
        }

        public void Connect(int port, string ip)
        {
            connectionStatus = ConnectionStatus.ATTEMPTINGTOCONNECT;
            DnsEndPoint endPoint = new DnsEndPoint(ip, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            SocketAsyncEventArgs args = new SocketAsyncEventArgs
            {
                UserToken = socket,
                RemoteEndPoint = endPoint
            };
            args.Completed += OnSocketCompleted;

            try
            {
                socket.ConnectAsync(args);
            }
            catch (SocketException ex)
            {
                connectionStatus = ConnectionStatus.CONNECTIONFAILURE;
                throw new SocketException(ex.ErrorCode);
            }
       
        }

        public void Disconnect()
        {
            if (socket.Connected)
            {
                socket.Disconnect(true);
            }
        }
        private void OnSocketCompleted(object sender, SocketAsyncEventArgs e)
        {
            if(e.SocketError == SocketError.Success)
            {
                byte[] response = new byte[2048];
                e.SetBuffer(response, 0, response.Length);
                e.Completed -= new EventHandler<SocketAsyncEventArgs>(OnSocketCompleted);
                e.Completed += onReceiveData; //new EventHandler<SocketAsyncEventArgs>(onSocketReceive);
                connectionStatus = ConnectionStatus.CONNECTED;
                Socket socket = (Socket)e.UserToken;
                socket.ReceiveAsync(e);
                this.socket = socket;
            }
            else
            {
                connectionStatus = ConnectionStatus.CONNECTIONFAILURE;
            }
        }

        public EventHandler<SocketAsyncEventArgs> onReceiveData;

        public void SendData(string toSend)
        {
            try
            {
                if (socket.Connected)
                {
                    byte[] byteData = System.Text.Encoding.UTF8.GetBytes(toSend);
                    SocketAsyncEventArgs tosend = new SocketAsyncEventArgs();
                    tosend.SetBuffer(byteData, 0, byteData.Length);
                    socket.SendAsync(tosend);
                }
            }
            catch
            {
                connectionStatus = ConnectionStatus.DISCONNECTED;
            }
        }
        public void SetSocket(Socket socket)
        {
            this.socket = socket;
        }

        public override void Draw(SpriteBatch spriteBatch) { }

        public override void Update(GameTime gameTime) { }

        public ConnectionStatus GetConnectionStatus()
        {
            return connectionStatus;
        }

        public void SendPacket(SendPacket packet)
        {
            string str = packet.ToString();
            SendData(str);
        }

        public Guid GetGuid()
        {
            return guid;
        }

        public void SetGuid(String guid)
        {
            this.guid = Guid.Parse(guid);
        }
    }

    public class ConnectionStatus
    {
        public static readonly ConnectionStatus WAITING = new ConnectionStatus("Waiting. . .");
        public static readonly ConnectionStatus ATTEMPTINGTOCONNECT = new ConnectionStatus("Attempting to Connect!");
        public static readonly ConnectionStatus CONNECTED = new ConnectionStatus("Connected");
        public static readonly ConnectionStatus DISCONNECTED = new ConnectionStatus("Disconnected");
        public static readonly ConnectionStatus CONNECTIONFAILURE = new ConnectionStatus("Connection failure!");


        public static IEnumerable<ConnectionStatus> Values
        {
            get
            {
                yield return WAITING;
                yield return ATTEMPTINGTOCONNECT;
                yield return CONNECTED;
                yield return DISCONNECTED;
                yield return CONNECTIONFAILURE;
            }
        }

        private readonly string message;

        ConnectionStatus(string message)
        {
            this.message = message;
        }

        public String GetMessage()
        {
            return message;
        }
    }
}