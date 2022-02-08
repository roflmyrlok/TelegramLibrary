using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	public class Bucket
	{
		public LinkedListNode First;
		public bool Visited;

		public List<string> matched = new List<string>();

		public void Add(KeyValuePair pair)
		{
			if (!Visited)
			{
				First = new LinkedListNode(pair);
				Visited = true;
				matched.Add(First.Pair.Key);
			}
			else if (!matched.Contains(pair.Key))
			{
				First.Next = new LinkedListNode(pair);
			}
			else
			{
				Console.WriteLine(pair.Value);
			}
		}

		public void RemoveByKey(string key)
		{
			var current = First;
			if (current == null) Console.WriteLine("no such an item in dict");
			if (current.Pair.Key.Equals(key))
			{
				First = current.Next;
			}
			else
			{
				while (true)
				{
					if (current.Next == null) Console.WriteLine("no such an item in dict");
					if (current.Next.Pair.Key.Equals(key))
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
				if (!current.Pair.Key.Equals(key))
					current = current.Next;
				else
					break;
			}

			return current.Pair;
		}
	}
}