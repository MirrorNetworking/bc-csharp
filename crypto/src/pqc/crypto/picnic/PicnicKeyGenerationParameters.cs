using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Security;

namespace Mirror.BouncyCastle.Pqc.Crypto.Picnic
{
    public class PicnicKeyGenerationParameters
        : KeyGenerationParameters
    {
        private readonly PicnicParameters m_parameters;

        public PicnicKeyGenerationParameters(SecureRandom random, PicnicParameters parameters)
            : base(random, 255)
        {
            m_parameters = parameters;
        }

        public PicnicParameters Parameters => m_parameters;
    }
}
