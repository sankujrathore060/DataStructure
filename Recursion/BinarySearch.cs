using System;

class BinarySearch{
	public static int Search(int[] array, int low, int high, int key){
		if(low > high)
			return -1;
		int mid = low + (high - low)/ 2;
		if(array[mid] == key){
			return mid;
		}
		
		if(array[mid] > key){
			return Search(array, low, mid - 1, key);
		}
		else {
			return Search(array, mid + 1, high, key);
		}
	}
	public static void Main(string[] args){
		int[] array = { 5, 8, 12, 15, 20};
		Console.WriteLine(Search(array, 0, array.Length - 1, 15));
	}
}