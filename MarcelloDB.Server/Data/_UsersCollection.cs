using System;
using System.Collections.Generic;
using MarcelloDB.Server.Models
namespace MarcelloDB.Server.Data
{
	public class _UsersCollection : Database<_User>
	{
		Collection<_User, string> _Collection {
			get {
				return InitalizeCollection<_User, string> (p => p._UserId);
			}
		}

		#region Singleton Constructor/Initilizer

		_UsersCollection ()
		{
			//collection = InitalizeCollection<_User, string> (p => p._UserId);
		}

		static readonly Lazy<_UsersCollection> lazy =
		new Lazy<_UsersCollection> (() => new _UsersCollection ());

		public static _UsersCollection Instance { get { return lazy.Value; } }

		#endregion

		#region Overides

		/// <summary>
		/// Gets all contacts in the collection.
		/// </summary>
		/// <value>All.</value>
		public override List<_User> All {
			get {
				return (_Collection.All as IEnumerable<_User>).OrderBy (o => o.Name).ToList ();
			}
		}

		/// <summary>
		/// Occurs when the collection changes.
		/// </summary>
		public override event EventHandler<DataCollectionChangedEventArgs<_User>> CollectionChanged = delegate { };

		/// <summary>
		/// Insert or Update the specified contact into the collection.
		/// </summary>
		/// <param name="item">Contact.</param>
		public override void Upsert (_User item)
		{
			_Collection.Persist (item);
			CollectionChanged (this, new DataCollectionChangedEventArgs<_User> (DataCollectionChangedEventArgsActions.Upsert, item));
		}

		/// <summary>
		/// Get the specified contact by its _UserId.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public override _User Get (string id)
		{
			return _Collection.Find (id);
		}

		/// <summary>
		/// Delete the specified Contact.
		/// </summary>
		/// <param name="id">_User identifier.</param>
		public override void Delete (string id)
		{
			var item = _Collection.Find (id);

			_Collection.Destroy (id);
			CollectionChanged (this, new DataCollectionChangedEventArgs<_User> (DataCollectionChangedEventArgsActions.Upsert, item));

		}


		/// <summary>
		/// Deletes all entries from the the collection.
		/// </summary>
		public override void Clear ()
		{
			var items = _Collection.All;
			foreach (var item in items) {
				_Collection.Destroy (item._UserId);
			}
		}

		#endregion
	}
}