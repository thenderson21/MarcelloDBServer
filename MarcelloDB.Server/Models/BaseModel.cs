using System;
using Newtonsoft.Json;

namespace MarcelloDB.Server.Models
{
	public class BaseModel
	{
		public BaseModel ()
		{
		}

		public string ToJSON ()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}

