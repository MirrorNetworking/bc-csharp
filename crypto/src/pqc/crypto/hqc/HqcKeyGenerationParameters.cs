using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Security;

namespace Mirror.BouncyCastle.Pqc.Crypto.Hqc
{
    public class HqcKeyGenerationParameters : KeyGenerationParameters
    {
        private HqcParameters param;

        public HqcKeyGenerationParameters(
            SecureRandom random,
            HqcParameters param) : base(random, 256)
            {
                this.param = param;
            }

            public HqcParameters Parameters => param;
        }
}
