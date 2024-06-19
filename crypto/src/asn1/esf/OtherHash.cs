using System;

using Mirror.BouncyCastle.Asn1.Oiw;
using Mirror.BouncyCastle.Asn1.X509;

namespace Mirror.BouncyCastle.Asn1.Esf
{
    /// <remarks>
    /// <code>
    /// OtherHash ::= CHOICE {
    ///		sha1Hash	OtherHashValue, -- This contains a SHA-1 hash
    /// 	otherHash	OtherHashAlgAndValue
    ///	}
    ///
    ///	OtherHashValue ::= OCTET STRING
    /// </code>
    /// </remarks>
    public class OtherHash
		: Asn1Encodable, IAsn1Choice
	{
        public static OtherHash GetInstance(object obj)
        {
            if (obj == null)
                return null;
            if (obj is OtherHash otherHash)
                return otherHash;
            if (obj is Asn1OctetString asn1OctetString)
                return new OtherHash(asn1OctetString);
            return new OtherHash(OtherHashAlgAndValue.GetInstance(obj));
        }

        public static OtherHash GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
        {
            return Asn1Utilities.GetInstanceFromChoice(taggedObject, declaredExplicit, GetInstance);
        }

        private readonly Asn1OctetString m_sha1Hash;
        private readonly OtherHashAlgAndValue m_otherHash;

        public OtherHash(byte[] sha1Hash)
		{
			if (sha1Hash == null)
				throw new ArgumentNullException(nameof(sha1Hash));

			m_sha1Hash = new DerOctetString(sha1Hash);
		}

		public OtherHash(Asn1OctetString sha1Hash)
		{
			m_sha1Hash = sha1Hash ?? throw new ArgumentNullException(nameof(sha1Hash));
		}

		public OtherHash(OtherHashAlgAndValue otherHash)
		{
			m_otherHash = otherHash ?? throw new ArgumentNullException(nameof(otherHash));
        }

		public AlgorithmIdentifier HashAlgorithm =>
			m_otherHash?.HashAlgorithm ?? new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1);

		public byte[] GetHashValue() => m_otherHash?.GetHashValue() ?? m_sha1Hash.GetOctets();

		public override Asn1Object ToAsn1Object() => m_otherHash?.ToAsn1Object() ?? m_sha1Hash;
	}
}
