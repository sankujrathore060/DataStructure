using System;

class BinarySearch{
	//Time:- O(log n), Space:- O(1)	
	public static int IterativeSearch(int[] array, int low, int high, int key){
		while(low <= high){
			int mid = low + (high - low) / 2;
			if(array[mid] == key){
				return mid;
			}
			else if(array[mid] < key){
				low = mid + 1;	
			}
			else {
				high = mid - 1;
			}
		}
		return -1;
	}
	//Time:- O(log n), Space:- O(1)	
	public static int RecursiveSearch(int[] array, int low, int high, int key){
		if(low > high){
			return -1;	
		}
		int mid = low + (high - low)/ 2;
		if(array[mid] == key){
			return mid;
		}
		if(array[mid] < key){
			return RecursiveSearch(array, mid + 1, high, key);
		}
		else {
			return RecursiveSearch(array, low, mid - 1, key);
		}
	}
	public static void Main(string[] args){
		int[] array = { 4 , 8,  15,  20,  26,  27 };
		Console.WriteLine(IterativeSearch(array, 0, array.Length -1, 15));
		Console.WriteLine(RecursiveSearch(array, 0, array.Length -1, 15));
	}
}