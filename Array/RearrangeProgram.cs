using System;
using System.Collections.Generic;
class RearrangeProgram{
	public static void SwapArray(int[] array, int startIndex, int endIndex){
		var temp  = array[startIndex];
		array[startIndex] = array[endIndex];
		array[endIndex] =  temp;
	}
	public static void PrintArray(int[] array){
		foreach(var item in array){
			Console.Write(item + " ");
		}
	}
	public static void RearrangeValueToRespectiveIndex(int[] array){
		for(int index = 0; index < array.Length; index++){
			if(array[index] != -1 && array[index] != index)
			{
				var temp  = array[array[index]];
				array[array[index]] = array[index];
				array[index] =  temp;
			}
		}
	}

	public static void RearrangeArrayInCycleForm(int[] array){
		Array.Sort(array);
		for(int index = 1; index < array.Length; index+= 2){
			array[index] = array[index] + array[index+1];
			array[index + 1] = array[index] - array[index+1];
			array[index] = array[index] - array[index+1];
		}
	}
	
	public static void RearrangrArrayInNegativePositiveMode(int[] array){
		int low = 0, high = array.Length - 1;
		Array.Sort(array);
		while(low < high){
			if(low == 1 && array[low] < 0 && low != high){
				if(array[high] < 0)
					high--;					
				SwapArray(array, high, low);				
			}
			else if((low%2) != 0 && array[low] < 0 && low != high){
				if(array[high] < 0)
					high--;					
				SwapArray(array, high, low);				
			}else if((low%2) == 0 && array[low] >=0 && low != high){
				if(array[high] < 0){							
					SwapArray(array, high, low);	
					if(high < array.Length - 1)
						high++;
				}
			}
			low++;		
		}
	}
	
	
	public static void MoveAllZeroAtEnd(int[] array){
		int low = 0, high = array.Length - 1;
		PrintArray(array);
		Console.WriteLine();
		while(low < high){
			if(array[high] == 0)
			{
				high--;
				continue;
			}
			if(array[low] == 0){
				SwapArray(array, low, high);
				high--;
			}
			
			low++;
		}
		PrintArray(array);
	}
	
	public static void NoOfSwapRequireToRearrangeElemntLessAndEqualToKey(int[] array, int key){
		int low = 0, high = array.Length - 1, totalSwapRequired = 0;
		while(low < high){
			if(array[low] <= key)
			{
				low++;
				continue;
			}
			if(array[high] <= key){
				SwapArray(array, low, high);
				totalSwapRequired++;
				low++;
			}
			else {
				high--;
			}	
		}
		PrintArray(array);
		Console.WriteLine();
		Console.WriteLine(totalSwapRequired);
	}
	public static void RearrangeArrayInWaveForm(int[] array){
		Array.Sort(array);
		for(int index = 0; index < array.Length - 1; index+=2){
			SwapArray(array, index, index+1);			
		}
		PrintArray(array);
	}

	public static void ReArrangeArrayInSmallestAndLargestForm(int[] array){
		Array.Sort(array);
		int low = 0, high = array.Length - 1, index = 0;
		int[] temp = new int[array.Length];

		while(low < high){
			if(index == 1){
				temp[index] = array[high];
				high--;	
			}
			else if((index % 2) == 0){
				temp[index] = array[low];
				low++;
			}
			else {
				temp[index] = array[high];
				high--;	
			}
			index++;	
		}
		
			temp[index] = array[low];
		for(int i = 0; i< array.Length; i++){
			array[i] = temp[i];
		}

		PrintArray(array);
	}
	
	public static void ReArrangeArrayBasedOnIndexUsingTempArray(int[] array, int[] index){
		int[] temp = new int[index.Length];
		for(int i = 0; i < index.Length; i++){
			temp[index[i]]  = array[i];
		}
		PrintArray(temp);
	}

	public static void ReArrangeArrayBasedOnIndex(int[] array, int[] index){
		int[] temp = array.Clone() as int[];
		Array.Sort(array, delegate(int a, int b) { return index[Array.IndexOf(temp, a)] - index[Array.IndexOf(temp, b)];  });
		
		PrintArray(array);
	}

	public static void RearrangeNagativeAndPositiveBased(int[] array){
		int low = 0,  high = array.Length - 1, mid = low+1;
		while(mid < high){
			if(array[low] < 0){
				low++;
				mid++;
				continue;
			}
			if(array[mid] < 0){
				SwapArray(array, low, mid);
				low++;
			}
			mid++;
		}
		
		Array.Sort(array, 0, low+1);
		Array.Sort(array, low, array.Length - low);
		Array.Reverse(array, low, array.Length - low);
		PrintArray(array);		
	}
	public static void RearrangeForMaximumAndMiniMum(int[] array){
		Array.Sort(array);
		int[] temp = new int[array.Length];
		int low = 0, high = array.Length - 1, index = 0;
		while(low < high){
			if(index == 1 || (index%2) != 0){
				temp[index] = array[low];	
				low++;
			}
			else {			
				temp[index] = array[high];
				high--;
			}
			index++;
		}
		temp[index] = array[low];
		PrintArray(temp);
	} 
	
	public static void RearrangeForMaximumAndMinimum(int[] array){
		Array.Sort(array);
		int[] temp = new int[array.Length];
		int low = 0, high = array.Length - 1, index = 0;
		while(low < high){
			if(index == 1 || (index%2) != 0){
				temp[index] = array[low];	
				low++;
			}
			else {			
				temp[index] = array[high];
				high--;
			}
			index++;
		}
		temp[index] = array[low];
		PrintArray(temp);
	} 
	
	public static void ReArrangeAllNagativeElementLast(int[] array){
		List<int> negNum = new List<int>();
		List<int> posNum = new List<int>();
		
		for(int index = 0; index < array.Length; index++){
			if(array[index] < 0){
				negNum.Add(array[index]);
			}
			else {
				posNum.Add(array[index]);
			}
		}
		posNum.AddRange(negNum);
		foreach(var item in posNum){
			Console.Write(item + " ");
		}	
	}
	
	public static bool isEvenNumber(int number){
		if(number == 1 || (number%2) != 0){
			return false;
		}
		return true;
	}
	
	public static void ReArrangeAllElementEvenAndOddWise(int[] array){
		int low = 0, index = low + 1, high = array.Length - 1;
		
		while(index <=  high){
			if(isEvenNumber(array[low])){
				low++;
				index++;
				continue;
			}
			if(isEvenNumber(array[index])){
				SwapArray(array, low, index);
				low++;
			}
			index++;	
		}
		PrintArray(array);
	}
	
	public static void Main(string[] args){
		//region DS Sheet Program No 29
		//int[] arr={-1, -1, 6, 1, 9,3, 2, -1, 4,-1};
		//RearrangeValueToRespectiveIndex(arr);
		//PrintArray(arr);
		//endregion
		//region DS Sheet Program No 30
		//int[] array = { 5, 9, 2, 1, 3,4, 6, 8, 7};
		//RearrangeArrayInCycleForm(array);
		//PrintArray(array);
		//endregion
		//region DS Sheet Program No 31
		//int[] arr = {-5, -2, 5, 2, 4, 7, 1, 8, 0, -8};
		//RearrangrArrayInNegativePositiveMode(arr);
		//PrintArray(arr);
		//endregion
		//region DS Sheet Program No 32
		//int[] array = { 1, 0, 0,1, 1};
		//MoveAllZeroAtEnd(array);
		//endregion
		//region DS Sheet Program No 33
		//int[] array = {2, 1, 5, 6, 3};
		//NoOfSwapRequireToRearrangeElemntLessAndEqualToKey(array,5);
		//endregion
		//region DS Sheet Program No 34
		//int[] array = {2, 1, 5, 6, 3};
		//RearrangeArrayInWaveForm(array);
		//endregion
		//region DS Sheet Program No 35
		//int[] array = {8 , 5 , 4, 3, 1, 2, 6, 7};
		//ReArrangeArrayInSmallestAndLargestForm(array);
		//endregion	
		//region DS Sheet Program No 36
		 //	int[] arr   = {50, 40, 70, 60, 90};
       		//	int[] index = {3,  0,  4,  1,  2};
		//	ReArrangeArrayBasedOnIndex(arr, index);
		//	Console.WriteLine();
		//	int[] arr2   = {50, 40, 70, 60, 90};
       		//	int[] index2 = {3,  0,  4,  1,  2};
		//	ReArrangeArrayBasedOnIndexUsingTempArray(arr2, index2);
		//endregion	
		//region DS Sheet Program No 37
		//	int[] array = {5, 5, -3, 4, -8, 1};
		//	RearrangeNagativeAndPositiveBased(array);
		//endregion
		//region DS Sheet Program No 38
		//	int[] array = {6, 5, 4, 2, 3, 1}; 
		//	RearrangeForMaximumAndMiniMum(array);
		//endregion
		//region DS Sheet Program No 39
		//int[] arr = {-5, 7, -3, -4, 9, 10, -1, 11};	
		//ReArrangeAllNagativeElementLast(arr);
		//endregion
		//region DS Sheet Program No 40
		int[] array = { 2, 3, 4, 7, 5, 8, 10,9, 14, 16 };
		ReArrangeAllElementEvenAndOddWise(array);
		//endregion 
	}
}