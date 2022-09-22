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
	
	public static void Main(string[] args){
		PrintIdentityMatrix();
		int[,] matrix = {{1,0,0}, {0, 1, 0}};
		Console.WriteLine(IsIdentityMatrix(matrix));
	}
}