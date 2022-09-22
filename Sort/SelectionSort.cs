using System;


class SelectionSort{
	
	public static void Sort(int[] array){
		for(int index =0; index < array.Length-1; index++){
			for(int inner = index + 1; inner < array.Length; inner++){
				if(array[inner] <  array[index]){
					int temp = array[index];
					array[index] = array[inner];
					array[inner] = temp;
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
		int[] array = { 5, 2, 8, 2, 9, 7, 3, 1 };
		PrintArray(array);
		Sort(array);
			
		PrintArray(array);
		
	}
}