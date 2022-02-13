using System;
using System.Collections.Generic;
using BallGame.t3_lab2;

namespace BallGame
{
	public class MapPrientier
	{
		public void MapPrinter( Map mazeToPrint)
		{
			string[,] maze = new string[12, 12];
			for (var column = 0; column <= mazeToPrint.LenHeight() - 1; column++)
			{
				for (var row = 0; row <= mazeToPrint.LenWidth() - 1; row++)
				{
					var current = mazeToPrint.ListOfList[column][row];
					maze[current.GetColumn(), current.GetRow()] = current.GetValue();
				}
			}


			for (var row = 0; row < maze.GetLength(1); row++)
			{
				Console.Write($"{row}\t");
				for (var column = 0; column < maze.GetLength(0); column++)
				{
					Console.Write(maze[column, row]);
				}

				Console.WriteLine();
			}
		}
	}
}
