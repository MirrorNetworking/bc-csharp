using System;

using Mirror.BouncyCastle.Utilities;

namespace Mirror.BouncyCastle.Bcpg.Sig
{
    public class PolicyUrl
        : SignatureSubpacket
    {
        public PolicyUrl(bool critical, string url)
            : this(critical, false, Strings.ToUtf8ByteArray(url))
        {
        }

        public PolicyUrl(bool critical, bool isLongLength, byte[] data)
            : base(SignatureSubpacketTag.PolicyUrl, critical, isLongLength, data)
        {
        }

        public string Url => Strings.FromUtf8ByteArray(data);

        public byte[] GetRawUrl() => Arrays.Clone(data);
    }
}
