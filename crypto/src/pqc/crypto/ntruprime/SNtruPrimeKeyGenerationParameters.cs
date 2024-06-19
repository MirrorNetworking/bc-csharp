using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Security;

namespace Mirror.BouncyCastle.Pqc.Crypto.NtruPrime
{
    public class SNtruPrimeKeyGenerationParameters : KeyGenerationParameters
    {
        private SNtruPrimeParameters _primeParameters;

        public SNtruPrimeKeyGenerationParameters(SecureRandom random, SNtruPrimeParameters ntruPrimeParameters) : base(random,256)
        {
            this._primeParameters = ntruPrimeParameters;
        }

        public SNtruPrimeParameters Parameters => _primeParameters;

    }
}
