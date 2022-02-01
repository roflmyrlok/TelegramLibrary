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
			Console.WriteLine(GetDescription(toHash1));
			Console.WriteLine(GetDescription(toHash2));
			boxes = SetBoxes(boxes);
			Console.WriteLine(GetDescription(toHash2));
			

			string GetDescription(string element)
			{
				var i = Math.Abs(ConvertToHash(element) % power);
				return boxes[i].GetValue(ConvertToHash(element));
			}
			void AddElement(string element, string value)
			{
				var i = Math.Abs(ConvertToHash(element) % power);
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
					foreach (var value in box.AlternativeIntList)
					{
						var i = Math.Abs(value % power);
						var index = box.AlternativeIntList.IndexOf(value);
						if (pureBoxes[i].Contains())
						{
							fill += 1 / pureBoxes.Count;
						}
						pureBoxes[i].AddElement(box.AlternativeIntList[index], box.AlternativeStringList[index]);
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