using System;
using System.Runtime.InteropServices;
using InvocationLayer;

namespace Indirection
{
    public class Program
    {
        private const int MAXBUF = 0xFFFF;

        private static IntPtr packet = Marshal.AllocHGlobal(MAXBUF);
        private static IntPtr pAddress = Marshal.AllocHGlobal(MAXBUF);

        private static IntPtr readLength = Marshal.AllocHGlobal(MAXBUF);

        static UInt32 packet_len = MAXBUF;

        static void Main(string[] args)
        {
   
        var handle  = WinDivertMethods
                .WinDivertOpen("true", DIVERT_LAYER.WINDIVERT_LAYER_NETWORK,
                0, WinDivertConstants.DIVERT_FLAG_SNIFF);

            WinDivertMethods.WinDivertSetParam(handle, DIVERT_PARAM.WINDIVERT_PARAM_QUEUE_LEN, 8192);

            while (true)
            {
                var value = WinDivertMethods.WinDivertRecv(handle, packet, packet_len, pAddress, readLength);
                if (value == false)
                    continue;

                int size = Marshal.ReadInt32(readLength);
                byte[] managedArray = new byte[size];
                Marshal.Copy(packet, managedArray, 0, size);

                Console.WriteLine("Packet read on " + handle + "  " + readLength + " " + pAddress + Convert.ToBase64String(managedArray));
               
                //4 Console.ReadKey();
            }
        }
    }
    /*
    
    HANDLE WinDivertOpen(
    __in const char *filter,
    __in WINDIVERT_LAYER layer,
    __in INT16 priority,
    __in UINT64 flags
); 

     */
}
