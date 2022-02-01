using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{ 
			double fill = 0;
			var power = 10;
			const string toHash1 = "amogus";
			const string toHash2 = "abobus";
			List<Boxes> boxes = new List<Boxes>();
			boxes = SetBoxes(boxes);
			AddElement(toHash1,"idk wtf is it");
			AddElement(toHash2,"sth wtf");
			GetDescription(toHash1);
			GetDescription(toHash2);
			boxes = SetBoxes(boxes);
			GetDescription(toHash2);
			

			void GetDescription(string element)
			{
				var i = Math.Abs(ConvertToHash(element) % power);
				Console.WriteLine(boxes[i].GetValue(ConvertToHash(element)));
			}
			void AddElement(string element, string value)
			{
				var i = Math.Abs(ConvertToHash(element) % power);
				fill += 1 / boxes.Count;
				boxes[i].AddElement(ConvertToHash(element),value);
				if (fill > 0.6)
				{
					boxes = SetBoxes(boxes);
				}
			}
			
			
			List<Boxes> SetBoxes(List<Boxes> boxes)
			{
				if (boxes.Count == 0)
				{
					for (var i = 0; i < power; i++)
					{
						boxes.Add(new Boxes());
					}

					return boxes;
				}

				var pureBoxes = new List<Boxes>();
				fill = 0;
				for (var i = 0; i < Math.Pow(power, 2); i++)
				{
					pureBoxes.Add(new Boxes());
				}

				power = pureBoxes.Count;

				foreach (var box in boxes)
				{
					foreach ((int value, string key) in box.TupleList)
					{
						var i = Math.Abs(value % power);
						fill += 1 / pureBoxes.Count;
						pureBoxes[i].AddElement(value, key);
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