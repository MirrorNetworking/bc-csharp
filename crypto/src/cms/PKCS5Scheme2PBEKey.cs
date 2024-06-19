using System;

using Mirror.BouncyCastle.Asn1.Pkcs;
using Mirror.BouncyCastle.Asn1.X509;
using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Crypto.Generators;
using Mirror.BouncyCastle.Crypto.Parameters;

namespace Mirror.BouncyCastle.Cms
{
	/// <summary>
	/// PKCS5 scheme-2 - password converted to bytes assuming ASCII.
	/// </summary>
	public class Pkcs5Scheme2PbeKey
		: CmsPbeKey
	{
		public Pkcs5Scheme2PbeKey(
			char[]	password,
			byte[]	salt,
			int		iterationCount)
			: base(password, salt, iterationCount)
		{
		}

		public Pkcs5Scheme2PbeKey(
			char[]				password,
			AlgorithmIdentifier keyDerivationAlgorithm)
			: base(password, keyDerivationAlgorithm)
		{
		}

#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
        public Pkcs5Scheme2PbeKey(ReadOnlySpan<char> password, ReadOnlySpan<byte> salt, int iterationCount)
            : base(password, salt, iterationCount)
        {
        }

        public Pkcs5Scheme2PbeKey(ReadOnlySpan<char> password, AlgorithmIdentifier keyDerivationAlgorithm)
            : base(password, keyDerivationAlgorithm)
        {
        }
#endif

        internal override KeyParameter GetEncoded(
			string algorithmOid)
		{
			Pkcs5S2ParametersGenerator gen = new Pkcs5S2ParametersGenerator();

			gen.Init(
				PbeParametersGenerator.Pkcs5PasswordToBytes(password),
				salt,
				iterationCount);

			return (KeyParameter) gen.GenerateDerivedParameters(
				algorithmOid,
				CmsEnvelopedHelper.GetKeySize(algorithmOid));
		}
	}
}
