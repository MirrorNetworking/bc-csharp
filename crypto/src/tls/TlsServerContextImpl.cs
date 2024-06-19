using System;

using Mirror.BouncyCastle.Tls.Crypto;

namespace Mirror.BouncyCastle.Tls
{
    internal class TlsServerContextImpl
        : AbstractTlsContext, TlsServerContext
    {
        internal TlsServerContextImpl(TlsCrypto crypto)
            : base(crypto, ConnectionEnd.server)
        {
        }

        public override bool IsServer
        {
            get { return true; }
        }
    }
}
