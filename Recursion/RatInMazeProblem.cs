using System;
using System.Collections.Generic;

class RatInMazeProblem{
	
	public static void CalculateAllPath(int[,] maze, int row, int column, int rowSize, int columnSize, IList<string> allPath, string path){
		Console.WriteLine(row);
		if(row < 0 || column < 0 || row > rowSize - 1 || column  > columnSize - 1)
			return;
		if(row == rowSize - 1 && column == columnSize - 1 && maze[row, column] == 1){
			allPath.Add(path);
			return;
		}
			
		if(column > 0 && maze[row, column - 1] == 1){
			string temp = path;
			temp+= "W";
			maze[row, column] = 0;
			CalculateAllPath(maze, row, column - 1,rowSize,columnSize, allPath, temp);
			maze[row, column] = 1;
		}
		if(row > 0 && maze[row - 1, column] == 1){
			string temp = path;
			temp+= "N";
			maze[row, column] = 0;
			CalculateAllPath(maze, row -1, column , rowSize, columnSize, allPath, temp);
			maze[row, column] = 1;
		}
		if(column < columnSize - 1 && maze[row, column + 1] == 1){
			string temp = path;
			temp+= "E";
			maze[row, column] = 0;
			CalculateAllPath(maze, row, column + 1 , rowSize, columnSize, allPath, temp);
			maze[row, column] = 1;
		}
		if(row < rowSize - 1 && maze[row + 1, column] == 1){
			string temp = path;
			temp+= "S";
			maze[row, column] = 0;
			CalculateAllPath(maze, row + 1, column , rowSize, columnSize, allPath, temp);
			maze[row, column] = 1;
		}
	}

	public static void Main(string[] args){
		int[,] maze = {{1,1, 1, 1}, {0, 1, 1, 1}, {0, 0, 1, 1}, {0, 0, 0, 1}};
		IList<string>  allPath = new List<string>();
		string path = string.Empty;
		CalculateAllPath(maze, 0, 0, 4, 4, allPath, path);
		foreach(var item in allPath){
			Console.WriteLine(item + " ");
		}
	}
}