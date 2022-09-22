using System;
public class TypesOfMatrixProgram{
	public static void PrintMatrix(int[,] matrix){
		for(int index = 0; index <= matrix.GetLength(0) - 1; index++){
			for(int nextIndex = 0; nextIndex <= matrix.GetLength(1) - 1; nextIndex++){
				Console.Write(matrix[index, nextIndex] + "   ");
			}
			Console.WriteLine();
		}
	}

	public static void PrintIdentityMatrix(){
		int[,] matrix= new int[3,3];
		for(int index = 0; index < 3; index++){
			for(int nextIndex = 0; nextIndex < 3; nextIndex++){
				if(index == nextIndex){
					matrix[index, nextIndex] = 1;
				}
				else {
					matrix[index, nextIndex] = 0;
				}
			}
		} 
		PrintMatrix(matrix);
	}

	public static bool IsIdentityMatrix(int[,] matrix){
		for(int index = 0; index < matrix.GetLength(0); index++){
                                 		for(int nextIndex = 0; nextIndex < matrix.GetLength(1); nextIndex++){
                                 			if(index == nextIndex){
					if(matrix[index, nextIndex] == 0)
						return false;
				}
				else {
					if(matrix[index, nextIndex] == 1)
						return false;
				}
                                  		}
                                  }
		return true;
	}

	public static bool CheckForSkewSymmetric(int[,] matrix){
		for(int index = 0; index < matrix.GetLength(0); index++){
			for(int nextIndex = 0; nextIndex < matrix.GetLength(1); nextIndex++){
				if(matrix[index, nextIndex] != -matrix[nextIndex,index])
					return false;	
			}
		}
		return true;
	}

	public static bool CheckForDiagonalGraterThenSum(int[,] matrix){
		for(int index = 0; index < matrix.GetLength(0); index++){
			int diagonalElement =  -1, sumOfRow = 0;
			for(int nextIndex = 0; nextIndex < matrix.GetLength(1); nextIndex++){
				if(index == nextIndex){
					diagonalElement = matrix[index, nextIndex];
				}		
				else {
					sumOfRow = sumOfRow + matrix[index, nextIndex];
				}
			}
			if(Math.Abs(diagonalElement) < Math.Abs(sumOfRow))
				return false;
		}
		return true;		
	}
	 public static bool CheckForIsMarkovMatrix(double[,] matrix){
		for(int index = 0; index < matrix.GetLength(0); index++){
			double sumOfRow = 0;
			for(int nextIndex = 0; nextIndex < matrix.GetLength(1); nextIndex++){
					sumOfRow = sumOfRow + matrix[index, nextIndex];
			}
			if(sumOfRow != 1)
				return false;
		}
		return true;		
	}

	public static bool IsDiagonalMatrix(int[,] matrix){
		for(int index = 0; index < matrix.GetLength(0); index++){
			for(int nextIndex = 0; nextIndex < matrix.GetLength(0); nextIndex++){
				if(index != nextIndex && matrix[index, nextIndex] != 0){
					return false;
				}
			}
		}
		return true;
	}
	public static bool IsScallerMatrix(int[,] matrix){
		int scallerElement = matrix[0, 0];
		for(int index = 0; index < matrix.GetLength(0); index++){
			for(int nextIndex = 0; nextIndex < matrix.GetLength(0); nextIndex++){
				if(index == nextIndex){
					if(matrix[index, nextIndex] != scallerElement)
						return false;
				}
				else if(matrix[index, nextIndex] != 0){
					return false;
				}
			}
		}
		return true;
	}
	public static void Main(string[] args){
		//PrintIdentityMatrix();
		//int[,] matrix = {{1,0,0}, {0, 1, 0}};
		//Console.WriteLine(IsIdentityMatrix(matrix));
		
		//int[,] matrix =  {{0, 5, -4},
                     	//	        {-5, 0, 6},
                    	//	        {4, -6, 0}}; 
		//Console.WriteLine(CheckForSkewSymmetric(matrix));
		 // int [,] m = { { 3, -2, 1 },
                    	//	{ 1, -5, 2 },
                    	//	{ -1, 2, 4 } };
		//Console.WriteLine(CheckForDiagonalGraterThenSum(m));
		 //double [,] m = {{ 0, 0, 1},
                                	//	{0.5, 0.1, 0.4},
                                	//	{1, 0, 0}};
		//Console.WriteLine(CheckForIsMarkovMatrix(m));
		int[,] mat= {{5, 0, 0, 0},
             			{0, 5, 0, 0},
             			{0, 0, 5, 0},
             			{0, 0, 0, 5}};	
		Console.WriteLine(IsDiagonalMatrix(mat));
		Console.WriteLine(IsScallerMatrix(mat));
	}
}