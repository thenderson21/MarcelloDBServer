using System;
namespace MarcelloDB.Server.Data
{
	public class DataCollectionChangedEventArgs<T> : EventArgs
	{
		public DataCollectionChangedEventArgsActions Action { get; private set; }

		public T Item { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:VideoChat.Data.CollectionChangedEventArgs`1"/> class.
		/// </summary>
		/// <param name="action">Action.</param>
		public DataCollectionChangedEventArgs (DataCollectionChangedEventArgsActions action)
		{
			Action = action;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:VideoChat.Data.CollectionChangedEventArgs`1"/> class.
		/// </summary>
		/// <param name="item">Item.</param>
		public DataCollectionChangedEventArgs (T item)
		{
			Item = item;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:VideoChat.Data.CollectionChangedEventArgs`1"/> class.
		/// </summary>
		/// <param name="action">Action.</param>
		/// <param name="item">Item.</param>
		public DataCollectionChangedEventArgs (DataCollectionChangedEventArgsActions action, T item)
		{
			Action = action;
			Item = item;
		}

	}

	/// <summary>
	/// Data collection changed event arguments actions.
	/// </summary>
	public enum DataCollectionChangedEventArgsActions
	{
		Upsert,
		Delete
	}
}

