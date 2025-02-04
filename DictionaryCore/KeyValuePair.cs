namespace DictionaryCore;

public class KeyValuePair<TKey, TValue>(TKey key, TValue value)
{
	public TKey Key { get; } = key;

	public TValue Value { get; } = value;
}