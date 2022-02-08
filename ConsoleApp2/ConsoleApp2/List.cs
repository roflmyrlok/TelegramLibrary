using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
	public class List
	{
		private int _arraylengs = 0;
		private List<int> _arrayOfInt = new List<int>();
		public void Add(int element)
		{
			_arrayOfInt.Add(element);
			_arraylengs += 1;
		}

		public int Count()
		{
			return _arraylengs;
		}

		public bool IsEqualTo(List listToCheck)
		{
			if (_arraylengs != listToCheck._arraylengs) return false;
			for (int i = 0; i < _arraylengs; i++)
			{
				if (listToCheck._arrayOfInt[i] != _arrayOfInt[i]) return false;
			}

			return true;
		}
	}
}