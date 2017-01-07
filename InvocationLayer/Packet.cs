using InvocationLayer.WinDivert;

namespace InvocationLayer
{
    public class Packet
    {
        public byte[] Payload { get; set; }

        public IpHeader IpHeader { get; set; }
        public TcpHeader TcpHeader { get; set; }
        public UdpHeader UdpHeader { get; set; }
        public IcmpHeader IcmpHeader { get; set; }
        public IpV6Header IpV6Header { get; set; }
        public IcmpV6Header IcmpV6Header { get; set; }

        public bool Inbound { get; set; }

        public bool Outbound => !Inbound;
    }
}
