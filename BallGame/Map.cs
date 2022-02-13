using System.Collections.Generic;
using System.Linq;
using System.Net;
using BallGame.t3_lab2;

namespace BallGame
{
	public class Map
	{
		public List<List<Point>> ListOfList;
		private int _width;
		private int _height;

		public Map(int width, int height)
		{
			this._width = width;
			this._height = height;
			ListOfList = new List<List<Point>>();
			for (int i = 0; i != 12; i++)
			{
				ListOfList.Add(new List<Point>());
				for (int b = 0; b != 12; b++)
				{
					ListOfList[i].Add(new Point());
				}
			}
		}

		public int LenWidth()
		{
			return _width;
		}
		public int LenHeight()
		{
			return _height;
		}

		public Queue<Point> GetPointsNearby(Point point)
		{
			int offset = 1;
			var result = new Queue<Point>();
			TryAddWithOffset(offset, 0);
			TryAddWithOffset(-offset, 0);
			TryAddWithOffset(0, offset);
			TryAddWithOffset(0, -offset);
			return result;
			
			void TryAddWithOffset(int offsetX, int offsetY)
			{
				var newColumn = point.GetColumn() + offsetX;
				var newRow = point.GetRow() + offsetY;
				if (newColumn >= 0 && newRow >= 0 && newColumn < _width && newRow < _height)
				{ result.Enqueue(ListOfList[newRow][newColumn]); }
			}
		}

		public void SetPoint(Point i)
		{
			ListOfList[i.GetColumn()][i.GetRow()] = i;
		}
	}
}