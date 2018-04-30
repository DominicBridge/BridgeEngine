using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.Network
{
    public class ReceivedData : EventArgs
    {
        private string Received;

        public ReceivedData(string Data)
        {
            Received = Data;
        }

        public string Data
        {
            get { return Received; }
        }
    }

    public class Connection
    {
        private TcpClient Sock;
        private NetworkStream SockStream;
        private const int BufferSize = 8192;
        private Byte[] Buffer = new byte[BufferSize];
        private StringBuilder sb = new StringBuilder();

        private bool isConnected = false;

        public EventHandler OnDisconnect, OnConnect;
        public EventHandler<ReceivedData> OnReceive;

        public Connection()
        {
            Sock = new TcpClient();
        }

        public Connection(TcpClient sock)
        {
            this.Sock = sock;
            this.isConnected = true;
            this.SockStream = this.Sock.GetStream();
            SockStream.BeginRead(Buffer, 0, BufferSize, new AsyncCallback(DataReceived), Sock);
        }

        public Connection(Socket sock)
        {
            Sock = new TcpClient();
            this.Sock.Client = sock;
            this.isConnected = true;
            this.SockStream = Sock.GetStream();
            this.SockStream.BeginRead(Buffer, 0, BufferSize, new AsyncCallback(DataReceived), Sock);
        }

        public string Server
        {
            get
            {
                if (this.Sock == null)
                {
                    return ""; //If not set, return nothing
                }
                else
                {
                    return ((IPEndPoint)Sock.Client.RemoteEndPoint).Address.ToString();
                }
            }
        }

        public int Port
        {
            get
            {
                if (this.Sock == null)
                {
                    return -1;
                }
                else
                {
                    return ((IPEndPoint)Sock.Client.RemoteEndPoint).Port;
                }
            }
        }

        private void Received(string Data)
        {
            OnReceive?.Invoke(this, new ReceivedData(Data));
        }


        public void Write(string Data)
        {
            if (isConnected)
                if (SockStream != null)
                    if (SockStream.CanWrite)
                    {
                        byte[] Send = Encoding.ASCII.GetBytes(Data);
                        SockStream.Write(Send, 0, Send.Length);
                    }
        }

        public void Connect(string Location, int Port)
        {
            AsyncCallback callback = new AsyncCallback(ClientConnected);
            Sock.BeginConnect(Location, Port, callback, null);
        }

        private void ClientConnected(IAsyncResult callbackVars)
        {
            isConnected = true;
            SockStream = Sock.GetStream();

            SockStream.BeginRead(Buffer, 0, BufferSize, new AsyncCallback(DataReceived), Sock);

            OnConnect?.Invoke(this, new EventArgs());
        }

        private void DataReceived(IAsyncResult callbackVars)
        {
            int BytesRead = 0;

            try
            {
                BytesRead = SockStream.EndRead(callbackVars);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }


            if (BytesRead > 0)
            {
                sb.Append(Encoding.ASCII.GetString(Buffer, 0, BytesRead));

                while (SockStream.DataAvailable)
                {
                    SockStream.BeginRead(Buffer, 0, BufferSize, new AsyncCallback(DataReceived), Sock);
                }

                if (sb.Length > 0)
                {
                    Received(sb.ToString());
                    sb.Length = 0;
                }
            }
            else
            {
                OnDisconnect?.Invoke(this, new EventArgs());
                return;
            }

            try
            {
                SockStream.BeginRead(Buffer, 0, BufferSize, new AsyncCallback(DataReceived), Sock);
            }
            catch (SocketException ex) {            
               //messagebox.show("SocketException[" + ex.SocketErrorCode + "] encountered in Connection class: " + ex.Message);
            }
            catch (System.IO.IOException ex)
            {
                throw new System.IO.IOException();
            }
        }

        internal void Close()
        {           
            Sock.Close();

            SockStream.Close();

            OnDisconnect?.Invoke(this, new EventArgs());

            return;
        }

    }
}
