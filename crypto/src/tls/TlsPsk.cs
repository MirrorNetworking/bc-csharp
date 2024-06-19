using System;

using Mirror.BouncyCastle.Tls.Crypto;

namespace Mirror.BouncyCastle.Tls
{
    public interface TlsPsk
    {
        byte[] Identity { get; }

        TlsSecret Key { get; }

        int PrfAlgorithm { get; }
    }
}
