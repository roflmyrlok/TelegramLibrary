using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{ 
			double fill = 0;
			var poryadok = 10;
			const string toHash1 = "amogus";
			const string toHash2 = "abobus";
			List<boxes> boxes = new List<boxes>();
			boxes = SetBoxes(boxes);
			Addelement(toHash1,"idk wtf is it");
			Addelement(toHash2,"sth wtf");
			Console.WriteLine(GetDescription(toHash1));
			Console.WriteLine(GetDescription(toHash2));
			boxes = SetBoxes(boxes);
			Console.WriteLine(GetDescription(toHash2));
			

			string GetDescription(string element)
			{
				var i = Math.Abs(ConvertToHash(element) % poryadok);
				return boxes[i].GetValue(ConvertToHash(element));
			}
			void Addelement(string element, string value)
			{
				var i = Math.Abs(ConvertToHash(element) % poryadok);
				if (!boxes[i].Contains())
				{
					fill += 1 / boxes.Count;
				}
				boxes[i].AddElement(ConvertToHash(element),value);
				if (fill > 0.6)
				{
					boxes = SetBoxes(boxes);
				}
			}
			
			
			List<boxes> SetBoxes(List<boxes> boxes)
			{
				if (boxes.Count == 0)
				{
					for (var i = 0; i < poryadok; i++)
					{
						boxes.Add(new boxes());
					}

					return boxes;
				}

				var pureBoxes = new List<boxes>();
				fill = 0;
				for (var i = 0; i < Math.Pow(poryadok, 2); i++)
				{
					pureBoxes.Add(new boxes());
				}

				poryadok = pureBoxes.Count;

				foreach (var box in boxes)
				{
					foreach (var value in box._localDict)
					{
						var i = Math.Abs(value.Key % poryadok);
						if (pureBoxes[i].Contains())
						{
							fill += 1 / pureBoxes.Count;
						}
						pureBoxes[i].AddElement(value.Key, value.Value);
					}
				}

				return pureBoxes;
			}

			int ConvertToHash(string toHash)
			{
				return toHash.GetHashCode();
			}
		}
	}
}