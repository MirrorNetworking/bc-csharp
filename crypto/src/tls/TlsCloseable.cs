using System;
using System.IO;

namespace Mirror.BouncyCastle.Tls
{
    public interface TlsCloseable
    {
        /// <exception cref="IOException"/>
        void Close();
    }
}
