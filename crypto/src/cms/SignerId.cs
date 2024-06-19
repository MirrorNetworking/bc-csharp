using System;

using Mirror.BouncyCastle.Utilities;
using Mirror.BouncyCastle.X509.Store;

namespace Mirror.BouncyCastle.Cms
{
    // TODO[api] sealed
    public class SignerID
        : X509CertStoreSelector, IEquatable<SignerID>
    {
        public virtual bool Equals(SignerID other)
        {
            return other == null ? false
                :  other == this ? true
                :  MatchesSubjectKeyIdentifier(other)
                && MatchesSerialNumber(other)
                && MatchesIssuer(other);
        }

        public override bool Equals(object obj) => Equals(obj as SignerID);

        public override int GetHashCode()
        {
            return GetHashCodeOfSubjectKeyIdentifier()
                ^  Objects.GetHashCode(SerialNumber)
                ^  Objects.GetHashCode(Issuer);
        }
    }
}
