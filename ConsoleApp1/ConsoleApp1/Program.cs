using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
	internal class Program
	{
		[SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH", MessageId = "type: ConsoleApp1.Boxes[]; size: 2017MB")]
		private static void Main(string[] args)
		{
			var boxes1 = new ListOfBoxes();
			List<string> txtfile = txtReadar();
			foreach (var element in txtfile)
			{
				var i = 0;
				var name = "";
				while (!element[i].Equals(';'))
				{
					name += element[i];
					i++;
				}

				var defenition = element.Substring(i + 1);
				boxes1.AddElement(name,defenition);
			}

			while (true)
			{
				var n = Console.ReadLine();
				boxes1.GetDescription(n);
			}
			List<string> txtReadar()
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