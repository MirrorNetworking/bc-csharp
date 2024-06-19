using System;

namespace Mirror.BouncyCastle.Crypto.Modes.Gcm
{
	[Obsolete("Will be removed")]
	public interface IGcmMultiplier
	{
		void Init(byte[] H);
		void MultiplyH(byte[] x);
	}
}
