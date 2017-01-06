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
                    _ipHdrSize = sizeof(DIVERT_IPHDR);
                    _icmpSize = sizeof(DIVERT_ICMPHDR);
                    _tcpSize = sizeof(DIVERT_TCPHDR);
                    _udpSize = sizeof(DIVERT_UDPHDR);
                }
            */

            var handle = WinDivertMethods
                .WinDivertOpen("true", DIVERT_LAYER.WINDIVERT_LAYER_NETWORK,
                0, WinDivertConstants.DIVERT_FLAG_SNIFF);

            WinDivertMethods.WinDivertSetParam(handle, DIVERT_PARAM.WINDIVERT_PARAM_QUEUE_LEN, 8192);

            while (true)
            {
                var value = WinDivertMethods.WinDivertRecv(handle, packet, MaxPacketLen, pAddress, readLength);
                if (value == false)
                    continue;


                int size = Marshal.ReadInt32(readLength);

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
                var ipHdr = (DIVERT_IPHDR)Marshal.PtrToStructure(ipHdrPointer, typeof(DIVERT_IPHDR));

                var sourceIpAddress = new IPAddress(BitConverter.GetBytes(ipHdr.SrcAddr)).ToString();
                var destinationIpAddress = new IPAddress(BitConverter.GetBytes(ipHdr.DstAddr)).ToString();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("IP Source IP: {0} Destination IP: {1}", sourceIpAddress, destinationIpAddress);
            }

            if (icmpHdrPointer != IntPtr.Zero)
            {
                var icmpHdr = (DIVERT_ICMPHDR)Marshal.PtrToStructure(icmpHdrPointer, typeof(DIVERT_ICMPHDR));
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("ICMP Type: {0}, Code: {1}, Body: {2}", icmpHdr.Type, icmpHdr.Code, icmpHdr.Body);
            }

            if (tcpHdrPointer != IntPtr.Zero)
            {
                var tcpHdr = (DIVERT_TCPHDR)Marshal.PtrToStructure(tcpHdrPointer, typeof(DIVERT_TCPHDR));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("TCP Source Port: {0} Destination Port: {1}, Sequence Number: {2}, Acknowledgement Number: {3}", tcpHdr.SrcPort, tcpHdr.DstPort, tcpHdr.SeqNum, tcpHdr.AckNum);
            }

            if (udpHdrPointer != IntPtr.Zero)
            {
                var udpHdr = (DIVERT_UDPHDR)Marshal.PtrToStructure(udpHdrPointer, typeof(DIVERT_UDPHDR));
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("UDP Source Port: {0} Destination Port: {1}, Length: {2}, Checksum: {3}", udpHdr.SrcPort, udpHdr.DstPort, udpHdr.Length, udpHdr.Checksum);
            }
        }
    }
}
