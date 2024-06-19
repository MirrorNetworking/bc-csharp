using System;

using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Crypto.Parameters;
using Mirror.BouncyCastle.Crypto.Signers;

namespace Mirror.BouncyCastle.Tls.Crypto.Impl.BC
{
    /// <summary>Implementation class for generation of the raw ECDSA signature type using the BC light-weight API.
    /// </summary>
    public class BcTlsECDsaSigner
        : BcTlsDssSigner
    {
        public BcTlsECDsaSigner(BcTlsCrypto crypto, ECPrivateKeyParameters privateKey)
            : base(crypto, privateKey)
        {
        }

        protected override IDsa CreateDsaImpl(int cryptoHashAlgorithm)
        {
            return new ECDsaSigner(new HMacDsaKCalculator(m_crypto.CreateDigest(cryptoHashAlgorithm)));
        }

        protected override short SignatureAlgorithm
        {
            get { return Tls.SignatureAlgorithm.ecdsa; }
        }
    }
}
