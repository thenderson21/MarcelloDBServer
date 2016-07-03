using System;
using Newtonsoft.Json;

namespace MarcelloDB.Server.Models
{
	public class ResponseError : BaseModel
	{
		/// <summary>
		/// Gets or sets the error code.
		/// </summary>
		/// <value>The code.</value>
		[JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
		public int Code { get; set; }

		/// <summary>
		/// Gets or sets the error message.
		/// </summary>
		/// <value>The message.</value>
		[JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
		public string Message { get; set; }
	}
}

