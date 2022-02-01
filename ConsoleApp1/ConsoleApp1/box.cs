using System.Collections.Generic;

namespace ConsoleApp1
{
	public class boxes
	{
		public Dictionary<int, string> _localDict { get; private set; } = new Dictionary<int, string>();
		
		public void AddElement(int hash, string description)
		{
			_localDict.Add(hash, description);
		}
		
		public string GetValue(int key)
		{
			return _localDict[key];
		}

		public bool Contains()
		{
			return _localDict.Count > 0;
		}
	}
}