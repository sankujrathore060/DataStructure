using System;

class TernarySearch{

	//Time:- O(log n with base 3), Space O(1)
	public static int IterativeSearch(int[] array, int low, int high, int key){
		while(low <= high){
			int mid1 = low + (high - low)/3;
			int mid2 = high - (high - low)/3;
			if(array[mid1] == key){
				return mid1;
			}
			else if(array[mid2] == key){
				return mid2;
			}
			else if(array[mid1] > key){
				high = mid1 - 1;
			}
			else if(array[mid2] < key){
				low = mid2 + 1;
			}
			else {
				low = mid1 + 1;
				high = mid2 - 1;
			}
		}
		return -1;
	}

	public static int RecursiveSearch(int[] array, int low, int high, int key){
		if(low > high)
		     return -1;
		int mid1 = low + (high - low) / 3;
		int mid2 = high - (high - low) / 3;
		if(array[mid1] == key){
			return mid1;
		}
		else if(array[mid2] == key){
			return mid2;
		}
		else if(array[mid1] > key){
			return RecursiveSearch(array, low, mid1 - 1, key);
		}
		else if(array[mid2] < key){
			return  RecursiveSearch(array, mid2 + 1, high, key);
		}
		else {
			return RecursiveSearch(array, mid1 + 1, mid2 - 1, key);
		}

	}
	public static void Main(string[] args){
		int[] array = {1, 5, 6, 7, 8, 9};
		Console.WriteLine(IterativeSearch(array, 0, array.Length - 1, 9));
		Console.WriteLine(RecursiveSearch(array, 0, array.Length - 1, 9));
	}	
}