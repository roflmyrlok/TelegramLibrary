using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var datafile = new FileRdr().TxtRdr();
			var buckets = new StringsDictionary(10);
			buckets.Fill(datafile,buckets);

			while (true)
			{
				var n = Console.ReadLine();
				buckets.Get(n.ToUpper());
			}
		}
	}
}