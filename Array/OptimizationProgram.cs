using System;
using System.Collections.Generic;
class OptimizationProgram {
	
	public static int FindSmallestPairCountUsingBruteForce(int[] array, int k){
		int minValue = int.MaxValue,  minValueSubArrayCount = 0;
		for(int element = 0;  element < array.Length - 1; element++ ){
			int currentSum = array[element];
			int currentCounter = 1;
			if(currentSum >  k){
				if(currentSum < minValue){
					minValue = currentSum;
					minValueSubArrayCount = currentCounter;
				}	
			}
			for(int inner_element = element + 1;  inner_element < array.Length; inner_element++ ){
				currentSum = currentSum + array[inner_element];
				currentCounter++;

				if(currentSum >  k){
					if(currentSum < minValue){
						minValue = currentSum;
						minValueSubArrayCount = currentCounter;
					}	
				}
			}
		}
		Console.WriteLine(minValue);
		return minValueSubArrayCount;		
	}
	
	public static void FindSmallestPairCountUsingTwoPointer(int[] array, int k){
		int low = 0, mid = 0, minValue = int.MaxValue, minCount = 0, currentSum = 0,lowerCount = 0;
		while(mid < array.Length - 1){
			if(array[mid] > k){
				if(array[mid] <  minValue){
					minValue = array[mid];
					lowerCount = 1;
					minCount = lowerCount;
				}					
			}
			currentSum  = currentSum  + array[mid];
			bool isFirstTime = true;
		                if(currentSum > k)
			{  
				while(currentSum > k && low < mid){
					if(currentSum <  minValue){
						minValue = currentSum;
						if(isFirstTime)
						{
							lowerCount++;
						}			
						minCount = lowerCount;
					}
					if(array[low] < 0)
					{
						currentSum  = currentSum + array[low];
					}
					else {
						currentSum  = currentSum - array[low];
					}
					lowerCount--;
					low++;
					isFirstTime = false;			
				}
			}	
			else if(currentSum <= k) 
				lowerCount++;
			if(currentSum < 0){
				currentSum = 0;
				lowerCount = 0;
			}
			mid++;	
		}

		Console.WriteLine(minValue);

		Console.WriteLine(minCount);
	}
	
	public static void FindMaximumArrayOfSubKLengthUsingBruteForce(int[] array, int k){
		int maxSum = int.MinValue, length = 0, startIndex = -1, endIndex = 0;
		for(int start =0; start <= array.Length - k; start++){
			int currentSum = array[start]; 
			int counter = 1;
			int inner = start+1;
			while(inner <= (start+ (k - 1))){
				currentSum = currentSum + array[inner];	
				counter++;	
				inner++;
			}
			if(currentSum > maxSum){
				maxSum = currentSum;
				length = counter;
				startIndex = start;
				endIndex = inner - 1;
			}	
		}
		Console.WriteLine("The Max sum  in {0} pair start with index {1} to {4} of length {2} and sum is {3}", k, startIndex, length, maxSum, endIndex);
	}		
	
	public static void FindMaximumArrayOfSubKLengthUsingTwoPointer(int[] array, int k){
		int low = 0, mid = low + 1, counter = 1, high = array.Length - 1, maxSum = int.MinValue, startIndex = -1, endIndex = 0, length = 0, currentSum = array[low];
		while(low <= array.Length - k && mid <=high){
			currentSum = currentSum + array[mid];
			counter++;
			if(counter == k){
				if(currentSum > maxSum){
					maxSum = currentSum;
					length = counter;
					startIndex = low;
					endIndex = mid;	
				}
				
				currentSum = currentSum - array[low];
				counter--;
				low++;
			}
			mid++;				
		}
		Console.WriteLine("The Max sum  in {0} pair start with index {1} to {4} of length {2} and sum is {3}", k, startIndex, length, maxSum, endIndex);
	
	}

	public static void CountMinStepTogetGivenDesireArray(int[] array){
		int doublingElementCount = 0;
		int totalStep = 0; 
		Array.Sort(array);
		int index = 0;
		while(index < array.Length){
			
			if( array[index] % 2 == 0) {
				if(doublingElementCount > 0)
				{
					int doublingCount = doublingElementCount;
					while(doublingCount > 0){
						array[index]/=2;
						doublingCount--;
					}
				}
				else 
				{
					if(array[index] > 1)
					{
						while(array[index] > 1){
							array[index]/=2;
							doublingElementCount++;
							totalStep++;
						}
					}
				}
			}
			if(array[index] == 1 || array[index] % 2 != 0){
				array[index]--;
				totalStep++;
				if(array[index] != 0){
					continue;
				} 
			}
			index++;	
		}
		Console.WriteLine(totalStep);
		Console.Write("{");
		foreach(var item in array){
			Console.Write(item + ",");
		}
		Console.Write("}");
	}
	
	public static void isArrayPlandrom(int[] array){
		int low = 0, high = array.Length - 1, operationCountForMakePalindrom = 0, currentSum = 0;
		while(low < high){	
			if(array[low] != array[high]){
				currentSum = currentSum + array[low] + array[high];
				operationCountForMakePalindrom++;		
			}
			low++;
			high--;
		}
		if(operationCountForMakePalindrom > 0){
			if(array.Length %2 != 0)
			{
				currentSum += array[low];
				operationCountForMakePalindrom++;
			}
			Console.WriteLine("Operation require to make palindrom array {0} with sum {1}", operationCountForMakePalindrom, currentSum);
		}
		else {
			Console.WriteLine("Array is Allready Plaindrom");
		}	
	}

	public static void FindMaximumSumFromSubArrayUsingPrefixSum(int[] array){
		int[] prefixSum = new int[array.Length];
		int res = 0, minSum = 0;
		prefixSum[0] = array[0]; 
		for(int i = 1; i < array.Length; i++){
			prefixSum[i] = prefixSum[i-1] + array[i]; 
		}
		
		for(int j = 0; j <array.Length; j++){
			res = Math.Max(res, prefixSum[j] - minSum);
			minSum = Math.Min(minSum, prefixSum[j]);
		}
		Console.WriteLine(res);
	}

	public static void FindMaximumSumFromSubArrayUsingPrefixSumTillK(int[] array, int k){
		int[] prefixSum = new int[array.Length];
		int res = 0, minSum = 0;
		List<int> lastElement = new List<int>();
		prefixSum[0] = array[0]; 
		for(int i = 1; i < array.Length; i++){
			prefixSum[i] = prefixSum[i-1] + array[i]; 
		}
		
		for(int j = 0; j <array.Length; j++){
			res = Math.Max(res, prefixSum[j] - minSum);
			lastElement.Add(res);
			minSum = Math.Min(minSum, prefixSum[j]);
		}
		lastElement.Sort(delegate(int a, int b) { return b - a; });
		//Console.WriteLine(res);

		foreach(var item in lastElement){
			if(k  > 0)
			{
				Console.Write(item + " ");
			}
			else {
				break;
			}
			k--;
		}
	}	

	public static void FindSmallestIntValueThatNotPartOfAnySubset(int[] array){
		int minElement = array[0], result = 0;
		
		Array.Sort(array);
		minElement = array[0];
		for(int index = 0; index < array.Length; index++){
			if(array[index] <= minElement){
				result+= array[index];	
				minElement = result + 1;
			}
			else {
				Console.WriteLine(minElement); 
				break;	
			}
		}		
	}
 
	public static void Main(string[] args){
		//region DS Sheet program No 
		//int[] arr = {- 8, 1, 4, 15, -3, 2, -6};
		//Console.WriteLine(FindSmallestPairCountUsingBruteForce(arr, 18));
		//FindSmallestPairCountUsingTwoPointer(arr, 18);
		//endregion

		//region Ds Sheet Program No
		//int[] array = {-5,4,3, 2, 8, 6};
		//FindMaximumArrayOfSubKLengthUsingBruteForce(array, 2);
		//FindMaximumArrayOfSubKLengthUsingTwoPointer(array, 2);
		//endregion
		//region DS Sheet Program No
		//int[] array = {2, 3};
		//CountMinStepTogetGivenDesireArray(array);
		//endregion

		//region DS Sheet Program No
		//int[] array = {11, 14, 15, 99};
		//isArrayPlandrom(array);
		//endregion
		//region DS Sheet Program No
		//int[] array = { -2, -3, 4, -1, -2, 1, 5, -3 };
		//FindMaximumSumFromSubArrayUsingPrefixSum(array);
		//int[] array2 = { 4, -8, 9, -4, 1, -8, -1, 6 };
		
		//FindMaximumSumFromSubArrayUsingPrefixSum(array2);
		//endregion
		//region DS sheet Program No
		//int[] array = {4, -8, 9, -4, 1, -8, -1, 6};
		//FindMaximumSumFromSubArrayUsingPrefixSumTillK(array, 4);
		//endregion 

		//region DS Sheet Program No
		int[] array =  {1, 2, 5, 10, 20, 40};
		FindSmallestIntValueThatNotPartOfAnySubset(array);
		//endregion
		}
}