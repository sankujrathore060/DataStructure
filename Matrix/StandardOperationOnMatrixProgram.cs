using System;

public class StandardOperationOnMatrixProgram{
	public static void PrintMatrix(int[,] matrix){
		for(int index = 0; index <= matrix.GetLength(0) - 1; index++){
			for(int nextIndex = 0; nextIndex <= matrix.GetLength(1) - 1; nextIndex++){
				Console.Write(matrix[index, nextIndex] + "   ");
			}
			Console.WriteLine();
		}
	}
	
	public static void SumOfTwoMarix(int[,] a, int[,] b){
		int[,] c = new int[a.GetLength(0),a.GetLength(1)];
		for(int index = 0; index < a.GetLength(0); index++){
			for(int nextIndex = 0; nextIndex < a.GetLength(1); nextIndex++){
				c[index, nextIndex] = a[index, nextIndex] + b[index, nextIndex];
			}
		}
		PrintMatrix(c);
	}
	public static void SubtractionOfTwoMarix(int[,] a, int[,] b){
		int[,] c = new int[a.GetLength(0),a.GetLength(1)];
		for(int index = 0; index < a.GetLength(0); index++){
			for(int nextIndex = 0; nextIndex < a.GetLength(1); nextIndex++){
				c[index, nextIndex] = a[index, nextIndex] - b[index, nextIndex];
			}
		}
		PrintMatrix(c);
	}
	public static void MultiplicationOfTwoMarix(int[,] a, int[,] b){
		int[,] c = new int[a.GetLength(0),a.GetLength(1)];
		for(int index = 0; index < a.GetLength(0); index++){
			for(int nextIndex = 0; nextIndex < a.GetLength(1); nextIndex++){
			c[index, nextIndex] = 0;
				for(int mulIndex = 0;  mulIndex < a.GetLength(1);  mulIndex++){
					c[index, nextIndex] =  c[index, nextIndex] + (a[index, mulIndex] * b[mulIndex, nextIndex]);
				}
			}
		}
		PrintMatrix(c);
	}
	public static void TransposeOfMarix(int[,] a){
		int[,] c = new int[a.GetLength(0),a.GetLength(1)];
		for(int index = 0; index < a.GetLength(0); index++){
			for(int nextIndex = 0; nextIndex < a.GetLength(1); nextIndex++){
				c[index, nextIndex] = a[nextIndex, index];
			}
		}
		PrintMatrix(c);
	}
	public static void Main(string[] args){
		int[,] a = {{1,2,3}, {4,5,6}, {7, 8,9}};
		
		int[,] b = {{1,2,3}, {4,5,6}, {7, 8,9}};
		SumOfTwoMarix(a, b);
		SubtractionOfTwoMarix(a, b);
		MultiplicationOfTwoMarix(a, b);
		TransposeOfMarix(a);
	}
}