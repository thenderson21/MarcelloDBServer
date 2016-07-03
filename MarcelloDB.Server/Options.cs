using System;
using System.Reflection;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace MarcelloDB.Server
{
	public class Options
	{

		[Option ('b', "basedir", HelpText = "The path where databases will be stored.")]
		public string BaseDir { get; set; } = Constants.DefaultOptions.DatabaseBaseDir;

		[Option ('h', "hosts", HelpText = "The hostnames to listen for.")]
		public string [] Hosts { get; set; } = new string [] { "*" };

		[Option ('p', "port", HelpText = "The port number to use when listening for connections.")]
		public string [] Ports { get; set; } = new string [] { "4040" };

		[Option ('u', "unsecure", HelpText = "Use and unsecure connection. **Should NOT be used in producton environment**")]
		public bool Unsecure { get; set; } = true;


		[HelpOption]
		public string GetUsage ()
		{
			var help = new HelpText {
				Heading = new HeadingInfo ("MarcelloDB", Constants.Info.Version.Full),
				Copyright = "Copyright (c) 2016 Todd Henderson",
				AdditionalNewLineAfterOption = false,
				AddDashesToOption = true
			};

			help.AddPreOptionsLine ("Usage: MarcelloDB[--options=values]");
			help.AddOptions (this);
			return help;
		}

		public string [] Prefixes {
			get {
				string [] prefixes = new string [Hosts.Length + Ports.Length - 1];
				var i = 0;
				foreach (var host in Hosts) {
					foreach (var port in Ports) {
						prefixes [i] = $"{Protocol}{host}:{port}/";
						i++;
					}
				}
				return prefixes;
			}
		}

		public string Protocol {
			get {
				return Unsecure ? "http://" : "https://";
			}
		}
	}
}

