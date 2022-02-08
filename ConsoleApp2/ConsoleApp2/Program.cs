using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			var newList = new List();
			newList.Add(1);
			newList.Add(2);
			newList.Add(3);
			Console.WriteLine(newList.Count());
			var listToCheck = new List();
			listToCheck.Add(1);
			listToCheck.Add(2);
			//listToCheck.Add(3);
			Console.WriteLine(newList.IsEqualTo(listToCheck));
		}
	}
}