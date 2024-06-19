using Mirror.BouncyCastle.Crypto;

namespace Mirror.BouncyCastle.Pqc.Crypto.Crystals.Kyber
{
    public abstract class KyberKeyParameters
        : AsymmetricKeyParameter
    {
        private readonly KyberParameters m_parameters;

        internal KyberKeyParameters(bool isPrivate, KyberParameters parameters)
            : base(isPrivate)
        {
            m_parameters = parameters;
        }

        public KyberParameters Parameters => m_parameters;
    }
}
