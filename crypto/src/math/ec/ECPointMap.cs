using System;

namespace Mirror.BouncyCastle.Math.EC
{
    public interface ECPointMap
    {
        ECPoint Map(ECPoint p);
    }
}
