using System;

public class TraversalProgram{
	public static void PrintMatrix(int[,] matrix){
		for(int index = 0; index <= matrix.GetLength(0) - 1; index++){
			for(int nextIndex = 0; nextIndex <= matrix.GetLength(1) - 1; nextIndex++){
				Console.Write(matrix[index, nextIndex] + "   ");
			}
			Console.WriteLine();
		}
	}	


	public static void TravelInSpiral(int[,] matrix){
		int rows = matrix.GetLength(0) -1, column = matrix.GetLength(1) -1;
		int start = 0, end = rows, right = column, left = 0;
		while(start != end && right != left){
			for(int index = left; index <= right; index++){
				Console.Write(matrix[start, index] + " ");
			}
			start++;
			for(int index = start; index <= end; index++){
				Console.Write(matrix[index, right]  + " ");
			}
			right--;
			for(int index = right; index >= left; index--){
				Console.Write(matrix[end, index]  + " ");
			}
			end--;
			for(int index = end; index >= start; index--){
				Console.Write(matrix[index, left]  + " ");
			}
			left++;
		}
	}

	public static void TravelInClockWiseSpiral(int[,] matrix){
		int start = 0, end = matrix.GetLength(0) - 1, left = 0, right = matrix.GetLength(1) - 1;
		while(start <= end && left <= right){
			for(int index = start; index <= end; index++){
				Console.Write(matrix[index, left] + " ");
			}
			left++;
			for(int index = left; index <= right; index++){
				Console.Write(matrix[end, index] + " ");
			}
			end--;
			for(int index = end; index >= start; index--){
				Console.Write(matrix[index, right] + " ");
			}
			right--;
			for(int index = right; index >= left; index--){
				Console.Write(matrix[start, index] + " ");
			}
			start++;
		}
	}

	public static void TravelInZigZagForm(int[,] matrix){
		int row = 0, column = 0, tempRow = 0, tempColumn = 0, lengthX = matrix.GetLength(0) - 1,  lengthY = matrix.GetLength(1) - 1;
		int zigZagTravelCount = 2;
		while(row != lengthX && column != lengthY){

			if(column <= lengthY - (zigZagTravelCount -1)){
				int visitingCount =zigZagTravelCount;
				int rowIndex = 0;
				while(visitingCount > 0){
					Console.Write(matrix[rowIndex, column]);
					visitingCount--;
					if(visitingCount > 0){
					column++;
					}
				}
				row++;		
			} 
			else {
				int visitingCount =zigZagTravelCount;
				while(visitingCount > 0){
					if(tempRow == lengthX)
						break;
					Console.Write(matrix[tempRow, column]);
					visitingCount--;
					
					if(visitingCount > 0){
						tempRow++;
					}
				}
				tempColumn++;
			}
			if(column <= lengthY - (zigZagTravelCount -1)){
				int columnIndex = column - 2;
				int rowIndex = 1;
				while(rowIndex >= row){
					Console.Write(matrix[rowIndex, columnIndex]);
					columnIndex--;
					rowIndex++;
				}	
			}
			else {
				int columnIndex = column - 1;
				int rowIndex = tempRow;
				while(rowIndex >= row){
					Console.Write(matrix[rowIndex, columnIndex]);
					columnIndex--;
					rowIndex++;
				}
			}

			if(row <= lengthX - (zigZagTravelCount -1)){
				int visitingCount =zigZagTravelCount;
				int columnIndex = 0;
				while(visitingCount > 0){
					Console.Write(matrix[row, columnIndex]);
					visitingCount--;
					if(visitingCount > 0){
						row++;
					}
				}
				column++;	
			} 
			else {
				int visitingCount =zigZagTravelCount;
				while(visitingCount > 0){
					if(tempColumn == lengthY)
						break;
					Console.Write(matrix[row,  tempColumn]);
					visitingCount--;

					if(visitingCount > 0){
					 	tempColumn++;
					}
				}
				tempRow++;
			}
			if(row <= lengthX - (zigZagTravelCount -1)){
				int columnIndex = 1;
				int rowIndex =  row - 2;
				while(columnIndex>= column){
					Console.Write(matrix[rowIndex, columnIndex]);
					columnIndex++;
					rowIndex--;
				}	
			}
			else {
				int columnIndex = tempColumn;
				int rowIndex = tempRow - 1;
				while(columnIndex>= column){
					Console.Write(matrix[rowIndex, columnIndex]);
					columnIndex++;
					rowIndex--;
				}
			}
		}  
	}
	
	public static void PrintLowerTriangular(int[,] matrix){
		int lengthX = matrix.GetLength(0) - 1, lengthY = matrix.GetLength(1) - 1; 
		for(int index = 0; index <= lengthX; index++){
			for(int nextIndex = 0; nextIndex <= lengthY; nextIndex++){
				if(nextIndex <= index){
					Console.Write(matrix[index, nextIndex] + "    ");
				}
				else {					
					Console.Write(0 + "    ");
				}
			}
			Console.WriteLine();
		}
	}
	public static void PrintUpperTriangular(int[,] matrix){
		int lengthX = matrix.GetLength(0) - 1, lengthY = matrix.GetLength(1) - 1; 
		for(int index = 0; index <= lengthX; index++){
			for(int nextIndex = 0; nextIndex <= lengthY; nextIndex++){
				if(nextIndex < index){	
					Console.Write(0 + "    ");
				}
				else {	
					Console.Write(matrix[index, nextIndex] + "    ");	
				}
			}
			Console.WriteLine();
		}
	}
	
	public static void PrintLowerAndUpperTriangular(int[,] matrix){
		PrintLowerTriangular(matrix);
		PrintUpperTriangular(matrix);
	}
	public static void SwapMazorDiagonalOfMatrix(int[,] matrix){
		int lengthX = matrix.GetLength(0) - 1, lengthY = matrix.GetLength(1) - 1 ;
		
		matrix[0,0] = matrix[0,0] + matrix[lengthX, 0];
		matrix[lengthX, 0] = matrix[0,0] - matrix[lengthX, 0];
		matrix[0, 0] = matrix[0,0] - matrix[lengthX, 0];	

		
		matrix[0,lengthY] = matrix[lengthX,lengthY] + matrix[0,lengthY];
		matrix[lengthX,lengthY] = matrix[0,lengthY] - matrix[lengthX,lengthY];
		matrix[0,lengthY] = matrix[0,lengthY] - matrix[lengthX,lengthY];	
	}
	public static void SwapMinorDiagonalOfMatrix(int[,] matrix){
		int lengthX = matrix.GetLength(0) - 1, lengthY = matrix.GetLength(1) - 1 ;
		
		matrix[0,0] = matrix[0,0] + matrix[0,lengthY];
		matrix[0,lengthY] = matrix[0,0] - matrix[0,lengthY];
		matrix[0, 0] = matrix[0,0] - matrix[0,lengthY];	

		
		matrix[lengthX, 0] = matrix[lengthX,lengthY] + matrix[lengthX, 0];
		matrix[lengthX,lengthY] = matrix[lengthX, 0] - matrix[lengthX,lengthY];
		matrix[lengthX, 0] = matrix[lengthX, 0] - matrix[lengthX,lengthY];	
	}
	public static void SwapMazorAndMinorDiagonalOfMatrix(int[,] matrix){
		//SwapMazorDiagonalOfMatrix(matrix);
		//PrintMatrix(matrix);
		SwapMinorDiagonalOfMatrix(matrix);
		PrintMatrix(matrix);
		
	}
	public static void SquareOfMatrixDiagonal(int[,] matrix){
		for(int index=0; index <= matrix.GetLength(0) - 1; index++){
			for(int nextIndex=0;  nextIndex <= matrix.GetLength(1) - 1; nextIndex++){
				if(nextIndex == index){
					Console.Write(Math.Pow(matrix[index, nextIndex], 2) + " ");
				}
			}
		}
		
		Console.WriteLine();
		for(int index=0; index <= matrix.GetLength(0) - 1; index++){
			for(int nextIndex=0;  nextIndex <= matrix.GetLength(1) - 1; nextIndex++){
				if((nextIndex + index) == matrix.GetLength(1) - 1){
					Console.Write(Math.Pow(matrix[index, nextIndex], 2) + " ");
				}
			}
		}
	}
	public static void SquareOfMatrixDiagonalInN(int[,] matrix){
		int row = matrix.GetLength(0) - 1, column = matrix.GetLength(1) - 1;
		for(int index=0; index <= row; index++){
			Console.Write(Math.Pow(matrix[index, index], 2) + " ");
		}
		
		Console.WriteLine();
		for(int index=0; index <= row; index++){
			Console.Write(Math.Pow(matrix[index, column - index], 2) + " ");
		}
	}

	
	public static void Main(string[] args){
		int[,] metrix = { { 1, 2, 3, 4 },
                      			{ 5, 6, 7, 8 },
                      			{ 9, 10, 11, 12 },
                      			{ 13, 14, 15, 16 } };
		//TravelInSpiral(metrix);
		Console.WriteLine();
		
		//TravelInClockWiseSpiral(metrix);

		//TravelInZigZagForm(metrix);

		//PrintLowerAndUpperTriangular(metrix);

		//SwapMazorAndMinorDiagonalOfMatrix(metrix);
		//SquareOfMatrixDiagonal(metrix); 
 		//SquareOfMatrixDiagonalInN(metrix);
	}
}