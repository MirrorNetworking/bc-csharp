using System;

namespace Mirror.BouncyCastle.Tls
{
    /// <summary>Processor interface for a PSK identity.</summary>
    public interface TlsPskIdentity
    {
        void SkipIdentityHint();

        void NotifyIdentityHint(byte[] psk_identity_hint);

        byte[] GetPskIdentity();

        byte[] GetPsk();
    }
}
