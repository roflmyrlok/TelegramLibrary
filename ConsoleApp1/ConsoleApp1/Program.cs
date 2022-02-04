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
			var datafile = TxtRdr();
			var lenTxt = 0;
			foreach (var element in datafile) lenTxt++;
			var maxNumberOfBoxes = Convert.ToInt32(Math.Pow(10, lenTxt.ToString().Length) * 10);
			var buckets = new StringsDictionary();
			buckets.StringsDictionaryStart(maxNumberOfBoxes);
			foreach (var element in datafile)
			{
				var i = 0;
				var name = "";
				while (!element[i].Equals(';'))
				{
					name += element[i];
					i++;
				}

				var definition = element.Substring(i + 1);
				buckets.Add(name, definition);
			}

			while (true)
			{
				var n = Console.ReadLine();
				buckets.Get(n);
				
			}

			List<string> TxtRdr()
			{
				var list = new List<string>();
				var fileStream = new FileStream(
					@"/Users/atrybushnyi/Documents/GitHub/t3_lab3/ConsoleApp1/ConsoleApp1/dictionary.txt",
					FileMode.Open, FileAccess.Read);
				using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
				{
					string line;
					while ((line = streamReader.ReadLine()) != null) list.Add(line);
				}
				return list;
			}
		}
	}
}