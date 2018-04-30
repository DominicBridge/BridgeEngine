using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.Network
{
    public abstract class ReceivedPacket
    {
        protected string header;
        protected BridgeEngine bridgeEngine;

        public ReceivedPacket(BridgeEngine bridgeEngine, string header)
        {
            this.bridgeEngine = bridgeEngine;

            this.header = header;
        }

        public abstract void OnReceived(string[] received);
            
        public virtual string GetHeader() { return header; }
    }
}
