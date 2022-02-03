using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1
{
	[SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.Collections.Generic.List`1[System.Tuple`2[System.Int32,System.String]]; size: 3017MB")]
	public class Boxes
	{
		public List<Tuple<int, string>> TupleList = new();
		public bool visited { get; set; } = false;

		public void AddElement(int hash, string description)
		{
			TupleList.Add(new Tuple<int, string>(hash, description));
			visited = true;
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