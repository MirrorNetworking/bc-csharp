using System;
using System.Collections.Generic;

using NUnit.Framework;

using Mirror.BouncyCastle.Asn1.X9;
using Mirror.BouncyCastle.Crypto.EC;
using Mirror.BouncyCastle.Math.EC.Multiplier;
using Mirror.BouncyCastle.Security;
using Mirror.BouncyCastle.Utilities.Collections;

namespace Mirror.BouncyCastle.Math.EC.Tests
{
    [TestFixture]
    public class FixedPointTest
    {
        private static readonly SecureRandom Random = new SecureRandom();

        private const int TestsPerCurve = 5;

        [Test]
        public void TestFixedPointMultiplier()
        {
            FixedPointCombMultiplier M = new FixedPointCombMultiplier();

            var names = new List<string>();
            names.AddRange(ECNamedCurveTable.Names);
            names.AddRange(CustomNamedCurves.Names);

            var uniqNames = new HashSet<string>(names);

            foreach (string name in uniqNames)
            {
                X9ECParameters x9A = ECNamedCurveTable.GetByName(name);
                X9ECParameters x9B = CustomNamedCurves.GetByName(name);

                X9ECParameters x9 = x9B ?? x9A;

                for (int i = 0; i < TestsPerCurve; ++i)
                {
                    BigInteger k = new BigInteger(x9.N.BitLength, Random);
                    ECPoint pRef = ECAlgorithms.ReferenceMultiply(x9.G, k);

                    if (x9A != null)
                    {
                        ECPoint pA = M.Multiply(x9A.G, k);
                        AssertPointsEqual("Standard curve fixed-point failure", pRef, pA);
                    }

                    if (x9B != null)
                    {
                        ECPoint pB = M.Multiply(x9B.G, k);
                        AssertPointsEqual("Custom curve fixed-point failure", pRef, pB);
                    }
                }
            }
        }

        private void AssertPointsEqual(string message, ECPoint a, ECPoint b)
        {
            // NOTE: We intentionally test points for equality in both directions
            Assert.AreEqual(a, b, message);
            Assert.AreEqual(b, a, message);
        }
    }
}
