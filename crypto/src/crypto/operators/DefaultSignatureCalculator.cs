using System.IO;

using Mirror.BouncyCastle.Crypto.IO;

namespace Mirror.BouncyCastle.Crypto.Operators
{
    // TODO[api] sealed
    public class DefaultSignatureCalculator
        : IStreamCalculator<IBlockResult>
    {
        private readonly SignerSink m_signerSink;

        public DefaultSignatureCalculator(ISigner signer)
        {
            m_signerSink = new SignerSink(signer);
        }

        public Stream Stream => m_signerSink;

        public IBlockResult GetResult() => new DefaultSignatureResult(m_signerSink.Signer);
    }
}
