using System;
using System.Runtime.InteropServices;
using System.Threading;
using InvocationLayer.WinDivert;

namespace InvocationLayer
{
    public class NetworkHandel : IDisposable
    {
        private const int Maxbuf = 0xFFFF;
        private const uint MaxPacketLen = Maxbuf;

        private IntPtr _handle = IntPtr.Zero;
        private Action<NetworkHandel, bool, Packet> _onReceivePacket;

        private Thread _listeningThread;
        private bool _listeningSentinel;

        private NetworkHandel()
        {
            _listeningSentinel = true;
        }

        public void Dispose()
        {
            if (_listeningThread.IsAlive)
            {
                _listeningThread.Abort();
            }

            if (_handle != IntPtr.Zero)
            {
                WinDivertMethods.WinDivertClose(_handle);
            }    
        }

        public static NetworkHandel GetHandle(string filter, DIVERT_LAYER layer, short priority, ulong flags)
        {
            var riverHandle = new NetworkHandel {_handle = WinDivertMethods.WinDivertOpen(filter, layer, priority, flags)};

            WinDivertMethods.WinDivertSetParam(riverHandle._handle, DIVERT_PARAM.WINDIVERT_PARAM_QUEUE_LEN, 8192);

            return riverHandle;
        }

        public NetworkHandel SetParamQueueLen(ulong len)
        {
            WinDivertMethods.WinDivertSetParam(_handle, DIVERT_PARAM.WINDIVERT_PARAM_QUEUE_LEN, len);
            return this;
        }

        public NetworkHandel SetParamQueueTime(ulong time)
        {
            WinDivertMethods.WinDivertSetParam(_handle, DIVERT_PARAM.WINDIVERT_PARAM_QUEUE_TIME, time);
            return this;
        }

        public NetworkHandel SetOnReceive(Action<NetworkHandel, bool, Packet> func)
        {
            _onReceivePacket = func;
            return this;
        }

        public void StartReceive()
        {
            _listeningSentinel = true;
            _listeningThread = new Thread(StartLIsteningInternal);
            _listeningThread.Start();
        }

        public void StopListening()
        {
            _listeningSentinel = false;
            _listeningThread.Join();
        }

        private void StartLIsteningInternal()
        {
            var packetPtr = Marshal.AllocHGlobal(Maxbuf);
            var pAddress = Marshal.AllocHGlobal(Maxbuf);
            var readLength = Marshal.AllocHGlobal(Maxbuf);

            while (_listeningSentinel)
            {
                var state = WinDivertMethods.WinDivertRecv(_handle, packetPtr, MaxPacketLen, pAddress, readLength);

                if (!state)
                {
                    _onReceivePacket(this, false, null);
                }
                else
                {
                    var pkt = PacketBuilder.Build(packetPtr, MaxPacketLen, pAddress, readLength);
                    _onReceivePacket(this, true, pkt);
                }
            }
        }

    }
}
