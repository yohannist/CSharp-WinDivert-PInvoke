using System;
using System.Runtime.InteropServices;
using InvocationLayer.WinDivert;

namespace InvocationLayer
{
    public static class PacketBuilder
    {
        internal static Packet Build(IntPtr packetPtr, uint maxPacketLen, IntPtr pAddress, IntPtr readLength)
        {
            var size = Marshal.ReadInt32(readLength);

            var address = (DIVERT_ADDRESS)Marshal.PtrToStructure(pAddress, typeof(DIVERT_ADDRESS));

            var packet = Build(packetPtr, (uint)size);
            packet.Inbound = address.Direction == WinDivertConstants.DIVERT_DIRECTION_INBOUND;
            return packet;
        }


        private static Packet Build(IntPtr packetPtr, uint size)
        {
            var packet = new Packet();

            var ipHdrPointer = IntPtr.Zero;
            var ipv6HdrPointer = IntPtr.Zero;
            var icmpHdrPointer = IntPtr.Zero;
            var tcpHdrPointer = IntPtr.Zero;
            var udpHdrPointer = IntPtr.Zero;
            var icmpv6HdrPointer = IntPtr.Zero;
            var payloadPointer = IntPtr.Zero;
            var payloadLengthPointer = IntPtr.Zero;

            WinDivertMethods.WinDivertHelperParsePacket(packetPtr, size
                                                        , ref ipHdrPointer
                                                        , ref ipv6HdrPointer
                                                        , ref icmpHdrPointer
                                                        , ref icmpv6HdrPointer
                                                        , ref tcpHdrPointer
                                                        , ref udpHdrPointer
                                                        , ref payloadPointer
                                                        , payloadLengthPointer);


            if (ipHdrPointer != IntPtr.Zero)
            {
                var ipHdr = (IpHeader)Marshal.PtrToStructure(ipHdrPointer, typeof(IpHeader));
                packet.IpHeader = ipHdr;
            }

            if (ipv6HdrPointer != IntPtr.Zero)
            {
                var ipv6Hdr = (IpV6Header)Marshal.PtrToStructure(ipv6HdrPointer, typeof(IpV6Header));
                packet.IpV6Header = ipv6Hdr;
            }

            if (icmpHdrPointer != IntPtr.Zero)
            {
                var icmpHdr = (IcmpHeader)Marshal.PtrToStructure(icmpHdrPointer, typeof(IcmpHeader));
                packet.IcmpHeader = icmpHdr;
            }

            if (icmpv6HdrPointer != IntPtr.Zero)
            {
                var icmpV6Hdr = (IcmpV6Header)Marshal.PtrToStructure(icmpv6HdrPointer, typeof(IcmpV6Header));
                packet.IcmpV6Header = icmpV6Hdr;
            }

            if (tcpHdrPointer != IntPtr.Zero)
            {
                var tcpHdr = (TcpHeader)Marshal.PtrToStructure(tcpHdrPointer, typeof(TcpHeader));
                packet.TcpHeader = tcpHdr;
            }

            if (udpHdrPointer != IntPtr.Zero)
            {
                var udpHdr = (UdpHeader)Marshal.PtrToStructure(udpHdrPointer, typeof(UdpHeader));
                packet.UdpHeader = udpHdr;
            }

            if (payloadPointer != IntPtr.Zero && payloadLengthPointer != IntPtr.Zero)
            {
                var payloadLen = Marshal.ReadInt32(payloadLengthPointer);
                var payload = new byte[payloadLen];

                Marshal.Copy(payloadPointer, payload, 0, payloadLen);
                packet.Payload = payload;
            }

            return packet;
        }


    }
}
