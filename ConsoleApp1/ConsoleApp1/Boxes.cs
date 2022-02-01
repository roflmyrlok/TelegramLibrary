using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
	public class Boxes
	{
		public List<int> AlternativeIntList { get; } = new List<int>();
		public List<string> AlternativeStringList { get; } = new List<string>();
		public void AddElement(int hash, string description)
		{
			AlternativeIntList.Add(hash);
			AlternativeStringList.Add(description);
		}
		
		public string GetValue(int key)
		{
			return AlternativeStringList[AlternativeIntList.IndexOf(key)];
		}

		public bool Contains()
		{
			return AlternativeIntList.Count > 0;
		}
	}
}