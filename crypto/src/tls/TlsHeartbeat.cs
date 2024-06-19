using System;

namespace Mirror.BouncyCastle.Tls
{
    public interface TlsHeartbeat
    {
        byte[] GeneratePayload();

        int IdleMillis { get; }

        int TimeoutMillis { get; }
    }
}
