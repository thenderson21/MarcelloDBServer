using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MarcelloDB.Collections;
using MarcelloDB.Server.Helpers;

namespace MarcelloDB.Server.Databases
{
	public abstract class Database
	{
		protected static netfx.Platform _platform = new netfx.Platform ();

		static readonly Lazy<Session> _AdminSessionlazy = new Lazy<Session> (() => {
			var path = Path.Combine (Constants.DefaultOptions.DatabaseBaseDir, "_internal");
			Directory.CreateDirectory (path);

			return new Session (_platform, path);
		});

		protected Session _adminSession { get { return _AdminSessionlazy.Value; } }

		protected static object _adminLock = new Object ();

		protected Session _databaseSession { get; }

		protected Dictionary<string, DatabaseCollection> collections { get; } = new Dictionary<string, DatabaseCollection> ();


		public Collection this [string collectionName] {
			get { return collections [collectionName].Collection; }
		}

		public Database (string databaseName)
		{
			var path = Path.Combine (Constants.DefaultOptions.DatabaseBaseDir, databaseName);
			Directory.CreateDirectory (path);

			_databaseSession = new Session (_platform, path);

		}

		public void Add (string collectionName, string collectionIdentifier)
		{
			collections.Add (collectionName,
							 new DatabaseCollection (collectionIdentifier,
													_databaseSession [collectionName + ".dat"].Collection<object, string> (collectionName,
																														   p => p.GetPropValue<string> (collectionIdentifier))));
		}

		public bool Remove (string collectionName)
		{
			foreach (var item in collections [collectionName].Collection.All) {
				collections [collectionName].Collection.Destroy (item.GetPropValue<string> (collections [collectionName].Identifier));
			}

			return collections.Remove (collectionName);
		}

		public void Clear ()
		{
			collections.Clear ();
		}

	}
}

