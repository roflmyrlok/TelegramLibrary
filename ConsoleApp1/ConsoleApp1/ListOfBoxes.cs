using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	public class ListOfBoxes
	{
		private double _fill;
		private int _power = 10;

		private List<Boxes> _boxes = new();

		public ListOfBoxes()
		{
			SetBoxes();
		}


		public void GetDescription(string element)
		{
			var i = Math.Abs(ConvertToHash(element) % _power);
			Console.WriteLine(_boxes[i].GetValue(ConvertToHash(element)));
		}

		public void AddElement(string element, string value)
		{
			var i = Math.Abs(ConvertToHash(element) % _power);
			_fill += 1 / _boxes.Count;
			_boxes[i].AddElement(ConvertToHash(element), value);
			if (_fill > 0.6) _boxes = SetBoxes();
		}


		private List<Boxes> SetBoxes()
		{
			if (_boxes.Count == 0)
			{
				for (var i = 0; i < _power; i++) _boxes.Add(new Boxes());

				return _boxes;
			}

			var pureBoxes = new List<Boxes>();
			_fill = 0;
			for (var i = 0; i < Math.Pow(_power, 2); i++) pureBoxes.Add(new Boxes());

			_power = pureBoxes.Count;

			foreach (var box in _boxes)
			foreach ((var value, var key) in box.TupleList)
			{
				var i = Math.Abs(value % _power);
				_fill += 1 / pureBoxes.Count;
				pureBoxes[i].AddElement(value, key);
			}

			return pureBoxes;
		}

		private int ConvertToHash(string toHash)
		{
			return toHash.GetHashCode();
		}
	}
}