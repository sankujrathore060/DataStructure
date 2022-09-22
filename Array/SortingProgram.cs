using System;
using System.Collections.Generic;

class SortingProgram {
	public static void PrintArray(int[] array){
		foreach(var item in array){
			Console.Write(item + " ");
		}
	}		

	public static void SwapArray(int[] array, int first, int next){
		array[first] = array[first] + array[next];
		array[next] = array[first] - array[next];
		array[first] = array[first] - array[next];
	}
	
	public static void SortInWaveForm(int[] array,  int n){
		Array.Sort(array);
		for(int i = 0;  i < n ;  i = i+2){
			SwapArray(array, i, i+1);		
		}
	} 

	public static void SortInAbsoluteValueUsingCollection(int[] array, int trace){
		SortedDictionary<int, List<int>> element  =  new SortedDictionary<int, List<int>>();
		int[] resultArray =  new int[array.Length];
		for(int i = 0; i < array.Length; i++){
			int currentDifference = Math.Abs(trace - array[i]); 
			if(element.ContainsKey(currentDifference)){
				
				List<int> data = element[currentDifference];
				
				data.Add(array[i]);
				
				element[currentDifference] = data;	
			}
			else {
				element.Add(currentDifference, new List<int>(){ array[i] });
				
			}
		}
		int index = 0;
		foreach(KeyValuePair<int, List<int>> item in element){
			foreach(var item_inner in  item.Value){
				Console.WriteLine(item_inner);
				resultArray[index++] = item_inner;			
			}				
		}
		PrintArray(resultArray);
	}

	public static void  SortInAbsoluteValueUsingDelegate(int[] array, int key){
		Array.Sort(array, delegate(int n, int m){ return (Math.Abs(key - n)) - (Math.Abs(key - m)); });
		PrintArray(array);
	}

	public static void Sort1ToNBySwapingAdjancetElement(int[] array, bool[] status){
		for(int index = 0; index < array.Length - 1; index++){
			if(status[index] == true){
				SwapArray(array, index, index + 1);
			}
		}
		PrintArray(array);
	}

	public static void SortArrayByFrequency(int[] array){
		Dictionary<int,int> element = new Dictionary<int, int>();
		for(int index =0; index < array.Length; index++){
			if(element.ContainsKey(array[index])){
				element[array[index]]++;
			}
			else {
				element.Add(array[index], 1);
			}
		}
		Array.Sort(array, delegate(int a, int b) { return element[b] == element[a] ? b - a  : element[b] - element[a]; });
		PrintArray(array);
	}
	public static void SortInversionArray(int[] array){
		int low = 0, high = array.Length - 1, totalPair = 0;
		while(low < array.Length - 1){
		 	if(array[low] > array[high])
			{
				totalPair++;			
			}
			if(low +1 == high){
				low++;
				high = array.Length - 1;
			}
			else {
				high--;
			}
		}
		Console.WriteLine("Total Pair is :- {0}", totalPair);	
	} 

                public static void NoOfSortRequire(int[] array){
		int[] arraySorted = new int[array.Length]; 
		array.CopyTo(arraySorted,0);
		int totalSwap = 0;
		bool IsAllreadyExist = false;
		Dictionary<int, int> element = new Dictionary<int, int>();
		Array.Sort(arraySorted);
		PrintArray(arraySorted);
		Console.WriteLine();
		PrintArray(array);
		Console.WriteLine();
		for(int index = 0; index < array.Length; index++){
			if(arraySorted[index] != array[index]){
				if((!element.ContainsKey(array[index])  && !element.ContainsValue(arraySorted[index])) || (element.ContainsKey(array[index])  && !element.ContainsValue(arraySorted[index])) || (!element.ContainsKey(array[index])  && element.ContainsValue(arraySorted[index])))
				{
					totalSwap++;
					element.Add(array[index], arraySorted[index]);
				}
				else {
					IsAllreadyExist = true;	
				}
			}
		}	
		if(!IsAllreadyExist){
			totalSwap--;
		}
		Console.WriteLine(totalSwap);
	} 	
	
	public static void SortByCustomValue(int[] array)
	{
		int count0 = 0, count1 = 0, count2 =  0, index = 0;
		int[] arraySorted = new int[array.Length];
		for(index = 0; index < array.Length; index++){
			switch(array[index]){
			case 0:
				count0++;
				break;
			case 1:
				count1++;
				break;
			case 2:
				count2++;
				break; 
			}
		}	
		index = 0;
		while(count1 > 0){
			arraySorted[index++] = 1;
			count1--;
		}
		while(count0 > 0){
			arraySorted[index++] = 0;
			count0--;
		}
		
		while(count2 > 0){
			arraySorted[index++] = 2;
			count2--;
		}
		PrintArray(arraySorted);
	}
	
	public static void SortTwoArray(int[] array1, int[] array2){
		int low = 0, high = array1.Length - 1;
		while(high >= 0 && low < array2.Length){
			if(array1[high] > array2[low]){
				array1[high ] = array1[high ] + array2[low];
				array2[low] = array1[high ] - array2[low];	
				array1[high ] = array1[high ] - array2[low];
			}
			low++;
			high--;
		}
		Array.Sort(array1);
		Array.Sort(array2);
		PrintArray(array1);
		Console.WriteLine();
		PrintArray(array2);
	}
	public static void Main(string[] args){
	
	//region DS Sheet Program No 13
	//int[] array = {8, 9, 5, 3, 4, 1, 2};
	//SortInWaveForm(array, array.Length - 1);
	//PrintArray(array);	
	//endregion

	//region DS Sheet Program No 14
		//int[] array = {8, 9, 5, 3, 4, 1, 2};
		//SortInAbsoluteValueUsingCollection(array, 8);	
		//SortInAbsoluteValueUsingDelegate(array, 8);
	//endregion	
	
	// region DS Sheet Program No 16
	//	   int[] A = { 1, 2, 5, 3, 4, 6 };
        	//	   bool[] B = { false, false, true, true, false };
	//	Sort1ToNBySwapingAdjancetElement(A, B);
	//endregion
	// region DS Sheet Program No 17
	//	  int[] arr = { 2, 5, 2, 6, -1, 9999999, 5, 8, 8, 8 };
	//	SortArrayByFrequency(arr);
	// endregion
	//region DS Sheet Program No 18
	//	SortInversionArray(new int[]{8,2,4,3,1});
	// endregion
	//region DS Sheet Program No 19
	//	NoOfSortRequire(new int[] { 101, 758, 315, 730, 472, 619, 460, 479 });
	//endregion
	// region DS Sheet Program No 20
	//	SortByCustomValue(new int[] { 1, 0, 2, 1, 0, 2, 0, 1 , 1, 2, 0});
	// endregion
	//region DS Sheet Program No 21
	SortTwoArray(new int[]{ 10,12, 25,35, 45, 58, 90 }, new int[]{ 2,5, 7,13, 17 });
	//endregion
	}
}