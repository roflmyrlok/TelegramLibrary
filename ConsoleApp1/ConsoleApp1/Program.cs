using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			const string toHash1 = "amogus";
			const string toHash2 = "abobus";
			var boxes1 = new ListOfBoxes();
			boxes1.SetBoxes();
			boxes1.AddElement(toHash1, "idk wtf is it");
			boxes1.AddElement(toHash2, "sth wtf");
			boxes1.GetDescription("amogus");
		}
	}
}