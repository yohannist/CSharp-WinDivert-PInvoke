using System;
using System.Net;
using InvocationLayer;
using InvocationLayer.WinDivert;

namespace NetworkVisualization
{
    class Program
    {
        static void Main(string[] args)
        {
            using (
                var riverHanlde = NetworkHandel.GetHandle("true", DIVERT_LAYER.WINDIVERT_LAYER_NETWORK, 0,
                    WinDivertConstants.DIVERT_FLAG_SNIFF))
            {
                riverHanlde.SetOnReceive(OnPacketReceive);

                riverHanlde.StartReceive();
                Console.Read();
            }
        }

        private static void OnPacketReceive(NetworkHandel handle, bool captureSuccess, Packet packet)
        {
            if (!captureSuccess)
            {
                return;
            }
            
            if (packet.IpHeader.HasValue)
            {
                var sourceIpAddress = new IPAddress(BitConverter.GetBytes(packet.IpHeader.Value.SrcAddr)).ToString();
                var destinationIpAddress = new IPAddress(BitConverter.GetBytes(packet.IpHeader.Value.DstAddr)).ToString();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("IP Source IP: {0} Destination IP: {1}", sourceIpAddress, destinationIpAddress);
            }

            if (packet.IcmpHeader.HasValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("ICMP Type: {0}, Code: {1}, Body: {2}", packet.IcmpHeader.Value.Type, packet.IcmpHeader.Value.Code, packet.IcmpHeader.Value.Body);
            }

            if (packet.TcpHeader.HasValue)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("TCP Source Port: {0} Destination Port: {1}, Sequence Number: {2}, Acknowledgement Number: {3}", packet.TcpHeader.Value.SrcPort.ToString().PadRight(5), packet.TcpHeader.Value.DstPort.ToString().PadRight(5), packet.TcpHeader.Value.SeqNum.ToString().PadRight(5), packet.TcpHeader.Value.AckNum.ToString().PadRight(5));

            }

            if (packet.UdpHeader.HasValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("UDP Source Port: {0} Destination Port: {1}, Length: {2}, Checksum: {3}", packet.UdpHeader.Value.SrcPort.ToString().PadRight(5), packet.UdpHeader.Value.DstPort.ToString().PadRight(5), packet.UdpHeader.Value.Length, packet.UdpHeader.Value.Checksum);
            }
        }
    }
}
