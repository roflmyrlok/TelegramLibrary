using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			List<string> datafile = TxtRdr();
			var lenTxt = 0;
			foreach (var element in datafile)
			{
				lenTxt++;
			}
			var maxNumberOfBoxes = Math.Pow(10, lenTxt.ToString().Length) * 10;
			var boxes1 = new ListOfBoxes(Convert.ToInt32(maxNumberOfBoxes));
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
				boxes1.AddElement(name,definition);
			}

			while (true)
			{
				var n = Console.ReadLine();
				boxes1.GetDescription(n);
			}
			List<string> TxtRdr()
			{
				string[] lines;
				var list = new List<string>();
				var fileStream = new FileStream(@"/Users/atrybushnyi/Documents/GitHub/t3_lab3/ConsoleApp1/ConsoleApp1/dictionary.txt",
					FileMode.Open, FileAccess.Read);
				using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
				{
					string line;
					while ((line = streamReader.ReadLine()) != null)
					{
						list.Add(line);
					}
				}

				lines = list.ToArray();
				return list;
			}
		}
	}
}