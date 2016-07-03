using System;
using Newtonsoft.Json;

namespace MarcelloDB.Server.Models
{
	public class RequestBody : BaseModel
	{
		/// <summary>
		/// Gets or sets the authentication credentials.
		/// </summary>
		/// <value>The auth.</value>
		public Credentials _Auth { get; set; }

		/// <summary>
		/// Gets or sets the data object.
		/// </summary>
		/// <value>The data.</value>
		[JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
		public object Data { get; set; }

	}
}

