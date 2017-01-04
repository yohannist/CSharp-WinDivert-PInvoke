namespace InvocationLayer
{
    public class WinDivertMethods
    {

        /// Return Type: HANDLE->void*
        ///filter: char*
        ///layer: WINDIVERT_LAYER->Anonymous_7ee85760_8c9f_47ec_983d_ea7fb647add9
        ///priority: INT16->short
        ///flags: UINT64->unsigned __int64
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertOpen")]
        public static extern System.IntPtr WinDivertOpen([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string filter, DIVERT_LAYER layer, short priority, ulong flags);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_7d636a21_3ea2_49af_b953_46fab44882e8*
        ///readLen: UINT*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertRecv")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool WinDivertRecv([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle, System.IntPtr pPacket, uint packetLen, System.IntPtr pAddr, System.IntPtr readLen);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///flags: UINT64->unsigned __int64
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_7d636a21_3ea2_49af_b953_46fab44882e8*
        ///readLen: UINT*
        ///lpOverlapped: LPOVERLAPPED->_OVERLAPPED*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertRecvEx")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool WinDivertRecvEx([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle, System.IntPtr pPacket, uint packetLen, ulong flags, System.IntPtr pAddr, System.IntPtr readLen, System.IntPtr lpOverlapped);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_7d636a21_3ea2_49af_b953_46fab44882e8*
        ///writeLen: UINT*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertSend")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool WinDivertSend([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle, [System.Runtime.InteropServices.InAttribute()] System.IntPtr pPacket, uint packetLen, [System.Runtime.InteropServices.InAttribute()] ref DIVERT_ADDRESS pAddr, System.IntPtr writeLen);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///flags: UINT64->unsigned __int64
        ///pAddr: PWINDIVERT_ADDRESS->Anonymous_7d636a21_3ea2_49af_b953_46fab44882e8*
        ///writeLen: UINT*
        ///lpOverlapped: LPOVERLAPPED->_OVERLAPPED*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertSendEx")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool WinDivertSendEx([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle, [System.Runtime.InteropServices.InAttribute()] System.IntPtr pPacket, uint packetLen, ulong flags, [System.Runtime.InteropServices.InAttribute()] ref DIVERT_ADDRESS pAddr, System.IntPtr writeLen, System.IntPtr lpOverlapped);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertClose")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool WinDivertClose([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///param: WINDIVERT_PARAM->Anonymous_5949f4c0_2bd7_4e4b_8867_f576755625e1
        ///value: UINT64->unsigned __int64
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertSetParam")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool WinDivertSetParam([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle, DIVERT_PARAM param, ulong value);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///param: WINDIVERT_PARAM->Anonymous_5949f4c0_2bd7_4e4b_8867_f576755625e1
        ///pValue: UINT64*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertGetParam")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool WinDivertGetParam([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle, DIVERT_PARAM param, [System.Runtime.InteropServices.OutAttribute()] out ulong pValue);


        /// Return Type: BOOL->int
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///ppIpHdr: PWINDIVERT_IPHDR*
        ///ppIpv6Hdr: PWINDIVERT_IPV6HDR*
        ///ppIcmpHdr: PWINDIVERT_ICMPHDR*
        ///ppIcmpv6Hdr: PWINDIVERT_ICMPV6HDR*
        ///ppTcpHdr: PWINDIVERT_TCPHDR*
        ///ppUdpHdr: PWINDIVERT_UDPHDR*
        ///ppData: PVOID*
        ///pDataLen: UINT*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertHelperParsePacket")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool WinDivertHelperParsePacket([System.Runtime.InteropServices.InAttribute()] System.IntPtr pPacket, uint packetLen, ref System.IntPtr ppIpHdr, ref System.IntPtr ppIpv6Hdr, ref System.IntPtr ppIcmpHdr, ref System.IntPtr ppIcmpv6Hdr, ref System.IntPtr ppTcpHdr, ref System.IntPtr ppUdpHdr, ref System.IntPtr ppData, System.IntPtr pDataLen);


        /// Return Type: BOOL->int
        ///addrStr: char*
        ///pAddr: UINT32*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertHelperParseIPv4Address")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool WinDivertHelperParseIPv4Address([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string addrStr, System.IntPtr pAddr);


        /// Return Type: BOOL->int
        ///addrStr: char*
        ///pAddr: UINT32*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertHelperParseIPv6Address")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool WinDivertHelperParseIPv6Address([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string addrStr, System.IntPtr pAddr);


        /// Return Type: UINT->unsigned int
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///flags: UINT64->unsigned __int64
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "WinDivertHelperCalcChecksums")]
        public static extern uint WinDivertHelperCalcChecksums(System.IntPtr pPacket, uint packetLen, ulong flags);


        /// Return Type: HANDLE->void*
        ///filter: char*
        ///layer: DIVERT_LAYER->WINDIVERT_LAYER->Anonymous_7ee85760_8c9f_47ec_983d_ea7fb647add9
        ///priority: INT16->short
        ///flags: UINT64->unsigned __int64
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "DivertOpen")]
        public static extern System.IntPtr DivertOpen([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string filter, DIVERT_LAYER layer, short priority, ulong flags);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///pAddr: PDIVERT_ADDRESS->PWINDIVERT_ADDRESS->Anonymous_7d636a21_3ea2_49af_b953_46fab44882e8*
        ///readLen: UINT*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "DivertRecv")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool DivertRecv([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle, System.IntPtr pPacket, uint packetLen, System.IntPtr pAddr, System.IntPtr readLen);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///pAddr: PDIVERT_ADDRESS->PWINDIVERT_ADDRESS->Anonymous_7d636a21_3ea2_49af_b953_46fab44882e8*
        ///writeLen: UINT*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "DivertSend")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool DivertSend([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle, [System.Runtime.InteropServices.InAttribute()] System.IntPtr pPacket, uint packetLen, [System.Runtime.InteropServices.InAttribute()] ref DIVERT_ADDRESS pAddr, System.IntPtr writeLen);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "DivertClose")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool DivertClose([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///param: DIVERT_PARAM->WINDIVERT_PARAM->Anonymous_5949f4c0_2bd7_4e4b_8867_f576755625e1
        ///value: UINT64->unsigned __int64
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "DivertSetParam")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool DivertSetParam([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle, DIVERT_PARAM param, ulong value);


        /// Return Type: BOOL->int
        ///handle: HANDLE->void*
        ///param: DIVERT_PARAM->WINDIVERT_PARAM->Anonymous_5949f4c0_2bd7_4e4b_8867_f576755625e1
        ///pValue: UINT64*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "DivertGetParam")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool DivertGetParam([System.Runtime.InteropServices.InAttribute()] System.IntPtr handle, DIVERT_PARAM param, [System.Runtime.InteropServices.OutAttribute()] out ulong pValue);


        /// Return Type: BOOL->int
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///ppIpHdr: PDIVERT_IPHDR*
        ///ppIpv6Hdr: PDIVERT_IPV6HDR*
        ///ppIcmpHdr: PDIVERT_ICMPHDR*
        ///ppIcmpv6Hdr: PDIVERT_ICMPV6HDR*
        ///ppTcpHdr: PDIVERT_TCPHDR*
        ///ppUdpHdr: PDIVERT_UDPHDR*
        ///ppData: PVOID*
        ///pDataLen: UINT*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "DivertHelperParsePacket")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool DivertHelperParsePacket([System.Runtime.InteropServices.InAttribute()] System.IntPtr pPacket, uint packetLen, ref System.IntPtr ppIpHdr, ref System.IntPtr ppIpv6Hdr, ref System.IntPtr ppIcmpHdr, ref System.IntPtr ppIcmpv6Hdr, ref System.IntPtr ppTcpHdr, ref System.IntPtr ppUdpHdr, ref System.IntPtr ppData, System.IntPtr pDataLen);


        /// Return Type: BOOL->int
        ///addrStr: char*
        ///pAddr: UINT32*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "DivertHelperParseIPv4Address")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool DivertHelperParseIPv4Address([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string addrStr, System.IntPtr pAddr);


        /// Return Type: BOOL->int
        ///addrStr: char*
        ///pAddr: UINT32*
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "DivertHelperParseIPv6Address")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool DivertHelperParseIPv6Address([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string addrStr, System.IntPtr pAddr);


        /// Return Type: UINT->unsigned int
        ///pPacket: PVOID->void*
        ///packetLen: UINT->unsigned int
        ///flags: UINT64->unsigned __int64
        [System.Runtime.InteropServices.DllImportAttribute("WinDivert.dll", EntryPoint = "DivertHelperCalcChecksums")]
        public static extern uint DivertHelperCalcChecksums(System.IntPtr pPacket, uint packetLen, ulong flags);

    }

}
