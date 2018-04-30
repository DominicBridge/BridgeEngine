using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.Network
{
    public class SendPacket
    {

        string packet;
        private string header;
        public SendPacket(string header, params string[] data)
        {
            Encode(header, data);
            this.header = header;
        }        

        public void Encode(string header, string[] data)
        {
            string temp = header + (char)2;

            foreach (string str in data)
            {
                temp += str + (char)2;
            }


            temp = temp.Remove(temp.Length - 1);
            temp += (char)1;
            packet = VL64Encode(temp.Length) + temp;
        }

        public String VL64Encode(int i)
        {
            byte[] wf = new byte[6];
            int pos = 0;
            int startPos = pos;
            int bytes = 1;
            int negativeMask = i >= 0 ? 0 : 4;
            i = Math.Abs(i);
            wf[pos++] = (byte)(64 + (i & 3));
            for (i >>= 2; i != 0; i >>= 6)
            {
                bytes++;
                wf[pos++] = (byte)(64 + (i & 0x3f));
            }

            wf[startPos] = (byte)(wf[startPos] | bytes << 3 | negativeMask);
            String tmp = Encoding.UTF8.GetString(wf);
            return tmp.Replace("\0", "");
        }

        public override string ToString()
        {
            return packet;
        }

        public void Send(ConnectionManager connectionManager)
        {
            connectionManager.SendData(packet);            
        }
    }
}
