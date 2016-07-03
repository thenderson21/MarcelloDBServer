using System;
using System.Collections.Generic;
using System.Linq;
using MarcelloDB.Collections;
using MarcelloDB.Server.Models;

namespace MarcelloDB.Server.Data
{
	internal class _Users : Base<_User>
	{

		Collection<_User, string> _Collection {
			get {
				return InitalizeCollection<_User, string> (p => p.Username);
			}
		}

		#region Singleton Constructor/Initilizer

		_Users ()
		{
			Upsert (new _User { Username = "Admin", Password = "Admin", AdminPrivledges = new List<Privledge> { Privledge.Create, Privledge.Read, Privledge.Update, Privledge.Delete } });
		}

		static readonly Lazy<_Users> lazy =
		new Lazy<_Users> (() => new _Users ());

		public static _Users Instance { get { return lazy.Value; } }

		#endregion

		#region Overides

		/// <summary>
		/// Gets all contacts in the collection.
		/// </summary>
		/// <value>All.</value>
		public override List<_User> All {
			get {
				return (_Collection.All as IEnumerable<_User>).ToList ();
			}
		}


		/// <summary>
		/// Insert or Update the specified contact into the collection.
		/// </summary>
		/// <param name="item">Contact.</param>
		public override void Upsert (_User item)
		{
			_Collection.Persist (item);
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
			_Collection.Destroy (id);
		}


		/// <summary>
		/// Deletes all entries from the the collection.
		/// </summary>
		public override void Clear ()
		{
			var items = _Collection.All;
			foreach (var item in items) {
				_Collection.Destroy (item.Username);
			}
		}

		#endregion
	}
}
