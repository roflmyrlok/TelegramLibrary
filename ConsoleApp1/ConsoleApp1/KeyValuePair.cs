namespace ConsoleApp1
{
	public class KeyValuePair
	{
		public KeyValuePair(long key, string value)
		{
			Key = key;
			Value = value;
		}

		public long Key { get; }

		public string Value { get; }
	}
}