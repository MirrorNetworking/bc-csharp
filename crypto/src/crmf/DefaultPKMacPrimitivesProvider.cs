using System;

using Mirror.BouncyCastle.Asn1.X509;
using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Security;

namespace Mirror.BouncyCastle.Crmf
{
    public class DefaultPKMacPrimitivesProvider
        : IPKMacPrimitivesProvider
    {
        public IDigest CreateDigest(AlgorithmIdentifier digestAlg)
        {
            return DigestUtilities.GetDigest(digestAlg.Algorithm);
        }

        public IMac CreateMac(AlgorithmIdentifier macAlg)
        {
            return MacUtilities.GetMac(macAlg.Algorithm);
        }
    }
}
