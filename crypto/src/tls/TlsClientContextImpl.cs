using System;

using Mirror.BouncyCastle.Tls.Crypto;

namespace Mirror.BouncyCastle.Tls
{
    internal class TlsClientContextImpl
        : AbstractTlsContext, TlsClientContext
    {
        internal TlsClientContextImpl(TlsCrypto crypto)
            : base(crypto, ConnectionEnd.client)
        {
        }

        public override bool IsServer
        {
            get { return false; }
        }
    }
}
