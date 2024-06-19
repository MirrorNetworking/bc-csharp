using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Security;

namespace Mirror.BouncyCastle.Pqc.Crypto.NtruPrime
{
    public class NtruLPRimeKeyGenerationParameters : KeyGenerationParameters
    {
        private NtruLPRimeParameters _primeParameters;

        public NtruLPRimeKeyGenerationParameters(SecureRandom random, NtruLPRimeParameters ntruPrimeParameters) : base(random,256)
        {
            this._primeParameters = ntruPrimeParameters;
        }

        public NtruLPRimeParameters Parameters => _primeParameters;

    }
}
