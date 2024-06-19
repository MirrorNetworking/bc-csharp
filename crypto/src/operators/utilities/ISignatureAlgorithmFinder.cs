using Mirror.BouncyCastle.Asn1.X509;

namespace Mirror.BouncyCastle.Operators.Utilities
{
    public interface ISignatureAlgorithmFinder
    {
        AlgorithmIdentifier Find(string signatureName);
    }
}
