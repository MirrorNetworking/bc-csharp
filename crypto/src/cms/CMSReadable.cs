using System;
using System.IO;

namespace Mirror.BouncyCastle.Cms
{
	public interface CmsReadable
	{
		Stream GetInputStream();
	}
}
