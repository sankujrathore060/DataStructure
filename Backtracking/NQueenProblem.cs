using System;

class NQueenProblem{
	public static void AddAnswer(int[,] board, int[,] ans, int n){
		for(int index = 0; index < n; index++){
			for(int inner = 0; inner < n; inner++){
				ans[index, inner] = board[index, inner];
			}	
		}
		
	}
	public static bool IsSafe(int[,] board, int index, int col, int n){
		int row = index;
		int column = col;
		
		while(column >= 0){			
			if(board[row, column] == 1){
				return false;
			}
			column--;
		}
	
		row = index;
		column = col;
		
		while(column>= 0 && row >= 0){
			if(board[row, column] == 1){
				return false;
			}
			row--;
			column--;
		}

		row = index;
		column = col;
		
		while(column >= 0 && row < n){
			if(board[row, column] == 1){
				return false;
			}
			row++;
			column--;
		}
		return true;
	}
		
	public static void Solve(int[,] board, int[,] ans, int col, int n){
		if(col == n){
			AddAnswer(board, ans, n);
			return;
		}

		for(int index =0; index < n; index++){
			if(IsSafe(board, index, col, n)){
				board[index, col] = 1;
				Solve(board, ans, col + 1, n);
				board[index, col] = 0;
			}
		}
	}

	public static void Main(string[] args){
		int[,] board  = new int[4,4];
		int[,] ans = new int[4,4];
		for(int index = 0; index < 4; index++){
			for(int inner = 0; inner < 4; inner++){
				ans[index, inner] = 0;
				board[index, inner] = 0;
			}	
		}
		Solve(board, ans, 0, 4);

		for(int index = 0; index < 4; index++){
			for(int inner = 0; inner < 4; inner++){
				Console.Write(ans[index, inner]);
			}	
		}
	}
}