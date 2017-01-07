namespace InvocationLayer.WinDivert
{
    public static class WinDivertConstants
    {

        /// __WINDIVERT_H -> 
        /// Error generating expression: Value cannot be null.
        ///Parameter name: node
        public const string @__WINDIVERT_H = "";

        /// WINDIVERTEXPORT -> __declspec(dllimport)
        /// Error generating expression: Error generating function call.  Operation not implemented
        public const string WINDIVERTEXPORT = "__declspec(dllimport)";

        /// WINDIVERT_DIRECTION_OUTBOUND -> 0
        public const int WINDIVERT_DIRECTION_OUTBOUND = 0;

        /// WINDIVERT_DIRECTION_INBOUND -> 1
        public const int WINDIVERT_DIRECTION_INBOUND = 1;

        /// WINDIVERT_FLAG_SNIFF -> 1
        public const int WINDIVERT_FLAG_SNIFF = 1;

        /// WINDIVERT_FLAG_DROP -> 2
        public const int WINDIVERT_FLAG_DROP = 2;

        /// WINDIVERT_FLAG_NO_CHECKSUM -> 1024
        public const int WINDIVERT_FLAG_NO_CHECKSUM = 1024;

        /// WINDIVERT_PARAM_MAX -> WINDIVERT_PARAM_QUEUE_TIME
        public const DIVERT_PARAM WINDIVERT_PARAM_MAX = DIVERT_PARAM.WINDIVERT_PARAM_QUEUE_TIME;

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPHDR_GET_FRAGOFF -> "(hdr) (((hdr)->FragOff0) & 0xFF1F)"
        public const string WINDIVERT_IPHDR_GET_FRAGOFF = "(hdr) (((hdr)->FragOff0) & 0xFF1F)";

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPHDR_GET_MF -> "(hdr) ((((hdr)->FragOff0) & 0x0020) != 0)"
        public const string WINDIVERT_IPHDR_GET_MF = "(hdr) ((((hdr)->FragOff0) & 0x0020) != 0)";

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPHDR_GET_DF -> "(hdr) ((((hdr)->FragOff0) & 0x0040) != 0)"
        public const string WINDIVERT_IPHDR_GET_DF = "(hdr) ((((hdr)->FragOff0) & 0x0040) != 0)";

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPHDR_GET_RESERVED -> "(hdr) ((((hdr)->FragOff0) & 0x0080) != 0)"
        public const string WINDIVERT_IPHDR_GET_RESERVED = "(hdr) ((((hdr)->FragOff0) & 0x0080) != 0)";

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPHDR_SET_FRAGOFF -> "(hdr,val) do                                                      
        ///    {                                                       
        ///        (hdr)->FragOff0 = (((hdr)->FragOff0) & 0x00E0) |    
        ///            ((val) & 0xFF1F);                               
        ///    }                                                       
        ///    while (FALSE)"
        public const string WINDIVERT_IPHDR_SET_FRAGOFF = @"(hdr,val) do                                                      
    {                                                       
        (hdr)->FragOff0 = (((hdr)->FragOff0) & 0x00E0) |    
            ((val) & 0xFF1F);                               
    }                                                       
    while (FALSE)";

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPHDR_SET_MF -> "(hdr,val) do                                                      
        ///    {                                                       
        ///        (hdr)->FragOff0 = (((hdr)->FragOff0) & 0xFFDF) |    
        ///            (((val) & 0x0001) << 5);                        
        ///    }                                                       
        ///    while (FALSE)"
        public const string WINDIVERT_IPHDR_SET_MF = @"(hdr,val) do                                                      
    {                                                       
        (hdr)->FragOff0 = (((hdr)->FragOff0) & 0xFFDF) |    
            (((val) & 0x0001) << 5);                        
    }                                                       
    while (FALSE)";

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPHDR_SET_DF -> "(hdr,val) do                                                      
        ///    {                                                       
        ///        (hdr)->FragOff0 = (((hdr)->FragOff0) & 0xFFBF) |    
        ///            (((val) & 0x0001) << 6);                        
        ///    }                                                       
        ///    while (FALSE)"
        public const string WINDIVERT_IPHDR_SET_DF = @"(hdr,val) do                                                      
    {                                                       
        (hdr)->FragOff0 = (((hdr)->FragOff0) & 0xFFBF) |    
            (((val) & 0x0001) << 6);                        
    }                                                       
    while (FALSE)";

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPHDR_SET_RESERVED -> "(hdr,val) do                                                      
        ///    {                                                       
        ///        (hdr)->FragOff0 = (((hdr)->FragOff0) & 0xFF7F) |    
        ///            (((val) & 0x0001) << 7);                        
        ///    }                                                       
        ///    while (FALSE)"
        public const string WINDIVERT_IPHDR_SET_RESERVED = @"(hdr,val) do                                                      
    {                                                       
        (hdr)->FragOff0 = (((hdr)->FragOff0) & 0xFF7F) |    
            (((val) & 0x0001) << 7);                        
    }                                                       
    while (FALSE)";

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPV6HDR_GET_TRAFFICCLASS -> "(hdr) ((((hdr)->TrafficClass0) << 4) | ((hdr)->TrafficClass1))"
        public const string WINDIVERT_IPV6HDR_GET_TRAFFICCLASS = "(hdr) ((((hdr)->TrafficClass0) << 4) | ((hdr)->TrafficClass1))";

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPV6HDR_GET_FLOWLABEL -> "(hdr) ((((UINT32)(hdr)->FlowLabel0) << 16) | ((UINT32)(hdr)->FlowLabel1))"
        public const string WINDIVERT_IPV6HDR_GET_FLOWLABEL = "(hdr) ((((UINT32)(hdr)->FlowLabel0) << 16) | ((UINT32)(hdr)->FlowLabel1))";

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPV6HDR_SET_TRAFFICCLASS -> "(hdr,val) do                                                      
        ///    {                                                       
        ///        (hdr)->TrafficClass0 = ((UINT8)(val) >> 4);         
        ///        (hdr)->TrafficClass1 = (UINT8)(val);                
        ///    }                                                       
        ///    while (FALSE)"
        public const string WINDIVERT_IPV6HDR_SET_TRAFFICCLASS = @"(hdr,val) do                                                      
    {                                                       
        (hdr)->TrafficClass0 = ((UINT8)(val) >> 4);         
        (hdr)->TrafficClass1 = (UINT8)(val);                
    }                                                       
    while (FALSE)";

        /// Warning: Generation of Method Macros is not supported at this time
        /// WINDIVERT_IPV6HDR_SET_FLOWLABEL -> "(hdr,val) do                                                      
        ///    {                                                       
        ///        (hdr)->FlowLabel0 = (UINT8)((val) >> 16);           
        ///        (hdr)->FlowLabel1 = (UINT16)(val);                  
        ///    }                                                       
        ///    while (FALSE)"
        public const string WINDIVERT_IPV6HDR_SET_FLOWLABEL = @"(hdr,val) do                                                      
    {                                                       
        (hdr)->FlowLabel0 = (UINT8)((val) >> 16);           
        (hdr)->FlowLabel1 = (UINT16)(val);                  
    }                                                       
    while (FALSE)";

        /// WINDIVERT_HELPER_NO_IP_CHECKSUM -> 1
        public const int WINDIVERT_HELPER_NO_IP_CHECKSUM = 1;

        /// WINDIVERT_HELPER_NO_ICMP_CHECKSUM -> 2
        public const int WINDIVERT_HELPER_NO_ICMP_CHECKSUM = 2;

        /// WINDIVERT_HELPER_NO_ICMPV6_CHECKSUM -> 4
        public const int WINDIVERT_HELPER_NO_ICMPV6_CHECKSUM = 4;

        /// WINDIVERT_HELPER_NO_TCP_CHECKSUM -> 8
        public const int WINDIVERT_HELPER_NO_TCP_CHECKSUM = 8;

        /// WINDIVERT_HELPER_NO_UDP_CHECKSUM -> 16
        public const int WINDIVERT_HELPER_NO_UDP_CHECKSUM = 16;

        /// DIVERT_DIRECTION_OUTBOUND -> WINDIVERT_DIRECTION_OUTBOUND
        public const int DIVERT_DIRECTION_OUTBOUND = WinDivertConstants.WINDIVERT_DIRECTION_OUTBOUND;

        /// DIVERT_DIRECTION_INBOUND -> WINDIVERT_DIRECTION_INBOUND
        public const int DIVERT_DIRECTION_INBOUND = WinDivertConstants.WINDIVERT_DIRECTION_INBOUND;

        /// DIVERT_FLAG_SNIFF -> WINDIVERT_FLAG_SNIFF
        public const int DIVERT_FLAG_SNIFF = WinDivertConstants.WINDIVERT_FLAG_SNIFF;

        /// DIVERT_FLAG_DROP -> WINDIVERT_FLAG_DROP
        public const int DIVERT_FLAG_DROP = WinDivertConstants.WINDIVERT_FLAG_DROP;

        /// DIVERT_HELPER_NO_IP_CHECKSUM -> WINDIVERT_HELPER_NO_IP_CHECKSUM
        public const int DIVERT_HELPER_NO_IP_CHECKSUM = WinDivertConstants.WINDIVERT_HELPER_NO_IP_CHECKSUM;

        /// DIVERT_HELPER_NO_ICMP_CHECKSUM -> WINDIVERT_HELPER_NO_ICMP_CHECKSUM
        public const int DIVERT_HELPER_NO_ICMP_CHECKSUM = WinDivertConstants.WINDIVERT_HELPER_NO_ICMP_CHECKSUM;

        /// DIVERT_HELPER_NO_ICMPV6_CHECKSUM -> WINDIVERT_HELPER_NO_ICMPV6_CHECKSUM
        public const int DIVERT_HELPER_NO_ICMPV6_CHECKSUM = WinDivertConstants.WINDIVERT_HELPER_NO_ICMPV6_CHECKSUM;

        /// DIVERT_HELPER_NO_TCP_CHECKSUM -> WINDIVERT_HELPER_NO_TCP_CHECKSUM
        public const int DIVERT_HELPER_NO_TCP_CHECKSUM = WinDivertConstants.WINDIVERT_HELPER_NO_TCP_CHECKSUM;

        /// DIVERT_HELPER_NO_UDP_CHECKSUM -> WINDIVERT_HELPER_NO_UDP_CHECKSUM
        public const int DIVERT_HELPER_NO_UDP_CHECKSUM = WinDivertConstants.WINDIVERT_HELPER_NO_UDP_CHECKSUM;
    }

}
