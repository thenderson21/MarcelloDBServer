using System;
using System.IO;
using System.Collections.Generic;

using MarcelloDB;
using MarcelloDB.Collections;
using MarcelloDB.Platform;

namespace MarcelloDB.Server.Data
{

	public abstract class Database
	{

		static readonly Lazy<Session> _AdminSessionlazy = new Lazy<Session> (() => {
			var path = Path.Combine (Constants.DefaultOptions.DatabaseBaseDir, "_internal");
			Directory.CreateDirectory (path);

			return new Session (_platform, path);
		});

		static readonly Lazy<Session> _CollectionsSessionlazy = new Lazy<Session> (() => {
			var path = Constants.DefaultOptions.DatabaseBaseDir;
			Directory.CreateDirectory (path);

			return new Session (_platform, path);
		});

		protected static netfx.Platform _platform = new netfx.Platform ();

		protected Session _adminSession { get { return _AdminSessionlazy.Value; } }

		protected Session _collectionsSession { get { return _CollectionsSessionlazy.Value; } }

		protected static object _adminLock = new Object ();

		protected static object _collectionsLock = new Object ();
	}

	public abstract class Database<ITEMTYPE> : Database
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

		#region Abstract Events

		/// <summary>
		/// Occurs when the collection changes.
		/// </summary>
		public abstract event EventHandler<DataCollectionChangedEventArgs<ITEMTYPE>> CollectionChanged;

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

		protected Collection<T, TID> InitalizeCollection<T, TID> (Func<T, TID> idFunct)
		{
			lock (_adminLock) {
				return _adminSession [$"{_collectionName}.data"].Collection<T, TID> (_collectionName, idFunct);
			}
		}
	}
}




