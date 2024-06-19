using System;

using NUnit.Framework;

using Mirror.BouncyCastle.Security;
using Mirror.BouncyCastle.Crypto.Digests;
using Mirror.BouncyCastle.Crypto.Engines;
using Mirror.BouncyCastle.Crypto.Paddings;
using Mirror.BouncyCastle.Crypto.Parameters;
using Mirror.BouncyCastle.Utilities.Encoders;
using Mirror.BouncyCastle.Utilities.Test;

namespace Mirror.BouncyCastle.Crypto.Tests
{
	[TestFixture]
	public class ShortenedDigestTest : SimpleTest
	{
		public override void PerformTest()
		{
			IDigest  d = new Sha1Digest();
			ShortenedDigest sd = new ShortenedDigest(new Sha1Digest(), 10);

			if (sd.GetDigestSize() != 10)
			{
				Fail("size check wrong for SHA-1");
			}

			if (sd.GetByteLength() != d.GetByteLength())
			{
				Fail("byte length check wrong for SHA-1");
			}

			//
			// check output fits
			//
			sd.DoFinal(new byte[10], 0);

			d = new Sha512Digest();
			sd = new ShortenedDigest(new Sha512Digest(), 20);

			if (sd.GetDigestSize() != 20)
			{
				Fail("size check wrong for SHA-512");
			}

			if (sd.GetByteLength() != d.GetByteLength())
			{
				Fail("byte length check wrong for SHA-512");
			}

			//
			// check output fits
			//
			sd.DoFinal(new byte[20], 0);

			try
			{
				new ShortenedDigest(null, 20);

				Fail("null parameter not caught");
			}
			catch (ArgumentException)
			{
				// expected
			}

			try
			{
				new ShortenedDigest(new Sha1Digest(), 50);

				Fail("short digest not caught");
			}
			catch (ArgumentException)
			{
				// expected
			}

			DigestTest.SpanConsistencyTests(this, new ShortenedDigest(new Sha1Digest(), 10));
		}

		public override string Name
		{
			get { return "ShortenedDigest"; }
		}

		[Test]
		public void TestFunction()
		{
			string resultText = Perform().ToString();

			Assert.AreEqual(Name + ": Okay", resultText);
		}
	}
}