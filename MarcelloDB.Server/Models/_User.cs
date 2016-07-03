using System;
using System.Collections.Generic;

namespace MarcelloDB.Server.Models
{
	internal class _User : BaseModel
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
		/// Gets or sets the admin privledges.
		/// </summary>
		/// <value>The admin privledges.</value>
		public List<Privledge> AdminPrivledges { get; set; }

		/// <summary>
		/// Gets or sets the content privledges.
		/// </summary>
		/// <value>The content privledges.</value>
		public List<Privledge> ContentPrivledges { get; set; }
	}
}

