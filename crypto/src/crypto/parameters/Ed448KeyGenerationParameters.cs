using System;

using Mirror.BouncyCastle.Security;

namespace Mirror.BouncyCastle.Crypto.Parameters
{
    public class Ed448KeyGenerationParameters
        : KeyGenerationParameters
    {
        public Ed448KeyGenerationParameters(SecureRandom random)
            : base(random, 448)
        {
        }
    }
}
