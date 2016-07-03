using System;
using Newtonsoft.Json;

namespace MarcelloDB.Server.Models
{
	public class Credentials : BaseModel
	{
		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>The username.</value>
		[JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
		public string Username { get; set; }

		/// <summary>
		/// Gets or sets the pasword.
		/// </summary>
		/// <value>The pasword.</value>
		[JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
		public string Pasword { get; set; }

		/// <summary>
		/// Gets or sets the session.
		/// </summary>
		/// <value>The session.</value>
		[JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
		public string Session { get; set; }
	}
}

