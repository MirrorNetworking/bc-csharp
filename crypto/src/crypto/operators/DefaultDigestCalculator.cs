using System.IO;

using Mirror.BouncyCastle.Crypto.IO;

namespace Mirror.BouncyCastle.Crypto.Operators
{
    public sealed class DefaultDigestCalculator
        : IStreamCalculator<IBlockResult>
    {
        private readonly DigestSink m_digestSink;

        public DefaultDigestCalculator(IDigest digest)
        {
            m_digestSink = new DigestSink(digest);
        }

        public Stream Stream => m_digestSink;

        public IBlockResult GetResult() => new DefaultDigestResult(m_digestSink.Digest);
    }
}
