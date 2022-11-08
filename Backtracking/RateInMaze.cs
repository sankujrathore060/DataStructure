using System;
using System.Collections.Generic;

class RateInMaze{
	public static bool IsSafe(int[,] maze, int[,] visited, int x, int y,int n){
		if((x >= 0 && x < n) && (y >= 0 && y < n) && maze[x, y] != 0 && visited[x, y] != 1){
			return true;
		}
		return false;
	}

	public static void Solve(int[,] maze, string path, int[,] visited, List<string> allPath, int x, int y, int n){
		
		if(!IsSafe(maze, visited, x, y, n)){
			return;
		}
		if(x == n-1 && y == n-1){
			allPath.Add(path);
			return;
		}
		visited[x, y] = 1;
		//Down
		Solve(maze, path + 'D', visited, allPath, x + 1, y, n);
		//Left
		Solve(maze, path + 'L', visited, allPath, x, y - 1, n);
		
		//right
		Solve(maze, path + 'R', visited, allPath, x, y + 1, n);

		//up
		Solve(maze, path + 'U', visited, allPath, x - 1, y, n);

		visited[x, y] = 0;
	}	


	public static void Main(string[] args){
		int[,] maze = {{1, 0, 0, 0}, {1, 1, 0, 0}, {1, 1, 0, 0}, {0, 1, 1, 1}};
		
		int[,] visited = new int[4,4];
		
		List<string> allPath = new List<string>();
		if(maze[0,0] != 0)
			Solve(maze, "", visited, allPath, 0, 0, 4);
		
		foreach(var item in allPath){
			Console.WriteLine(item);
		}
	}
}