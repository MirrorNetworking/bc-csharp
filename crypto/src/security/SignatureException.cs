using System;
using System.Runtime.Serialization;

namespace Mirror.BouncyCastle.Security
{
    [Serializable]
    public class SignatureException
		: GeneralSecurityException
	{
		public SignatureException()
			: base()
		{
		}

		public SignatureException(string message)
			: base(message)
		{
		}

		public SignatureException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected SignatureException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
