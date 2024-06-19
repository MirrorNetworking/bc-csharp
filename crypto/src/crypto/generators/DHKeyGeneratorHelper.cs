using Mirror.BouncyCastle.Crypto.Parameters;
using Mirror.BouncyCastle.Math;
using Mirror.BouncyCastle.Math.EC.Multiplier;
using Mirror.BouncyCastle.Security;
using Mirror.BouncyCastle.Utilities;

namespace Mirror.BouncyCastle.Crypto.Generators
{
    internal static class DHKeyGeneratorHelper
    {
        internal static BigInteger CalculatePrivate(DHParameters dhParams, SecureRandom	random)
        {
            int limit = dhParams.L;

            if (limit != 0)
            {
                int minWeight = limit >> 2;
                for (;;)
                {
                    BigInteger x = new BigInteger(limit, random).SetBit(limit - 1);
                    if (WNafUtilities.GetNafWeight(x) >= minWeight)
                        return x;
                }
            }

            BigInteger min = BigInteger.Two;
            int m = dhParams.M;
            if (m != 0)
            {
                min = BigInteger.One.ShiftLeft(m - 1);
            }

            BigInteger q = dhParams.Q ?? dhParams.P;
            BigInteger max = q.Subtract(BigInteger.Two);

            {
                int minWeight = max.BitLength >> 2;
                for (;;)
                {
                    BigInteger x = BigIntegers.CreateRandomInRange(min, max, random);
                    if (WNafUtilities.GetNafWeight(x) >= minWeight)
                        return x;
                }
            }
        }

        internal static BigInteger CalculatePublic(DHParameters	dhParams, BigInteger x)
        {
            return dhParams.G.ModPow(x, dhParams.P);
        }
    }
}
