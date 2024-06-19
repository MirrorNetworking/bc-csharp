using System;

namespace Mirror.BouncyCastle.Utilities.Test
{
    public interface ITestResult
    {
        bool IsSuccessful();

        Exception GetException();

        string ToString();
    }
}
