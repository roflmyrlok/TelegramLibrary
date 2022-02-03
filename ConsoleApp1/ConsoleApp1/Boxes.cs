using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1
{
	public class Boxes
	{
		public List<Tuple<int, string>> TupleList = new();
		public bool Visited { get; set; } = false;

		public void AddElement(int hash, string description)
		{
			TupleList.Add(new Tuple<int, string>(hash, description));
			Visited = true;
		}

		public string GetValue(int hash)
		{
			foreach (var (key, value) in TupleList)
				if (hash.Equals(key))
					return value;
			return "shhes";
		}
	}
}