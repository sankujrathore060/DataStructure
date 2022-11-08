using System;

class SudokuSolver{
	public static bool IsValid(int[,] board, int row, int column, int key, int n){
		for(int index  = 0; index < n; index++){
			//for row
			if(board[row, index] == key){
				return false;
			} 

			if(board[index, column] == key){
				return false;
			} 

			if(board[(3 *(row/3) + (index/3)), (3*(column/3) + (index/3))] == key){
				return false;
			}
		}
		return true;
	}
	public static bool Solve(int[,] board, int n){
		for(int index =0; index < n; index++){
			for(int inner = 0; inner < n; inner++){
				if(board[index, inner] == -1){
					for(int num = 1; num <= n; num++){
						if(IsValid(board, index, inner, num, n)){
							board[index, inner] = num;
							bool valid = Solve(board, n);
							if(valid){
								return true;
							}
							board[index, inner] = -1;
						}
					}
					return false;
				}
			}
		}
		return true;
	}

	public static void Main(string[] args){
		int[,] board = {{5, 3, -1, -1, 7, -1, -1, -1, -1}, 
			      {6, -1, -1, 1, 9, 5, -1, -1, -1 },
			      {-1, 9, 8, -1, -1, -1, -1, 6, -1},
			      {8, -1, -1, -1, 6, -1, -1, -1, 3},
			      {4, -1, -1, 8, -1, 3, -1, -1, 1},
			      {7, -1, -1, -1, 2, -1, -1, -1, 6},
			      {-1, 6, -1, -1, -1, -1, 2, 8, -1},
			      {-1, -1, -1, 4, 1, 9, -1, -1, 5},
		    	      {-1, -1, -1, -1, 8, -1, -1, 7, 9}};
	
		bool isSolved = Solve(board, 9);
		if(isSolved)
			Console.WriteLine("Solved");
		else 
			Console.WriteLine("Not Solved");
	}
}