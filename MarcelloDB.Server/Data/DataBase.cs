using System;
using System.IO;

namespace MarcelloDB.Server.Data
{
	public class DataBase
	{
		public abstract class Database
		{

			static readonly Lazy<Session> _ServerSessionlazy = new Lazy<Session> (() => {
				var path = Path.Combine (Constants.DefaultOptions.DatabaseBaseDir, "_Admin");
				Directory.CreateDirectory (path);

				return new Session (_platform, path);
			});

			protected static netfx.Platform _platform = new netfx.Platform ();

			protected Session _session { get { return _ServerSessionlazy.Value; } }

			protected static object _adminLock = new Object ();
		}
	}
}

