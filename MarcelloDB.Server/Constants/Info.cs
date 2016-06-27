using System;
using System.Reflection;

namespace MarcelloDB.Server.Constants
{
	public static class Info
	{
		public const string Name = "MarcelloDB Server";

		public static class Version
		{
			public static readonly string Short = $"{assembly.Version.Major}.{assembly.Version.Minor}.{assembly.Version.Revision}";

			public static readonly string Full = assembly.Version.ToString ();
		}

		public static readonly string [] Authors = { "Todd Henderson" };


		static AssemblyName assembly = Assembly.GetExecutingAssembly ().GetName ();
	}
}

