using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
	public class Boxes
	{
		public List<Tuple<int, string>> TupleList = new List<Tuple<int, string>>();
		public void AddElement(int hash, string description)
		{
			TupleList.Add(new Tuple<int, string>(hash, description));
		}
		
		public string GetValue(int hash)
		{
			foreach (var (key, value) in TupleList)
			{
				if (hash.Equals(key))
				{
					return value;
				}
			}
			return "shhes";
		}
	}
}