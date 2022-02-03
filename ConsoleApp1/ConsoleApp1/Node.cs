using ConsoleApp1;

public class LinkedListNode
{
	public LinkedListNode(KeyValuePair pair, LinkedListNode next = null)
	{
		Pair = pair;
		Next = next;
	}

	public KeyValuePair Pair { get; }

	public LinkedListNode Next { get; set; }
}