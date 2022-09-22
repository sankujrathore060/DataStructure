using System;

class MergeSort{
	public static void Merge(int[] array, int low, int mid, int high){
		int n1 = (mid - low) + 1;
		int n2 = high - mid;
		
		int[] leftArray = new int[n1];
		int[] rightArray = new int[n2];

		for(int index = 0; index < n1; index++){
			leftArray[index] = array[low + index];
		} 
		for(int index = 0; index < n2; index++){
			rightArray[index] = array[(mid + 1) + index];
		} 
		
		int lindex = 0;
		int jindex = 0;
		int kindex = low;
		while(lindex < n1 && jindex < n2){
			if(leftArray[lindex] < rightArray[jindex]){
				array[kindex] = leftArray[lindex] ;
				lindex++; 
			}
			else {
				array[kindex] = rightArray[jindex] ;
				jindex++; 
			}
			kindex++;
		}	
		while(lindex < n1){
			array[kindex] = leftArray[lindex] ;
			lindex++; 
			kindex++;
		}
		while(jindex < n2){
			array[kindex] = rightArray[jindex] ;
			jindex++; 
			kindex++;
		}
	}
	
	public static void Sort(int[] array, int low, int high){
		if(low < high){
			int mid = low +  (high - low)/2;
			Sort(array, low, mid);
			Sort(array, mid+1, high);
			Merge(array, low, mid, high);	
		}	
	}
	public static void PrintArray(int[] array){
		Console.WriteLine();
		foreach(var item in array){
			Console.Write(item + " ");
		}	
	}
	public static void Main(string[] args){
		int[] array = {8, 1, 5, 2, 6, 1, 4};
		PrintArray(array);
		Sort(array, 0, array.Length - 1);
		PrintArray(array);
	}
}