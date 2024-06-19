using System;
using System.IO;

using Mirror.BouncyCastle.Tls.Crypto;

namespace Mirror.BouncyCastle.Tls
{
    internal class DigestInputBuffer
        : MemoryStream
    {
        internal void UpdateDigest(TlsHash hash)
        {
            WriteTo(new TlsHashSink(hash));
        }

        /// <exception cref="IOException"/>
        internal void CopyInputTo(Stream output)
        {
            // TODO[tls] Consider defensive copy if 'output' might be external code
            WriteTo(output);
        }
    }
}
