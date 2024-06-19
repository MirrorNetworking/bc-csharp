using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Utilities;

namespace Mirror.BouncyCastle.Pqc.Crypto.Lms
{
    public abstract class LmsKeyParameters
        : AsymmetricKeyParameter, IEncodable
    {
        internal LmsKeyParameters(bool isPrivateKey)
            : base(isPrivateKey)
        {
        }

        public abstract byte[] GetEncoded();
    }
}
