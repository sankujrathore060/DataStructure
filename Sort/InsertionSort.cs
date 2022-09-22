using System;

class InsertionSort{

	public static void Sort(int[] array){
		for(int index = 1; index < array.Length; index++){
			int current = index;
			int prev = index - 1;
			while(prev >=0 && array[prev] > array[prev+1]){
				var temp = array[prev];
				array[prev] = array[prev +1];
				array[prev +1] = temp;
				prev--;
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
		int[] array = {5, 2, 1, 12, 3, 11, 9};
		PrintArray(array);
		Sort(array);
		PrintArray(array);
	}
}