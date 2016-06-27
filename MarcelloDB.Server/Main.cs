using System;
using CommandLine;

namespace MarcelloDB.Server
{
	class MainClass
	{
		public static int Main (string [] args)
		{
			var options = new Options ();
			if (Parser.Default.ParseArguments (args, options)) {
				var app = new Application (options);
			}
			return 0;
		}
	}
}
