using System;

using Mirror.BouncyCastle.Asn1.X509;
using Mirror.BouncyCastle.Crypto.Parameters;

namespace Mirror.BouncyCastle.Cms
{
	internal interface CmsSecureReadable
	{
		AlgorithmIdentifier Algorithm { get; }
		object CryptoObject { get; }
		CmsReadable GetReadable(KeyParameter key);
	}
}
