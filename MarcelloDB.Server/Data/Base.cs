using System;
using System.Collections.Generic;
using System.IO;
using MarcelloDB.Collections;
using Newtonsoft.Json;

namespace MarcelloDB.Server.Data
{
	public abstract class Base
	{
		protected static netfx.Platform _platform = new netfx.Platform ();

		static readonly Lazy<Session> _Sessionlazy = new Lazy<MarcelloDB.Session> (() => {
			var path = Path.Combine (Constants.DefaultOptions.DatabaseBaseDir, "_internal");
			Directory.CreateDirectory (path);

			return new Session (_platform, path);
		});

		protected Session _session { get { return _Sessionlazy.Value; } }

		protected static object _Lock = new Object ();
	}

	public abstract class Base<ITEMTYPE> : Base
	{

		protected String _collectionName {
			get {
				return GetType ().FullName;
			}
		}

		#region Abstract Properties

		/// <summary>
		/// Gets all of the items in the collection.
		/// </summary>
		/// <value>All.</value>
		public abstract List<ITEMTYPE> All { get; }

		#endregion


		#region Abstract Methods
		/// <summary>
		/// Get the specified contact by its Id.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public abstract ITEMTYPE Get (string id);

		/// <summary>
		/// Deletes all entries from the the collection.
		/// </summary>
		public abstract void Clear ();

		/// <summary>
		/// Delete the specified item.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public abstract void Delete (string id);

		/// <summary>
		/// Insert or Update the specified item into the collection.
		/// </summary>
		/// <param name="item">Item.</param>
		public abstract void Upsert (ITEMTYPE item);


		#endregion

		public string ToJSON ()
		{
			return JsonConvert.SerializeObject (this.All);
		}

		protected Collection<T, TID> InitalizeCollection<T, TID> (Func<T, TID> idFunct)
		{
			lock (_Lock) {
				return _session [$"{_collectionName}.data"].Collection<T, TID> (_collectionName, idFunct);
			}
		}
	}
}


