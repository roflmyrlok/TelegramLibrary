namespace ConsoleApp1
{
	public class KeyValuePair
	{
		public KeyValuePair(string key, string value)
		{
			Key = key;
			Value = value;
		}

		public string Key { get; }

		public string Value { get; }
	}
}