using System;

using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Security;

namespace Mirror.BouncyCastle.Pqc.Crypto.Sike
{
    [Obsolete("Will be removed")]
    public sealed class SikeKeyGenerationParameters
        : KeyGenerationParameters
    {
        private readonly SikeParameters m_parameters;

        public SikeKeyGenerationParameters(SecureRandom random, SikeParameters sikeParameters)
            : base(random, 256)
        {
            m_parameters = sikeParameters;
        }

        public SikeParameters Parameters => m_parameters;
    }
}
