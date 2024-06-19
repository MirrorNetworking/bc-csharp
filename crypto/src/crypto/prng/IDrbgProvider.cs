using System;

using Mirror.BouncyCastle.Crypto.Prng.Drbg;

namespace Mirror.BouncyCastle.Crypto.Prng
{
    internal interface IDrbgProvider
    {
        ISP80090Drbg Get(IEntropySource entropySource);
    }
}
