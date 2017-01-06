namespace InvocationLayer
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct DIVERT_ADDRESS
    {

        /// UINT32->unsigned int
        public uint IfIdx;

        /// UINT32->unsigned int
        public uint SubIfIdx;

        /// UINT8->unsigned char
        public byte Direction;
    }

    public enum DIVERT_LAYER
    {

        /// WINDIVERT_LAYER_NETWORK -> 0
        WINDIVERT_LAYER_NETWORK = 0,

        /// WINDIVERT_LAYER_NETWORK_FORWARD -> 1
        WINDIVERT_LAYER_NETWORK_FORWARD = 1,
    }

    public enum DIVERT_PARAM
    {

        /// WINDIVERT_PARAM_QUEUE_LEN -> 0
        WINDIVERT_PARAM_QUEUE_LEN = 0,

        /// WINDIVERT_PARAM_QUEUE_TIME -> 1
        WINDIVERT_PARAM_QUEUE_TIME = 1,
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct DIVERT_IPHDR
    {

        /// HdrLength : 4
        ///Version : 4
        public uint bitvector1;

        /// UINT8->unsigned char
        public byte TOS;

        /// UINT16->unsigned short
        public ushort Length;

        /// UINT16->unsigned short
        public ushort Id;

        /// UINT16->unsigned short
        public ushort FragOff0;

        /// UINT8->unsigned char
        public byte TTL;

        /// UINT8->unsigned char
        public byte Protocol;

        /// UINT16->unsigned short
        public ushort Checksum;

        /// UINT32->unsigned int
        public uint SrcAddr;

        /// UINT32->unsigned int
        public uint DstAddr;

        public uint HdrLength
        {
            get
            {
                return ((uint)((this.bitvector1 & 15u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }

        public uint Version
        {
            get
            {
                return ((uint)(((this.bitvector1 & 240u)
                            / 16)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16)
                            | this.bitvector1)));
            }
        }
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct DIVERT_IPV6HDR
    {

        /// TrafficClass0 : 4
        ///Version : 4
        ///FlowLabel0 : 4
        ///TrafficClass1 : 4
        public uint bitvector1;

        /// UINT16->unsigned short
        public ushort FlowLabel1;

        /// UINT16->unsigned short
        public ushort Length;

        /// UINT8->unsigned char
        public byte NextHdr;

        /// UINT8->unsigned char
        public byte HopLimit;

        /// UINT32[4]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = System.Runtime.InteropServices.UnmanagedType.U4)]
        public uint[] SrcAddr;

        /// UINT32[4]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = System.Runtime.InteropServices.UnmanagedType.U4)]
        public uint[] DstAddr;

        public uint TrafficClass0
        {
            get
            {
                return ((uint)((this.bitvector1 & 15u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }

        public uint Version
        {
            get
            {
                return ((uint)(((this.bitvector1 & 240u)
                            / 16)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16)
                            | this.bitvector1)));
            }
        }

        public uint FlowLabel0
        {
            get
            {
                return ((uint)(((this.bitvector1 & 3840u)
                            / 256)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 256)
                            | this.bitvector1)));
            }
        }

        public uint TrafficClass1
        {
            get
            {
                return ((uint)(((this.bitvector1 & 61440u)
                            / 4096)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4096)
                            | this.bitvector1)));
            }
        }
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct DIVERT_ICMPHDR
    {

        /// UINT8->unsigned char
        public byte Type;

        /// UINT8->unsigned char
        public byte Code;

        /// UINT16->unsigned short
        public ushort Checksum;

        /// UINT32->unsigned int
        public uint Body;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct DIVERT_ICMPV6HDR
    {

        /// UINT8->unsigned char
        public byte Type;

        /// UINT8->unsigned char
        public byte Code;

        /// UINT16->unsigned short
        public ushort Checksum;

        /// UINT32->unsigned int
        public uint Body;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct DIVERT_TCPHDR
    {

        /// UINT16->unsigned short
        public ushort SrcPort;

        /// UINT16->unsigned short
        public ushort DstPort;

        /// UINT32->unsigned int
        public uint SeqNum;

        /// UINT32->unsigned int
        public uint AckNum;

        /// Reserved1 : 4
        ///HdrLength : 4
        ///Fin : 1
        ///Syn : 1
        ///Rst : 1
        ///Psh : 1
        ///Ack : 1
        ///Urg : 1
        ///Reserved2 : 2
        public uint bitvector1;

        /// UINT16->unsigned short
        public ushort Window;

        /// UINT16->unsigned short
        public ushort Checksum;

        /// UINT16->unsigned short
        public ushort UrgPtr;

        public uint Reserved1
        {
            get
            {
                return ((uint)((this.bitvector1 & 15u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }

        public uint HdrLength
        {
            get
            {
                return ((uint)(((this.bitvector1 & 240u)
                            / 16)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16)
                            | this.bitvector1)));
            }
        }

        public uint Fin
        {
            get
            {
                return ((uint)(((this.bitvector1 & 256u)
                            / 256)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 256)
                            | this.bitvector1)));
            }
        }

        public uint Syn
        {
            get
            {
                return ((uint)(((this.bitvector1 & 512u)
                            / 512)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 512)
                            | this.bitvector1)));
            }
        }

        public uint Rst
        {
            get
            {
                return ((uint)(((this.bitvector1 & 1024u)
                            / 1024)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 1024)
                            | this.bitvector1)));
            }
        }

        public uint Psh
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2048u)
                            / 2048)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2048)
                            | this.bitvector1)));
            }
        }

        public uint Ack
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4096u)
                            / 4096)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4096)
                            | this.bitvector1)));
            }
        }

        public uint Urg
        {
            get
            {
                return ((uint)(((this.bitvector1 & 8192u)
                            / 8192)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 8192)
                            | this.bitvector1)));
            }
        }

        public uint Reserved2
        {
            get
            {
                return ((uint)(((this.bitvector1 & 49152u)
                            / 16384)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16384)
                            | this.bitvector1)));
            }
        }
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct DIVERT_UDPHDR
    {

        /// UINT16->unsigned short
        public ushort SrcPort;

        /// UINT16->unsigned short
        public ushort DstPort;

        /// UINT16->unsigned short
        public ushort Length;

        /// UINT16->unsigned short
        public ushort Checksum;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct OVERLAPPED
    {

        /// ULONG_PTR->unsigned int
        public uint Internal;

        /// ULONG_PTR->unsigned int
        public uint InternalHigh;

        /// Anonymous_7416d31a_1ce9_4e50_b1e1_0f2ad25c0196
        public Anonymous_7416d31a_1ce9_4e50_b1e1_0f2ad25c0196 Union1;

        /// HANDLE->void*
        public System.IntPtr hEvent;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct Anonymous_7416d31a_1ce9_4e50_b1e1_0f2ad25c0196
    {

        /// Anonymous_ac6e4301_4438_458f_96dd_e86faeeca2a6
        [System.Runtime.InteropServices.FieldOffsetAttribute(0)]
        public Anonymous_ac6e4301_4438_458f_96dd_e86faeeca2a6 Struct1;

        /// PVOID->void*
        [System.Runtime.InteropServices.FieldOffsetAttribute(0)]
        public System.IntPtr Pointer;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct Anonymous_ac6e4301_4438_458f_96dd_e86faeeca2a6
    {

        /// DWORD->unsigned int
        public uint Offset;

        /// DWORD->unsigned int
        public uint OffsetHigh;
    }
}
