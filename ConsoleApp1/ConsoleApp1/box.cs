using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
	public class boxes
	{
		public Dictionary<int, string> _localDict { get; private set; } = new Dictionary<int, string>();
		public List<int> alternativeIntList { get; } = new List<int>();
		public List<string> alternativeStringList { get; } = new List<string>();
		public void AddElement(int hash, string description)
		{
			_localDict.Add(hash, description);
			alternativeIntList.Add(hash);
			alternativeStringList.Add(description);
		}
		
		public string GetValue(int key)
		{
			//return _localDict[key];
			return alternativeStringList[alternativeIntList.IndexOf(key)];
		}

		public bool Contains()
		{
			return _localDict.Count > 0;
		}
	}
}