using Mirror.BouncyCastle.Crypto.Engines;

namespace Mirror.BouncyCastle.Crypto
{
    public static class AesUtilities
    {
        public static IBlockCipher CreateEngine()
        {
#if NETCOREAPP3_0_OR_GREATER
            if (IsHardwareAccelerated)
                return new AesEngine_X86();
#endif

            return new AesEngine();
        }

#if NETCOREAPP3_0_OR_GREATER
        public static bool IsHardwareAccelerated => AesEngine_X86.IsSupported;
#else
        public static bool IsHardwareAccelerated => false;
#endif
    }
}
