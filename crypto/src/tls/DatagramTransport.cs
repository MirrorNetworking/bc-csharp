using System;

namespace Mirror.BouncyCastle.Tls
{
    /// <summary>Base interface for an object sending and receiving DTLS data.</summary>
    public interface DatagramTransport
        : DatagramReceiver, DatagramSender, TlsCloseable
    {
    }
}
