using System;
using Newtonsoft.Json;

namespace MarcelloDB.Server.Models
{
	public class ResponseBody : BaseModel
	{
		/// <summary>
		/// Gets or sets the data object.
		/// </summary>
		/// <value>The data.</value>
		[JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
		public object Data { get; set; }

		/// <summary>
		/// Gets or sets the request error.
		/// </summary>
		/// <value>The error.</value>
		[JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
		public ResponseError Error { get; set; }
	}
}

