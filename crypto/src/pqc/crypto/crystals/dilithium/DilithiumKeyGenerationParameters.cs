using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Security;

namespace Mirror.BouncyCastle.Pqc.Crypto.Crystals.Dilithium
{
    public class DilithiumKeyGenerationParameters
        : KeyGenerationParameters
    {
        private DilithiumParameters parameters;

        public DilithiumKeyGenerationParameters(SecureRandom random, DilithiumParameters parameters) : base(random, 255)
        {
            this.parameters = parameters;
        }

        public DilithiumParameters Parameters => parameters;
    }
}