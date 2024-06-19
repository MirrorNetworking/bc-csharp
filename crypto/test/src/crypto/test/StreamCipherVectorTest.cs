using System;

using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Utilities;
using Mirror.BouncyCastle.Utilities.Test;
using Mirror.BouncyCastle.Utilities.Encoders;

namespace Mirror.BouncyCastle.Crypto.Tests
{
    /**
     * a basic test that takes a stream cipher, key parameter, and an input
     * and output string.
     */
    public class StreamCipherVectorTest: SimpleTest
    {
        int                 id;
        IStreamCipher       cipher;
        ICipherParameters    param;
        byte[]              input;
        byte[]              output;

        public StreamCipherVectorTest(
            int                 id,
            IStreamCipher       cipher,
            ICipherParameters    param,
            string              input,
            string              output)
        {
            this.id = id;
            this.cipher = cipher;
            this.param = param;
            this.input = Hex.Decode(input);
            this.output = Hex.Decode(output);
        }

		public override string Name
		{
			get { return cipher.AlgorithmName + " Vector Test " + id; }
		}

		public override void PerformTest()
        {
            cipher.Init(true, param);

            byte[] outBytes = new byte[input.Length];

            cipher.ProcessBytes(input, 0, input.Length, outBytes, 0);

            if (!Arrays.AreEqual(outBytes, output))
            {
                Fail("failed - "
					+ "expected " + Hex.ToHexString(output)
					+ " got " + Hex.ToHexString(outBytes));
            }

            cipher.Init(false, param);

            cipher.ProcessBytes(output, 0, output.Length, outBytes, 0);

            if (!Arrays.AreEqual(input, outBytes))
            {
                Fail("failed reversal");
            }
        }
    }
}
