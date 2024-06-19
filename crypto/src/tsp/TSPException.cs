using System;
using System.Runtime.Serialization;

namespace Mirror.BouncyCastle.Tsp
{
    [Serializable]
    public class TspException
		: Exception
	{
		public TspException()
			: base()
		{
		}

		public TspException(string message)
			: base(message)
		{
		}

		public TspException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected TspException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
