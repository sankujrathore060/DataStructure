using System;

public class LinearSearch{
	
	//Time:- O(n), Space:- O(1)
	public static int IterativeSearch(int[] array, int size, int key){
		for(int index = 0; index < size; index++){
			if(array[index] == key)
				return index;
		}
		return -1;		
	}

	public static int RecursiveSearch(int[] array, int size, int key){
		if(size == 0)
			return -1;
		if(array[size -1] == key){
			return size-1;
		}
		else {
			return RecursiveSearch(array, size-1, key);
		}
	}	
	public static void Main(string[] args){
		int[] array = { 2, 5, 6, 8, 7, 1 };
		Console.WriteLine(IterativeSearch(array, array.Length,8));
		Console.WriteLine(RecursiveSearch(array, array.Length,8));
	}
}