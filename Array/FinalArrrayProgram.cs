using System;

class FinalArrrayProgram{
	public static void SwapArray(int[] a, int[] b, int first, int secound){
		a[first] = a[first] + b[secound];
		b[secound] = a[first] - b[secound]; 
		a[first] = a[first] - b[secound];
	}

	public static void PrintArray(int[] a){
		Console.WriteLine();
		foreach(var item in a){
			Console.Write(item + " ");
		}	
	}
	
	public static void SortTwoArray(int[] a, int[] b){
		int low = 0 , high = a.Length - 1;
		while(low < b.Length && high >= 0){
			if(b[low] < a[high]){
				SwapArray(a, b, high, low);
				low++;
				high--;
			}
			else {
				break;
			}	
		}
		Array.Sort(a);
		Array.Sort(b);
		PrintArray(a);
	
		PrintArray(b);		
	}
	
	public static void Main(string[] args){
		int[] a = { 1, 5, 9, 10 };
		int[] b = { 2, 3, 8, 13, 15, 20 };
		SortTwoArray(a, b);			
	}
}