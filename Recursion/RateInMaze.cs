using System;
using System.Collections.Generic;

class RateInMaze{
	public IList<string> allPath;
	public int[,] visited;
	
	public RateInMaze(int r, int c){
		visited = new int[r,c];
		allPath = new List<string>();
	}

	public bool IsSafe(int r, int c, int n, int m, int[,] maze){
		if((r >= 0 && r < n) && (c >= 0 && c < m) && visited[r, c] == 0 && maze[r, c] == 1){
			return true;
		}
		return false;
	}
	
	public void CalPath(int[,] maze, int r, int c, string path, int n, int m){
		if(r == n - 1 && c == m - 1){
			allPath.Add(path);
			return;
		}
		visited[r, c] = 1;

		//Go Down
		int rnew = r +1;
		int cnew = c;
		if(IsSafe(rnew, cnew, n, m, maze)){
			path+= "D";
			CalPath(maze, rnew, cnew, path, n, m);
			path = path.Substring(0,path.Length - 1);
		}

		//Go left
		rnew = r;
		cnew = c -1 ;
		if(IsSafe(rnew, cnew, n, m, maze)){
			path+= "L";
			CalPath(maze, rnew, cnew, path, n, m);
			path = path.Substring(0, path.Length - 1);
		}

		//Go right
		rnew = r;
		cnew = c +1 ;
		if(IsSafe(rnew, cnew, n, m, maze)){
			path+= "R";
			CalPath(maze, rnew, cnew, path, n, m);
			path = path.Substring(0, path.Length - 1);
		}

		//Go Top
		rnew = r - 1;
		cnew = c;
		if(IsSafe(rnew, cnew, n, m, maze)){
			path+= "T";
			CalPath(maze, rnew, cnew, path, n, m);
			path = path.Substring(0, path.Length - 1);
		}

		visited[r, c] = 0;
	}

	public static void Main(string[] args){
		RateInMaze rateInMaze = new RateInMaze(4, 4);

		for(int index = 0; index < 4; index++){
			for(int inner = 0; inner < 4; inner++){
				rateInMaze.visited[index, inner] = 0;
			}
		}
		string path = "";
		int[,] maze = {{1, 0, 0, 0}, {1, 1, 0, 0}, {1, 1, 0, 0}, {0, 1, 1, 1}};
		rateInMaze.CalPath(maze, 0, 0, path, 4, 4);
		foreach(var item in rateInMaze.allPath){
			Console.WriteLine(item);
		}
	}
}
