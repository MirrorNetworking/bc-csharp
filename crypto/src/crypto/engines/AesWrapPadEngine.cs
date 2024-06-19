using System;

namespace Mirror.BouncyCastle.Crypto.Engines
{
    public class AesWrapPadEngine
        : Rfc5649WrapEngine
    {
        public AesWrapPadEngine()
            : base(AesUtilities.CreateEngine())
        {
        }
    }
}
