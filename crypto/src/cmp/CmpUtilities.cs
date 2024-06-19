using Mirror.BouncyCastle.Asn1;
using Mirror.BouncyCastle.Asn1.X509;
using Mirror.BouncyCastle.Operators.Utilities;

namespace Mirror.BouncyCastle.Cmp
{
    internal static class CmpUtilities
    {
        internal static byte[] CalculateCertHash(Asn1Encodable asn1Encodable, AlgorithmIdentifier signatureAlgorithm,
            IDigestAlgorithmFinder digestAlgorithmFinder)
        {
            var digestAlgorithm = digestAlgorithmFinder.Find(signatureAlgorithm)
                ?? throw new CmpException("cannot find digest algorithm from signature algorithm");

            return X509.X509Utilities.CalculateDigest(digestAlgorithm, asn1Encodable);
        }
    }
}
