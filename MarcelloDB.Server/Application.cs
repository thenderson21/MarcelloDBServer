using System;
using System.Net;

namespace MarcelloDB.Server
{
	public class Application
	{

		public static Options Options { get; private set; } = new Options ();

		public Application ()
		{
			Server ws = new Server (Options.Prefixes);
			ws.Run ();
			Console.WriteLine ($"{Constants.Info.Name}. Press a key to quit.");
			Console.ReadKey ();
			ws.Stop ();
		}

		public Application (Options options) : this ()
		{
			Options = options;
		}

	}
}

