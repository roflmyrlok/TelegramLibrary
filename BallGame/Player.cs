using System.ComponentModel.DataAnnotations.Schema;
using BallGame.t3_lab2;

namespace BallGame
{
	public class Player
	{
		private Point position;

		public Player(int column, int row, string name)
		{
			position = new Point();
			position.SetPoint(column,row,name);
		}

		public Point getPoint()
		{
			return position;
		}
	}
}