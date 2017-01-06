using System;
using System.Net;
using System.Runtime.InteropServices;
using InvocationLayer;

namespace Indirection
{
    public class Program
    {
        private const int Maxbuf = 0xFFFF;
        private const uint MaxPacketLen = Maxbuf;


        static void Main(string[] args)
        {
            var packet = Marshal.AllocHGlobal(Maxbuf);
            var pAddress = Marshal.AllocHGlobal(Maxbuf);
            var readLength = Marshal.AllocHGlobal(Maxbuf);

            /*
                int _ipHdrSize, _icmpSize, _udpSize, _tcpSize;

                unsafe
                {
                    _ipHdrSize = sizeof(IpHeader);
                    _icmpSize = sizeof(IcmpHeader);
                    _tcpSize = sizeof(TcpHeader);
                    _udpSize = sizeof(UdpHeader);
                }
            */
            Console.CancelKeyPress += (o, e) =>
            {
                Console.ForegroundColor = ConsoleColor.White;    
            };

            var handle = WinDivertMethods
                .WinDivertOpen("true", DIVERT_LAYER.WINDIVERT_LAYER_NETWORK,
                0, WinDivertConstants.DIVERT_FLAG_SNIFF);

            WinDivertMethods.WinDivertSetParam(handle, DIVERT_PARAM.WINDIVERT_PARAM_QUEUE_LEN, 8192);
         
            
            while (true)
            {
                var value = WinDivertMethods.WinDivertRecv(handle, packet, MaxPacketLen, pAddress, readLength);
                if (value == false)
                    continue;

                var size = Marshal.ReadInt32(readLength);

                var address = (DIVERT_ADDRESS) Marshal.PtrToStructure(pAddress, typeof (DIVERT_ADDRESS));

                if (address.Direction == WinDivertConstants.DIVERT_DIRECTION_INBOUND)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("<".PadRight(120, '-'));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(">".PadLeft(120, '-'));
                }
                /*byte[] managedArray = new byte[size];
                Marshal.Copy(packet, managedArray, 0, size);
                Console.WriteLine("Packet read on " + handle + "  " + readLength + " " + _pAddress + Convert.ToBase64String(managedArray));
                */
                ParsePacket(packet, (uint)size);


            }
        }

        private static void ParsePacket(IntPtr packet, uint size)
        {
            var ipHdrPointer = IntPtr.Zero;
            var ipv6HdrPointer = IntPtr.Zero;
            var icmpHdrPointer = IntPtr.Zero;
            var tcpHdrPointer = IntPtr.Zero;
            var udpHdrPointer = IntPtr.Zero;
            var icmpv6HdrPointer = IntPtr.Zero;
            var dataHdrPointer = IntPtr.Zero;
            var lenHdrPointer = IntPtr.Zero;

            WinDivertMethods.WinDivertHelperParsePacket(packet, size
                                                        , ref ipHdrPointer
                                                        , ref ipv6HdrPointer
                                                        , ref icmpHdrPointer
                                                        , ref icmpv6HdrPointer
                                                        , ref tcpHdrPointer
                                                        , ref udpHdrPointer
                                                        , ref dataHdrPointer
                                                        , lenHdrPointer);


            if (ipHdrPointer != IntPtr.Zero)
            {
                var ipHdr = (IpHeader)Marshal.PtrToStructure(ipHdrPointer, typeof(IpHeader));

                var sourceIpAddress = new IPAddress(BitConverter.GetBytes(ipHdr.SrcAddr)).ToString();
                var destinationIpAddress = new IPAddress(BitConverter.GetBytes(ipHdr.DstAddr)).ToString();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("IP Source IP: {0} Destination IP: {1}", sourceIpAddress, destinationIpAddress);
            }

            if (icmpHdrPointer != IntPtr.Zero)
            {
                var icmpHdr = (IcmpHeader)Marshal.PtrToStructure(icmpHdrPointer, typeof(IcmpHeader));
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                
                Console.WriteLine("ICMP Type: {0}, Code: {1}, Body: {2}", icmpHdr.Type, icmpHdr.Code, icmpHdr.Body);
            }

            if (tcpHdrPointer != IntPtr.Zero)
            {
                var tcpHdr = (TcpHeader)Marshal.PtrToStructure(tcpHdrPointer, typeof(TcpHeader));
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("TCP Source Port: {0} Destination Port: {1}, Sequence Number: {2}, Acknowledgement Number: {3}", tcpHdr.SrcPort.ToString().PadRight(5), tcpHdr.DstPort.ToString().PadRight(5), tcpHdr.SeqNum.ToString().PadRight(5), tcpHdr.AckNum.ToString().PadRight(5));
                
            }

            if (udpHdrPointer != IntPtr.Zero)
            {
                var udpHdr = (UdpHeader)Marshal.PtrToStructure(udpHdrPointer, typeof(UdpHeader));
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("UDP Source Port: {0} Destination Port: {1}, Length: {2}, Checksum: {3}", udpHdr.SrcPort.ToString().PadRight(5), udpHdr.DstPort.ToString().PadRight(5), udpHdr.Length, udpHdr.Checksum);
            }
        }
    }
}
