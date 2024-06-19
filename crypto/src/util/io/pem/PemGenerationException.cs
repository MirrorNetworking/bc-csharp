using System;
using System.Runtime.Serialization;

namespace Mirror.BouncyCastle.Utilities.IO.Pem
{
    [Serializable]
    public class PemGenerationException
		: Exception
	{
		public PemGenerationException()
			: base()
		{
		}

		public PemGenerationException(string message)
			: base(message)
		{
		}

		public PemGenerationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected PemGenerationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
