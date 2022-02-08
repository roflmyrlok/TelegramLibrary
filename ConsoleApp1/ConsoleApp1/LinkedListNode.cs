using ConsoleApp1;

public class LinkedListNode<T>
{
	public LinkedListNode(T value, LinkedListNode<T> next = null)
	{
		Value = value;
		Next = next;
	}

	public T Value { get; }

	public LinkedListNode<T> Next { get; set; }
}