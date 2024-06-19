using System;

using Mirror.BouncyCastle.Asn1.X509;
using Mirror.BouncyCastle.Crypto;

namespace Mirror.BouncyCastle.Crmf
{
    public interface IPKMacPrimitivesProvider
    {
	    IDigest CreateDigest(AlgorithmIdentifier digestAlg);

        IMac CreateMac(AlgorithmIdentifier macAlg);
    }
}
