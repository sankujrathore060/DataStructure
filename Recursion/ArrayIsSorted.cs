using System;

class ArrayIsSorted{
	public static bool IsSorted(int[] array, int length, int low){
		if(length ==0 || length == 1){
			return true;
		}
		if(array[low] > array[low + 1])
		{
			return false;
		}
		else {
			return IsSorted(array, length - 1, ++low);
		}
	}
	public static void Main(string[] args){
		int[] array = { 2, 5, 9, 12, 15};
		if(IsSorted(array, 5, 0)){
			Console.WriteLine("Array is Sorted");
		}
		else {
			
			Console.WriteLine("Array is not Sorted");
		}
	}
}