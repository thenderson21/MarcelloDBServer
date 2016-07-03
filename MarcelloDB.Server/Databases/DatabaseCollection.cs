using System;
using MarcelloDB.Collections;

namespace MarcelloDB.Server.Databases
{
	public class DatabaseCollection
	{
		public string Identifier { get; set; }

		public Collection<object, string> Collection { get; set; }

		public DatabaseCollection (string identifier)
		{
		}

		public DatabaseCollection (string identifier, Collection<object, string> collection) : this (identifier)
		{
			Collection = collection;
		}
	}
}

