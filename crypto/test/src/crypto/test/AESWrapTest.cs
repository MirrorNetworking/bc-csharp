using System;

using NUnit.Framework;

using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Crypto.Engines;
using Mirror.BouncyCastle.Crypto.Parameters;
using Mirror.BouncyCastle.Utilities;
using Mirror.BouncyCastle.Utilities.Encoders;
using Mirror.BouncyCastle.Utilities.Test;

namespace Mirror.BouncyCastle.Crypto.Tests
{
	/**
	* Wrap Test
	*/
	[TestFixture]
	public class AesWrapTest
		: ITest
	{
		public string Name
		{
			get
			{
				return "AESWrap";
			}
		}

        private ITestResult WrapTest(int id, byte[] kek, byte[] inBytes, byte[] outBytes)
        {
            return WrapTest(id, kek, inBytes, outBytes, false);
        }

        private ITestResult WrapTest(int id, byte[] kek, byte[] inBytes, byte[] outBytes, bool useReverseDirection)
		{
			IWrapper wrapper = new AesWrapEngine(useReverseDirection);

			wrapper.Init(true, new KeyParameter(kek));

			try
			{
				byte[]  cText = wrapper.Wrap(inBytes, 0, inBytes.Length);
				if (!Arrays.AreEqual(cText, outBytes))
				{
					return new SimpleTestResult(false, Name + ": failed wrap test " + id
						+ " expected " + Hex.ToHexString(outBytes)
						+ " got " + Hex.ToHexString(cText));
				}
			}
			catch (Exception e)
			{
				return new SimpleTestResult(false, Name + ": failed wrap test exception " + e);
			}

			wrapper.Init(false, new KeyParameter(kek));

			try
			{
				byte[]  pText = wrapper.Unwrap(outBytes, 0, outBytes.Length);
				if (!Arrays.AreEqual(pText, inBytes))
				{
					return new SimpleTestResult(false, Name + ": failed unwrap test " + id
						+ " expected " + Hex.ToHexString(inBytes)
						+ " got " + Hex.ToHexString(pText));
				}
			}
			catch (Exception e)
			{
				return new SimpleTestResult(false, Name + ": failed unwrap test exception.", e);
			}

			return new SimpleTestResult(true, Name + ": Okay");
		}

		public ITestResult Perform()
		{
			byte[]  kek1 = Hex.Decode("000102030405060708090a0b0c0d0e0f");
			byte[]  in1 = Hex.Decode("00112233445566778899aabbccddeeff");
			byte[]  out1 = Hex.Decode("1fa68b0a8112b447aef34bd8fb5a7b829d3e862371d2cfe5");
			ITestResult result = WrapTest(1, kek1, in1, out1);

			if (!result.IsSuccessful())
			{
				return result;
			}

			byte[]  kek2 = Hex.Decode("000102030405060708090a0b0c0d0e0f1011121314151617");
			byte[]  in2 = Hex.Decode("00112233445566778899aabbccddeeff");
			byte[]  out2 = Hex.Decode("96778b25ae6ca435f92b5b97c050aed2468ab8a17ad84e5d");
			result = WrapTest(2, kek2, in2, out2);
			if (!result.IsSuccessful())
			{
				return result;
			}

			byte[]  kek3 = Hex.Decode("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
			byte[]  in3 = Hex.Decode("00112233445566778899aabbccddeeff");
			byte[]  out3 = Hex.Decode("64e8c3f9ce0f5ba263e9777905818a2a93c8191e7d6e8ae7");
			result = WrapTest(3, kek3, in3, out3);
			if (!result.IsSuccessful())
			{
				return result;
			}

			byte[]  kek4 = Hex.Decode("000102030405060708090a0b0c0d0e0f1011121314151617");
			byte[]  in4 = Hex.Decode("00112233445566778899aabbccddeeff0001020304050607");
			byte[]  out4 = Hex.Decode("031d33264e15d33268f24ec260743edce1c6c7ddee725a936ba814915c6762d2");
			result = WrapTest(4, kek4, in4, out4);
			if (!result.IsSuccessful())
			{
				return result;
			}

			byte[]  kek5 = Hex.Decode("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
			byte[]  in5 = Hex.Decode("00112233445566778899aabbccddeeff0001020304050607");
			byte[]  out5 = Hex.Decode("a8f9bc1612c68b3ff6e6f4fbe30e71e4769c8b80a32cb8958cd5d17d6b254da1");
			result = WrapTest(5, kek5, in5, out5);
			if (!result.IsSuccessful())
			{
				return result;
			}

			byte[]  kek6 = Hex.Decode("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
			byte[]  in6 = Hex.Decode("00112233445566778899aabbccddeeff000102030405060708090a0b0c0d0e0f");
			byte[]  out6 = Hex.Decode("28c9f404c4b810f4cbccb35cfb87f8263f5786e2d80ed326cbc7f0e71a99f43bfb988b9b7a02dd21");
			result = WrapTest(6, kek6, in6, out6);
			if (!result.IsSuccessful())
			{
				return result;
			}

            byte[] kek7 = Hex.Decode("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
            byte[] in7 = Hex.Decode("00112233445566778899aabbccddeeff000102030405060708090a0b0c0d0e0f");
            byte[] out7 = Hex.Decode("cba01acbdb4c7c39fa59babb383c485f318837208731a81c735b5be6ba710375a1159e26a9b57228");
            result = WrapTest(7, kek7, in7, out7, true);
            if (!result.IsSuccessful())
            {
                return result;
            }

            // Example of 64-bit input (which uses a simplified wrapping algorithm)
            byte[] kek8 = Hex.Decode("574957151fc2afe0fa3dc7a9a7da6495");
            byte[] in8 = Hex.Decode("0001020304050607");
            byte[] out8 = Hex.Decode("6f0b501f1f2f59e3ae605aa679ce43a6");
            result = WrapTest(8, kek8, in8, out8);
            if (!result.IsSuccessful())
            {
                return result;
            }

            IWrapper wrapper = new AesWrapEngine();
			KeyParameter key = new KeyParameter(new byte[16]);
			byte[]       buf = new byte[16];

			try
			{
				wrapper.Init(true, key);

				wrapper.Unwrap(buf, 0, buf.Length);

				return new SimpleTestResult(false, Name + ": failed unwrap state test.");
			}
			catch (InvalidOperationException)
			{
				// expected
			}
			catch (InvalidCipherTextException e)
			{
				return new SimpleTestResult(false, Name + ": unexpected exception: " + e, e);
			}

			try
			{
				wrapper.Init(false, key);

				wrapper.Wrap(buf, 0, buf.Length);

				return new SimpleTestResult(false, Name + ": failed unwrap state test.");
			}
			catch (InvalidOperationException)
			{
				// expected
			}

			//
			// short tests
			//
			try
			{
				wrapper.Init(false, key);

				wrapper.Unwrap(buf, 0, 0);

				return new SimpleTestResult(false, Name + ": failed unwrap short test 1.");
			}
			catch (InvalidCipherTextException)
			{
				// expected
			}
            try
            {
                wrapper.Init(false, key);

                wrapper.Unwrap(buf, 0, buf.Length / 2);

                return new SimpleTestResult(false, Name + ": failed unwrap short test 2.");
            }
            catch (InvalidCipherTextException)
            {
                // expected
            }

            try
            {
				wrapper.Init(true, key);

				wrapper.Wrap(buf, 0, 15);

				return new SimpleTestResult(false, Name + ": failed wrap length test.");
			}
			catch (DataLengthException)
			{
				// expected
			}

			return new SimpleTestResult(true, Name + ": Okay");
		}

		[Test]
		public void TestFunction()
		{
			string resultText = Perform().ToString();

			Assert.AreEqual(Name + ": Okay", resultText);
		}
	}
}
