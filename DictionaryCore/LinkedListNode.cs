namespace DictionaryCore;

public class LinkedListNode<T>(T value, LinkedListNode<T> next = null)
{
	public T Value { get; } = value;
	public LinkedListNode<T> Next { get; set; } = next;
}