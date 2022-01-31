using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			double filledK = 0;
			var toHash1 = "amogus";
			var toHash2 = "abobus";
			var boxes = new List<Dictionary<int,string>>();
			int poryadok = new int();
			SetBoxes();
			AddElement(toHash1, "sth imposter");
			AddElement(toHash2, "sth not imposter");
			Console.WriteLine(GetValue(toHash2));
			

			void SetBoxes()
			{
				if (boxes.Count == 0)
				{
					for (var i = 0; i < 10; i++)
					{
						boxes.Add(new Dictionary<int,string>());
					} 
					poryadok = boxes.Count / 10;
				}
				else
				{
					
					var pureBoxes = new List<Dictionary<int,string>>();
					for (var i = 0; i < Math.Pow(10 ,poryadok); i++)
					{
						boxes.Add(new Dictionary<int,string>());
					}

					foreach (var dict in boxes)
					{
						foreach (var value in dict)
						{
							var hesh = ConvertToHash(value.Value);
							int hashNumber = GetHashNumbers(hesh);
							boxes[hashNumber].Add(hesh,value.Value);
							if (boxes[hashNumber].Count == 0)
							{
								filledK += (1 / boxes.Count);
							}
						}
					}
				}
			}
			int ConvertToHash(string toHash)
			{
				return toHash.GetHashCode();
			}

			void AddElement(string value, string description)
			{
				if (filledK < 0.6)
				{
					var hesh = ConvertToHash(value);
					int hashNumber = GetHashNumbers(hesh);
					boxes[hashNumber].Add(hesh,description);
					if (boxes[hashNumber].Count == 0)
					{
						filledK += (1 / boxes.Count);
					}
				}
			}
			int GetHashNumbers(int hash)
			{
				var i = hash.ToString().Substring(hash.ToString().Length - poryadok);
				return int.Parse(i);
			}

			string GetValue(string key)
			{
				var i = GetHashNumbers(ConvertToHash(key));
				return boxes[i][ConvertToHash(key)];
			}
		}
	}
}