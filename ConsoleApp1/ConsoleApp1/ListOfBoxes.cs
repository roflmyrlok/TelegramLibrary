using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	public class ListOfBoxes
	{
		public ListOfBoxes()
		{
			SetBoxes();
		}

		List<Boxes> boxes = new List<Boxes>();
		double fill = 0;
		int power = 10;


		public void GetDescription(string element)
		{
			var i = Math.Abs(ConvertToHash(element) % power);
			Console.WriteLine(boxes[i].GetValue(ConvertToHash(element)));
		}

		public void AddElement(string element, string value)
		{
			var i = Math.Abs(ConvertToHash(element) % power);
			fill += 1 / boxes.Count;
			boxes[i].AddElement(ConvertToHash(element), value);
			if (fill > 0.6)
			{
				boxes = SetBoxes();
			}
		}


		private List<Boxes> SetBoxes()
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

		private int ConvertToHash(string toHash)
		{
			return toHash.GetHashCode();
		}
	}
}