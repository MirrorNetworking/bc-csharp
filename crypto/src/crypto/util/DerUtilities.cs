using System;

using Mirror.BouncyCastle.Asn1;

namespace Mirror.BouncyCastle.Crypto.Utilities
{
    internal class DerUtilities
    {
        internal static Asn1OctetString GetOctetString(byte[] data)
        {
            byte[] contents = data == null ? Array.Empty<byte>() : (byte[])data.Clone();

            return new DerOctetString(contents);
        }

        internal static byte[] ToByteArray(Asn1Object asn1Object)
        {
            return asn1Object.GetEncoded();
        }
    }
}
