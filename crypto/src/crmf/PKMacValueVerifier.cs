using System;

using Mirror.BouncyCastle.Asn1.Cmp;
using Mirror.BouncyCastle.Asn1.Crmf;
using Mirror.BouncyCastle.Asn1.X509;
using Mirror.BouncyCastle.X509;

namespace Mirror.BouncyCastle.Crmf
{
    internal class PKMacValueVerifier
    {
        private readonly PKMacBuilder m_builder;

        internal PKMacValueVerifier(PKMacBuilder builder)
        {
            m_builder = builder;
        }

#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
        internal virtual bool IsValid(PKMacValue value, ReadOnlySpan<char> password, SubjectPublicKeyInfo keyInfo)
        {
            m_builder.SetParameters(PbmParameter.GetInstance(value.AlgID.Parameters));

            var macFactory = m_builder.Build(password);

            return X509Utilities.VerifyMac(macFactory, keyInfo, value.MacValue);
        }
#else
        internal virtual bool IsValid(PKMacValue value, char[] password, SubjectPublicKeyInfo keyInfo)
        {
            m_builder.SetParameters(PbmParameter.GetInstance(value.AlgID.Parameters));

            var macFactory = m_builder.Build(password);

            return X509Utilities.VerifyMac(macFactory, keyInfo, value.MacValue);
        }
#endif
    }
}
