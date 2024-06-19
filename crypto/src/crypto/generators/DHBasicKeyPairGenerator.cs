using System;

using Mirror.BouncyCastle.Crypto.Parameters;
using Mirror.BouncyCastle.Math;

namespace Mirror.BouncyCastle.Crypto.Generators
{
    /**
     * a basic Diffie-Hellman key pair generator.
     *
     * This generates keys consistent for use with the basic algorithm for
     * Diffie-Hellman.
     */
    // TODO[api] sealed
    [Obsolete("Use 'DHKeyPairGenerator' instead")]
    public class DHBasicKeyPairGenerator
		: IAsymmetricCipherKeyPairGenerator
    {
        private DHKeyGenerationParameters m_parameters;

        public virtual void Init(KeyGenerationParameters parameters)
        {
            m_parameters = (DHKeyGenerationParameters)parameters;
        }

        public virtual AsymmetricCipherKeyPair GenerateKeyPair()
        {
			DHParameters dhp = m_parameters.Parameters;

			BigInteger x = DHKeyGeneratorHelper.CalculatePrivate(dhp, m_parameters.Random);
			BigInteger y = DHKeyGeneratorHelper.CalculatePublic(dhp, x);

			return new AsymmetricCipherKeyPair(
                new DHPublicKeyParameters(y, dhp),
                new DHPrivateKeyParameters(x, dhp));
        }
    }
}
