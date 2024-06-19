using System;
using System.IO;

using Mirror.BouncyCastle.Asn1;
using Mirror.BouncyCastle.Asn1.X509;
using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Crypto.Parameters;
using Mirror.BouncyCastle.Security;
using Mirror.BouncyCastle.Utilities.Date;
using Mirror.BouncyCastle.Utilities.IO;

namespace Mirror.BouncyCastle.Cms
{
	public class CmsAuthenticatedGenerator
		: CmsEnvelopedGenerator
	{
		public CmsAuthenticatedGenerator()
		{
		}

        /// <summary>Constructor allowing specific source of randomness</summary>
        /// <param name="random">Instance of <c>SecureRandom</c> to use.</param>
        public CmsAuthenticatedGenerator(SecureRandom random)
			: base(random)
		{
		}
	}
}
