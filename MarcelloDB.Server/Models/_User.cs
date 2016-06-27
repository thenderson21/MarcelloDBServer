using System;
using System.Collections.Generic;

namespace MarcelloDB.Server.Models
{
	internal class _User
	{
		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>The username.</value>
		public string Username { get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public string Password { get; set; }

		/// <summary>
		/// Gets or sets the last logged in.
		/// </summary>
		/// <value>The last logged in.</value>
		public DateTime LastLoggedIn { get; set; }

		/// <summary>
		/// User.
		/// </summary>
		public Dictionary<string, List<CollectionPrivledges>> Collections { get; set; }

		/// <summary>
		/// Collection privledges.
		/// </summary>
		public enum CollectionPrivledges
		{
			Create,
			Read,
			Update,
			Delete,
			All
		}
	}
}

