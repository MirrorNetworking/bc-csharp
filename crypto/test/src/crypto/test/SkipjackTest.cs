using System;

using NUnit.Framework;

using Mirror.BouncyCastle.Crypto.Engines;
using Mirror.BouncyCastle.Crypto.Parameters;
using Mirror.BouncyCastle.Utilities.Encoders;
using Mirror.BouncyCastle.Utilities.Test;

namespace Mirror.BouncyCastle.Crypto.Tests
{
    [TestFixture]
    public class SkipjackTest
		: CipherTest
    {
        public override string Name
        {
			get { return "SKIPJACK"; }
        }

        internal static SimpleTest[] tests = new SimpleTest[]{
            new BlockCipherVectorTest(0, new SkipjackEngine(), new KeyParameter(Hex.Decode("00998877665544332211")), "33221100ddccbbaa", "2587cae27a12d300")};

		public SkipjackTest()
			: base(tests, new SkipjackEngine(), new KeyParameter(new byte[16]))
		{
        }

		[Test]
        public void TestFunction()
        {
            string resultText = Perform().ToString();

            Assert.AreEqual(Name + ": Okay", resultText);
        }
    }
}
