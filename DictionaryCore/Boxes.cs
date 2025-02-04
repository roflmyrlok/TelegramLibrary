using System;

namespace DictionaryCore;

public class Bucket
{
	public LinkedListNode<KeyValuePair<string,string>> First;
	public bool Visited;

	//public List<T> matched = new List<T>();

	public void Add(KeyValuePair<string,string> pair)
	{
		if (!Visited)
		{
			First = new LinkedListNode<KeyValuePair<string,string>>(pair);
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
			current.Next = new LinkedListNode<KeyValuePair<string,string>>(pair);
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

	public KeyValuePair<string,string> GetItemWithKey(string key)
	{
		var current = First;
		while (true)
		{
			if (current == null) return new KeyValuePair<string,string>("T", "no such an item in dict");
			if (!current.Value.Key.Equals(key))
				current = current.Next;
			else
				break;
		}

		return current.Value;
	}
}