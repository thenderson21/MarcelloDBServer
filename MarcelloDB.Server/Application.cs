using System;
using System.Net;

namespace MarcelloDB.Server
{
	public class Application
	{
		public String Method { get; set; } = "http://localhost:8080/";

	 	public Application ()
		{
			Server ws = new Server (SendResponse, Method);
			ws.Run ();
			Console.WriteLine ("A simple webserver. Press a key to quit.");
			Console.ReadKey ();
			ws.Stop ();
		}

		public Application (string method) : this()
		{
			Method = method;
		}

		string SendResponse (HttpListenerRequest request)
		{
			return $"<HTML><BODY>My web page.<br>{DateTime.Now}</BODY></HTML>";
		}
	}
}

