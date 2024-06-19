using System;
using System.Runtime.Serialization;

using Mirror.BouncyCastle.Security;

namespace Mirror.BouncyCastle.Pkix
{
    [Serializable]
    public class PkixCertPathBuilderException
		: GeneralSecurityException
	{
		public PkixCertPathBuilderException()
			: base()
		{
		}

		public PkixCertPathBuilderException(string message)
			: base(message)
		{
		}

		public PkixCertPathBuilderException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected PkixCertPathBuilderException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
