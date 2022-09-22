using System;

class CountingSort{
	
	public static void Sort(int[] array, int max){
		int[] count = new int[max+1];
		
		for(int index = 0; index < array.Length; index++){
			count[array[index]]++;
		}
		int k = 0, countI = 0;
		while(countI<= max){
			if(count[countI] > 0){
				array[k] = countI;
				count[countI] = count[countI] -1;
				k++;
			}
			else{
			countI++;	
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
		int[] array = { 8 , 5 , 1 , 2 , 6, 2, 8, 7};
		PrintArray(array);
		Sort(array, 8);
		PrintArray(array);
	}
}