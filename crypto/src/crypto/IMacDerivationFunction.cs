namespace Mirror.BouncyCastle.Crypto
{
    public interface IMacDerivationFunction
        : IDerivationFunction
    {
        IMac Mac { get; }
    }
}
