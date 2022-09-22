using System;

class BubbleSort{
	
	public static void Sort(int[] array, int n){
		for(int index = 0; index < n-1;index++){
			
			for(int inner = 0; inner < n-index - 1; inner++){
				if(array[inner] > array[inner + 1]){
					int temp = array[inner];
					array[inner] = array[inner + 1];
					array[inner + 1] = temp;
				}
			}
		}
	}
	
	public static void PrintArray(int[] array){
		Console.WriteLine();
		foreach(var item in array){
			Console.Write(item + " ");
		}	
	}
	public static void Main(string[] args){
		int[] array = { 6, 5, 4, 3, 2, 1 };
		PrintArray(array);
		Sort(array, array.Length);
			
		PrintArray(array);	
	}
}