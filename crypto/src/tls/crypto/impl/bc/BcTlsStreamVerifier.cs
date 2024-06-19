using System;
using System.IO;

using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Crypto.IO;

namespace Mirror.BouncyCastle.Tls.Crypto.Impl.BC
{
    internal sealed class BcTlsStreamVerifier
        : TlsStreamVerifier
    {
        private readonly SignerSink m_output;
        private readonly byte[] m_signature;

        internal BcTlsStreamVerifier(ISigner verifier, byte[] signature)
        {
            this.m_output = new SignerSink(verifier);
            this.m_signature = signature;
        }

        public Stream Stream
        {
            get { return m_output; }
        }

        public bool IsVerified()
        {
            return m_output.Signer.VerifySignature(m_signature);
        }
    }
}
