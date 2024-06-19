using System;

using NUnit.Framework;

/*
 Basic test interface
 */
namespace Mirror.BouncyCastle.Utilities.Test
{
    public interface ITest
    {
        string Name { get; }

		[Test]
        ITestResult Perform();
    }
}
