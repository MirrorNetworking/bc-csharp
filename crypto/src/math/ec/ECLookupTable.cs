using System;

namespace Mirror.BouncyCastle.Math.EC
{
    public interface ECLookupTable
    {
        int Size { get; }
        ECPoint Lookup(int index);
        ECPoint LookupVar(int index);
    }
}
