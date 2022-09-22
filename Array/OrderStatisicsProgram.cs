using System;
using System.Collections.Generic;
using System.Linq;
public class OrderStatisicsProgram{
	
	public static int FindKthSmallestElementUsingSort(int[] array,int k){
		Array.Sort(array);
		return array[k - 1];
	}
	
	public static int FindKthSmallestElementUsingSortedSet(int[] array,int k){
		SortedSet<int> set = new SortedSet<int>();
		for(int index =0; index< array.Length; index++){
			set.Add(array[index]);
		}
		foreach(var item in set){
			if(k == 1){
				return item; 
			}
			k--;
		}
		return 0;
	}

	public static int FindKthHighestElementUsingSort(int[] array,int k){
		Array.Sort(array,  delegate(int a, int b) { return b - a; });
		return array[k - 1];
	}
	
	public static int FindKthHighestElementUsingSortedSet(int[] array,int k){
		SortedSet<int> set = new SortedSet<int>();
		for(int index =0; index< array.Length; index++){
			set.Add(array[index]);
		}
		 k = set.Count - (k-1);	
		foreach(var item in set){
			if(k == 1){
				return item; 
			}
			k--;
		}
		return 0;
	}	
	public static int FindKthSmallestElementFromArray(int[,] array, int n, int k){
		
		int[] temp = new int[n*n];
		int index = 0;
		for(int row = 0; row < n; row++){
			for(int column = 0;column < n; column++){
				temp[index] = array[row, column];
				Console.WriteLine(temp[index]);
				index++;
			}
		}
		Array.Sort(temp);
		
		return temp[k-1];
	}
	public static int KthLargestSumInContinuesArray(int[] array, int k){
		List<int> data = new List<int>();
		for(int index = 0; index < array.Length; index++){
			data.Add(array[index]);
			int prevSum = array[index];
			for(int inner = index+1; inner < array.Length; inner++){
				prevSum = prevSum + array[inner];
				data.Add(prevSum);				
			}	
		}
		 k = data.Count - (k - 1);
		data.Sort();
		foreach(var item in data){
			if(k == 1){
				return item;
			}	
			k--;
		}
		return 0;		
	}

	public static double FindMean(int[] array){
		double sumOfElement = 0;
		foreach(var item in array){
			sumOfElement = sumOfElement + (double)item;
		}
		return ((double)(sumOfElement/array.Length));
	}
	public static double FindMedium(int[] array){
		Array.Sort(array);
		if((array.Length % 2) != 0){
			return array[(array.Length/2)];
		}
		return (double)(array[(array.Length - 1) / 2] + array[(array.Length/2)])/ 2;
	}
	public static void FindMeanAndMedium(int[] array){
		Console.WriteLine(FindMean(array) +"  " + FindMedium(array));
	}

	public static void FindLargestSumFromContinuesSubArrayUsingKadaneAlgorithem(int[] array){
		int maxSum = int.MinValue, currentSum = 0;
		for(int index = 0; index < array.Length; index++){
			currentSum = currentSum + array[index];
			maxSum = Math.Max(currentSum, maxSum);
			if(currentSum < 0){
				currentSum = 0;
			}
		}
		Console.WriteLine(maxSum);
	}

	public static void FindLargestSumFromContinuesSubArrayUsingBruteForceApproch(int[] array){
		int maxSum =  int.MinValue;
		for(int index = 0; index < array.Length - 1; index++){
			int currentSum = array[index];
			maxSum = Math.Max(maxSum, currentSum);
			for(int inner = index + 1; inner < array.Length;  inner++){
				
				currentSum += array[inner];
				maxSum = Math.Max(maxSum, currentSum);					
			}
		}

		Console.WriteLine(maxSum);
	}

	public static void FindKLargestElementSumFromArray(int[] array, int k){
		List<int> sumOfElements = new List<int>();
		int currentSum = 0;
		for(int index = 0; index < array.Length; index++){
			currentSum = currentSum + array[index];
			sumOfElements.Add(currentSum);
			if(currentSum < 0){
				currentSum = 0;
			}
		}
		sumOfElements.Sort(delegate(int a, int b) { return b - a; });
		foreach(var item in sumOfElements){
			if(k == 0)
			   break;
			Console.Write(item + " ");
			k--;
		}
	}

	public static void FindKMostOccurence(int[] array, int k){
		Dictionary<int, int> set = new Dictionary<int, int>();
		
		for(int index =0; index < array.Length; index++){
			if(set.ContainsKey(array[index])){
				set[array[index]]++;
			}
			else {
				set.Add(array[index], 0);
			}
		}
		List<int> keys = set.Keys.ToList();
		keys.Sort(delegate(int a, int b) { return  set[b] == set[a] ? b - a : set[b] - set[a]; });
		
		foreach(var item in keys){
			if(k > 0)
			{
				Console.Write(item + " ");
			}
			else {
			break;
			}
			k--;
		}
	}
	
	public static void Main(string[] args){
		//region DS Sheet Program No 40
		//int[] array = { 5 , 4 , 9, 2 , 6 , 7, 3, 1};
		//Console.WriteLine(FindKthSmallestElementUsingSort(array, 3));
		
		//int[] array2 = { 5 , 4 , 9, 2 , 6 , 7, 3, 1};
		//Console.WriteLine(FindKthSmallestElementUsingSortedSet(array2, 3));
		
		//int[] array3 = { 5 , 4 , 9, 2 , 6 , 7, 3, 1};
		//Console.WriteLine(FindKthHighestElementUsingSort(array3, 3));
		
		//int[] array4 = { 5 , 4 , 9, 2 , 6 , 7, 3, 1};
		//Console.WriteLine(FindKthHighestElementUsingSortedSet(array4, 3));
		//endregion				
		//region DS Sheet Program No 41
		 // int [,]mat = { { 10, 20, 30, 40 },
                   	//	{ 15, 25, 35, 45 },
                   	//	{ 25, 29, 37, 48 },
                   	//	{ 32, 33, 39, 50 } };
		//Console.WriteLine(FindKthSmallestElementFromArray(mat, 4, 7));
		//endregion
		//region DS Sheet Program No 42
		//int[] a = {10, -10, 20, -40}; 
		//Console.WriteLine(KthLargestSumInContinuesArray(a, 6));
		//endregion
		//region DS Sheet Program No 43
        		//int[] a = { 1, 3, 4, 2, 7, 5, 8, 6 };
		//FindMeanAndMedium(a);
		//endregion
		//region DS Sheet Program No 44
		//int [] a = {1, -3, 4, 2, 7, 5, 8, 6};
		//FindLargestSumFromContinuesSubArrayUsingKadaneAlgorithem(a);
		//FindLargestSumFromContinuesSubArrayUsingBruteForceApproch(a);
		//endRegion

		//region DS Sheet Program No 45
		//int[] a = {-2, -3, 4, -1, -2, 1, 5, -3};
		//FindKLargestElementSumFromArray(a, 3);
		//endregion

		//region DS Sheet Program No 46
		int[] a = {2 , 4 , 1 , 3 , 2, 4, 9, 1};
		FindKMostOccurence(a, 3);
		//endregion		
	}
}