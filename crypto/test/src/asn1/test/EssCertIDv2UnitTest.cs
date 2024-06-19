using System;

using NUnit.Framework;

using Mirror.BouncyCastle.Asn1;
using Mirror.BouncyCastle.Asn1.Ess;
using Mirror.BouncyCastle.Asn1.Nist;
using Mirror.BouncyCastle.Asn1.X509;

namespace Mirror.BouncyCastle.Asn1.Tests
{
    [TestFixture]
	public class EssCertIDv2UnitTest
	: Asn1UnitTest
	{
		public override string Name
		{
			get { return "ESSCertIDv2"; }
		}

		public override void PerformTest()
		{
			// check GetInstance on default algorithm.
			byte[] digest = new byte[32];
			EssCertIDv2 essCertIdv2 = new EssCertIDv2(
				new AlgorithmIdentifier(NistObjectIdentifiers.IdSha256), digest);
			Asn1Object asn1Object = essCertIdv2.ToAsn1Object();

			EssCertIDv2.GetInstance(asn1Object);
		}

		[Test]
        public void TestFunction()
        {
            string resultText = Perform().ToString();

            Assert.AreEqual(Name + ": Okay", resultText);
        }
	}
}
