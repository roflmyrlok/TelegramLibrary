using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
	public class FileRdr
	{
		public List<string> TxtRdr()
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