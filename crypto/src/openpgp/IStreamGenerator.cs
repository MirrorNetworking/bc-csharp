using System;

namespace Mirror.BouncyCastle.Bcpg.OpenPgp
{
	public interface IStreamGenerator
	{
		[Obsolete("Dispose any opened Stream directly")]
		void Close();
	}
}
