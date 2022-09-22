using System;

class QuickSort{
	
	public static void Swap(int[] array, int first, int secound){
		int temp = array[first];
		array[first] = array[secound];
		array[secound] = temp;
	}

	public static int Partition(int[] array, int low, int high){
		int pivot = array[low];
		
		int count = 0;
		for(int index = low +1; index <=high; index++){
			if(array[index] < pivot){
				count++;
			}
		}	
		int pivotIndex = low + count;
		Swap(array, low, pivotIndex);
		
		int i = low;
		int j = high;

		while(i < pivotIndex &&  j > pivotIndex){
			if(array[i] < array[pivotIndex]){
				i++;
				continue;
			}
			if(array[pivotIndex] < array[j]){
				j--;
				continue;
			}
			Swap(array, i, j);
			i++;
			j--;
		}
		return pivotIndex;
	}
	public static void Sort(int[] array, int low, int high){
		if(low < high){
			
			//create Partition
			int p = Partition(array, low, high);
			Sort(array, low, p-1);
			Sort(array, p + 1, high);
		}
	}
	public static void PrintArray(int[] array){
		Console.WriteLine();
		foreach(var item in array){
			Console.Write(item + " ");
		}	
	}
	public static void Main(string[] args){
		int[] array = { 5, 4, 6, 1, 8, 2, 7, 3};
		PrintArray(array);
		Sort(array, 0, array.Length - 1);
		PrintArray(array);
	}
}