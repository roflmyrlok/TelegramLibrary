namespace ConsoleApp1
{
	public class Bucket
	{
		public LinkedListNode First;
		public bool Visited;

		public void Add(KeyValuePair pair)
		{
			if (!Visited)
			{
				First = new LinkedListNode(pair);
				Visited = true;
			}
			else
			{
				First.Next = new LinkedListNode(pair);
			}
		}

		public void RemoveByKey(long key)
		{
			// remove pair with provided key
		}

		public KeyValuePair GetItemWithKey(long key)
		{
			var current = First;
			while (true)
			{
				if (current == null) return new KeyValuePair(-1, "no such an item in dict");
				if (current.Pair.Key != key)
					current = current.Next;
				else
					break;
			}

			return current.Pair;
		}
	}
}