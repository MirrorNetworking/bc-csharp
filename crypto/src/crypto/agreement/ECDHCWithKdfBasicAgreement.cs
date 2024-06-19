using System;

using Mirror.BouncyCastle.Asn1;
using Mirror.BouncyCastle.Crypto.Agreement.Kdf;
using Mirror.BouncyCastle.Math;
using Mirror.BouncyCastle.Security;
using Mirror.BouncyCastle.Utilities;

namespace Mirror.BouncyCastle.Crypto.Agreement
{
    public sealed class ECDHCWithKdfBasicAgreement
        : ECDHCBasicAgreement
    {
        private readonly string m_algorithm;
        private readonly IDerivationFunction m_kdf;

        public ECDHCWithKdfBasicAgreement(string algorithm, IDerivationFunction kdf)
        {
            m_algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
            m_kdf = kdf ?? throw new ArgumentNullException(nameof(kdf));
        }

        public override BigInteger CalculateAgreement(ICipherParameters pubKey)
        {
            BigInteger result = base.CalculateAgreement(pubKey);

            return BasicAgreementWithKdf.CalculateAgreementWithKdf(m_algorithm, m_kdf, GetFieldSize(), result);
        }
    }
}
