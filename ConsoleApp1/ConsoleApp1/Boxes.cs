using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	public class Bucket
	{
		public LinkedListNode<KeyValuePair> First;
		public bool Visited;

		//public List<T> matched = new List<T>();

		public void Add(KeyValuePair pair)
		{
			if (!Visited)
			{
				First = new LinkedListNode<KeyValuePair>(pair);
				Visited = true;
			}
			else
			{
				var current = First;
				if (current == null) return;
				while (current.Next != null)
				{
					if (current.Value.Equals(pair))
					{
						Console.WriteLine("colision");
						return;
					}
					current = current.Next;
				}
				current.Next = new LinkedListNode<KeyValuePair>(pair);
			}
			
		}

		public void RemoveByKey(string key)
		{
			var current = First;
			if (current == null) Console.WriteLine("no such an item in dict");
			if (current.Value.Key.Equals(key))
			{
				First = current.Next;
			}
			else
			{
				while (true)
				{
					if (current.Next == null) Console.WriteLine("no such an item in dict");
					if (current.Next.Value.Key.Equals(key))
					{
						current.Next = current.Next.Next;
					}
				}
			}
			
		}

		public KeyValuePair GetItemWithKey(string key)
		{
			var current = First;
			while (true)
			{
				if (current == null) return new KeyValuePair("T", "no such an item in dict");
				if (!current.Value.Key.Equals(key))
					current = current.Next;
				else
					break;
			}

			return current.Value;
		}
	}
}