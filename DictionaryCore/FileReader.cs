using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryCore;

public class FileReader
{
	public List<string> ReadLines()
	{
		var path =
			Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.FullName ?? throw new InvalidOperationException(),
				"dictionary.txt");
		var list = new List<string>();
		var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		using var streamReader = new StreamReader(fileStream, Encoding.UTF8);
		while (streamReader.ReadLine() is { } line) list.Add(line);
		return list;
	}
}