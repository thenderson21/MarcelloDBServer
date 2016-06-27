using System;
using System.IO;

namespace MarcelloDB.Server.Constants
{
	public static class DefaultOptions
	{
		public static readonly string DatabaseBaseDir = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData), "MarcelloDB");
	}
}

