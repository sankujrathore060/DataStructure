using System;
using System.Collections.Generic;
class SearchingProgram {
	
	public static void PrintArray(int[] array){
		foreach(var item in array){
			Console.Write(item + " ");
		}
		Console.WriteLine();
	} 

	public static int FindNonRepeatingElementUsingXor(int[] array, int length){
		int searchElement = 0;
		foreach(var item in array){
			searchElement = searchElement ^ item;
		}
		return searchElement;					
	}
	
	public static int FindNonRepeatingElementUsingMathFormulla(int[] array, int length){
		// nonrepeatitem = 2*(sum of all item with not repeated) - (sum of all array item);
		List<int> item =  new List<int>();
		int sumOfItemWithnotDuplicate = 0, sumOfAllItem = 0;
		for(int index = 0; index <= length; index++){
			if(!item.Contains(array[index])){
				sumOfItemWithnotDuplicate = sumOfItemWithnotDuplicate + array[index];
				item.Add(array[index]);		
			}
			sumOfAllItem = sumOfAllItem + array[index];
		}
		return (2*sumOfItemWithnotDuplicate) - sumOfAllItem;				
	}

	public static int FindNonRepeatingElementUsingEventOddIndexCompare(int[] array, int length){
		int low = 0;
		int high = length;
		
		while(low < high)
		{
		
			int mid = low + high / 2;
			if(array[mid] == array[mid^1]){
				low = mid + 1;				
			}
			else {
				high = mid - 1;
			}
		}	
		return array[low]; 
	}

	public static int FindRepeatingElementUsingMathFormulla(int[] array, int length){
		//Sum on n natual number is (n-1)*n/2
		int totalSum = 0;
		foreach(var item in array){
			totalSum = totalSum + item;
		}
		return (totalSum - (((length - 1)*length)/2));
	}
	public static int FindRepeatingElementUsingCollection(int[] array, int length){
		HashSet<int> element =  new HashSet<int>();

		foreach(var item in array){
		   if(element.Contains(item))
		  {
		     return item;
		  } 
		element.Add(item);
		}
		return -1;
	}
	public static int FindRepeatingElementUsingXOR(int[] array, int length){
		int finalRepeatingElement = 0, index = 0;
		for(index = 0; index < length; index++){
			finalRepeatingElement = finalRepeatingElement ^ (index + 1) ^ array[index];
		}
		finalRepeatingElement = finalRepeatingElement ^ array[length];
		return finalRepeatingElement;	
	}

	public static bool IsXSumOfTwoElementUsingTwoPointerTechnique(int[] array, int sum){
		Array.Sort(array);
		int leftPointer = 0, rightPointer = array.Length - 1;
		while(leftPointer < rightPointer){
			if(array[leftPointer] + array[rightPointer] == sum)
			{
				Console.WriteLine(array[leftPointer] +" "+ array[rightPointer]);
				return true;
			}
			else if(array[leftPointer] + array[rightPointer] > sum)
				rightPointer--;
			else
				leftPointer++;		
		}
		return false;
	} 

	public static bool IsXSumOfTwoElementUsingHashSet(int[] array, int sum)
	{
		HashSet<int> element = new HashSet<int>();
		foreach(var item in array){
			var result = sum - item;
			if(element.Contains(result))
				return true;
			element.Add(item);
		}	
		return false;
	}
	public static bool IsXSumOfThreeElementUsingTwoPointerTechnique(int[] array, int sum)
	{
		for(int i = 0; i < array.Length - 3; i++){
			int leftPart = i+1, rightPart = array.Length - 1;
			while(leftPart < rightPart){
				if(array[i] + array[leftPart]+ array[rightPart] == sum){
					return true;
				}
				else if(array[i] + array[leftPart]+ array[rightPart] > sum){
					rightPart--;
				}
				else{
					leftPart++;
				}
			}	
		}
		return false;
	}
	public static bool IsXSumOfThreeElementUsingHashSet(int[] array, int sum){
		
			for(int i = 0; i < array.Length - 2; i++){

			HashSet<int> element = new HashSet<int>();
			for(int j =  i + 1; j < array.Length; j++){
				var result = (sum - array[i]) - array[j];
				Console.WriteLine(result);
				if(element.Contains(result)){
					return true;			
				}  
				element.Add(array[j]);
			}	
		}
		return false;	
	}

	public static int FindMajorityNBy2ElementUsingTwoLoop(int[] array){
		int finalCounter = 0;
		int finalIndex = -1;
		
		for(int i = 0; i < array.Length - 1; i++){
			int counter = 0;
			for(int j =  i; j < array.Length; j++){
				if(array[i] == array[j]){
					counter++;	
				}

			}
			if(counter > finalCounter){
				finalCounter = counter;
				finalIndex = i;
			}
		}
		if(finalCounter > array.Length / 2){
			return array[finalIndex];
		}
		return -1;
	}

	public static int FindMajorityNBy2ElementUsingThreePointerTechnique(int[] array){
		Array.Sort(array);
		int low = 0,  mid = 0, high = array.Length - 1;
		int finalCounter = 0;
		int finalElement = 0;

		int counter = 0, element = 0;
		while(mid <= high){
			
			if(array[low] == array[mid]){
				counter++;
				element = array[low];
				mid++;
			}
			else {
				if(counter > finalCounter){
					finalCounter = counter;
					finalElement = element;
				}
				else if(counter == finalCounter){
					finalElement = 0;
				}
				counter = 0;
				element = 0;
				low++;
			}	
		}
				if(counter > finalCounter){
					finalCounter = counter;
					finalElement = element;
				}
				else if(counter == finalCounter){
					finalElement = 0;
				}	
		if(finalCounter > (array.Length/2) && finalElement > 0){
			return finalElement;
		}
		return -1;
	}

	public static void FindMajorityNBy2ElementUsingMooreVoating(int[] array){
		int vote = 1, elementIndex = 0, majorityCount = 0;
		

		for(int index = 1; index < array.Length; index++){
			if(array[elementIndex] == array[index]){
				vote++;
				elementIndex = index;
			}
			else {
				vote--;
				if(vote == 0){
				  vote = 1;
				  elementIndex = index;
				}
			}
		}
		Console.WriteLine(elementIndex+" "+ array[0]);
		for(int index = 0; index < array.Length; index++){
			if(array[index] == array[elementIndex]){
				Console.WriteLine(array[elementIndex]);
		
				majorityCount++;
			}
		}
		if(majorityCount > 1)
		Console.WriteLine("Majority Of Element {0} is {1}", array[elementIndex], majorityCount);
		else
		Console.WriteLine("No Majority of element found.");	
	}

	public static int FindMajorityNBy2ElementUsingDictionary(int[] array){
		Dictionary<int, int> elements = new Dictionary<int, int>();
		for(int index =0; index < array.Length; index++){
			if(elements.ContainsKey(array[index])){
				elements[array[index]]++;
				if(elements[array[index]] > array.Length/ 2){
					return array[index];			
				}
			}
			else {
				elements.Add(array[index], 1);
			}	
		}
		return -1;	
	}
	
	public static int FindEqibiliramIndex(int[] array){
		for(int index = 0; index < array.Length; index++){
			int leftSum = 0, rightSum = 0;
			for(int j = 0; j < index; j++){
				leftSum += array[j];	
			}
			for(int j = index + 1; j < array.Length; j++){
				rightSum += array[j];	
			}
			if(leftSum == rightSum){
				return index;
			}
		}
		return -1; 	
	}

	public static int FindEqibiliramIndexInNTime(int[] array){	
		int sum = 0, leftSum = 0;
		for(int i=0; i < array.Length; i++){
			sum += array[i];
		}	
		for(int i = 0; i < array.Length; i++){
			sum -= array[i];
			if(sum == leftSum){
				return i;
			}
			leftSum = leftSum + array[i];					
		}	
		return -1;
	}
	public static string CeilingSortedArrayLinearSerach(int[] array, int x){
		for(int index = 0; index < array.Length; index++){
			if(x == array[index]){
				return "Floor:" + array[index] + "Ceil:" + array[index];			
			}
			if(index == 0 && x < array[index]){
				return "Floor: X Ceil:" + array[index];			
			}
			if(index == array.Length - 1 && x > array[index]){
				return "Floor: " + array[index]  + "Ceil: X";			
			}
			if(x > array[index] && x < array[index + 1]){
				return "Foor: " + array[index] + "Ceil : " + array[index + 1];
			}		
		}
		return "No record Found";
	}
	public static string CeilingSortedArrayBinarySerach(int[] array, int x){
		int low = 0, high = array.Length - 1;
		while(low <= high){
			int mid = (low + high) / 2;
			if(array[mid] == x){
				return "Floor:" + array[mid] + "Ceil:" + array[mid];	
			}
			else if(mid == 0 && array[mid] > x )				
			{				
				return "Floor: X Ceil:" + array[mid];
			}
			else if(mid == array.Length -1 && array[mid] < x )				
			{	
				return "Floor: " + array[mid]  + "Ceil: X";
			}
			else if(low == mid && mid == high){
				return "Floor: X Ceil: X";
			}
 
			else if(x > array[mid] && x < array[mid + 1]){
				return "Floor: " + array[mid]  + "Ceil:" + array[mid + 1];
			}
			else if(x < array[mid] && x  > array[mid -1]){
				return "Floor: " + array[mid - 1]  + "Ceil:" + array[mid];
			}
			else if(array[mid] > x){
			 high = mid - 1;
			}
			else {
			low = mid + 1;
			}				
		}

				return "Floor: X Ceil: X";
	}
	public static int FindPeekElementUsingLinearSearch(int[] array){
		for(int i = 0; i < array.Length; i++){
			if(array.Length <= 1){
				return -1;
			}
			if(i == 0){
				if(array[i] > array[i+1])
				{
					return array[i];
				}		
			}
			else if(i == array.Length - 1){
				if(array[i] > array[i-1])
				{				
					return array[i];
				}
			}
			else if(array[i] > array[i - 1] && array[i] > array[i + 1]){
				return array[i];
			}
		}
		return -1; 		
	}
	
	public static string IndexesOfSubArrayEqualToSum(int[] array, int sum){
		int currentSum = array[0], start = 0;
		if(currentSum == sum)
			return "Sum start with :-" + start;
		for(int i = 1; i  < array.Length; i++){
			currentSum = currentSum + array[i];	
			if(currentSum == sum)
				return "Sum start with :-" + start + " And " + i;	
			while(currentSum > sum && start < i -1){
				currentSum = currentSum - array[start];
				start++;	
			}
			
		}	
		return "No Record Found";
	}

	public static string CloasestPairEqualToSumFromTwoArray(int[] array1, int[] array2, int element){
		int firstArrayIndex = 0, secoundArrayIndex = array1.Length - 1, difference = int.MaxValue, low = 0, high = array2.Length - 1;
		while(low < array1.Length && high >= 0){
			int innerDiff = Math.Abs((array1[low] + array2[high]) - element);
			if(innerDiff < difference){
				firstArrayIndex = low;
				secoundArrayIndex = high;
				difference = innerDiff;
			}
			if((array1[low] + array2[high]) > element){
				 high--;
			}
			else {
				low++;
			}
		}
		return  firstArrayIndex+" "+secoundArrayIndex;
	}

	public static string CloasestPairEqualToSumFromSingleArray(int[] array, int element, int n){
		int firstIndex = 0, secoundIndex = 0, difference = int.MaxValue,  low = 0, high = n;
		while(low < high){
			int innerDiff = Math.Abs((array[low] + array[high]) - element);
			if(innerDiff  < difference){
				difference = innerDiff;
				firstIndex = low;
				secoundIndex = high;
			}
			if((array[low] + array[high])  > element)
				high--;
			else 
				low++;		
		}
		return array[firstIndex] +" + "+ array[secoundIndex] + " = " + (array[firstIndex] + array[secoundIndex]) + " Closest Nearest to " + element; 
	}
	
	public static void Main(string[] args){
		
		//region DS Sheet Program no 1
		 //int[] array = {5, 2, 5, 3, 6, 3, 6};		
		 //PrintArray(array);
		 //Console.WriteLine(FindNonRepeatingElementUsingXor(array, array.Length - 1));
		 //Console.WriteLine(FindNonRepeatingElementUsingMathFormulla(array, array.Length - 1));
		 //Array.Sort(array);
		 //Console.WriteLine(FindNonRepeatingElementUsingEventOddIndexCompare(array, array.Length - 1));
		//endregion 

		//region DS Sheet Program no 2
		 //int[] array = {1, 2, 3, 4, 4, 7, 5, 6};		
		 //PrintArray(array);
		 //Console.WriteLine(FindRepeatingElementUsingMathFormulla(array, array.Length));
		 //Console.WriteLine(FindRepeatingElementUsingCollection(array, array.Length));
		 //Console.WriteLine(FindRepeatingElementUsingXOR(array, array.Length - 1));
		//endregion 

		//region DS Sheet Program no 3
		//int[] array = {1, 2, 3, 4, 4, 7, 5, 6};
		 
		//Console.WriteLine(IsXSumOfTwoElementUsingTwoPointerTechnique(array, 14));
		//Console.WriteLine(IsXSumOfTwoElementUsingHashSet(array,14));
		//endregion

		//region DS Sheet Program no 4
		//int[] array = {1, 2, 3, 4, 7, 5, 6};
		//Console.WriteLine(IsXSumOfThreeElementUsingTwoPointerTechnique(array, 12));
		//Console.WriteLine(IsXSumOfThreeElementUsingHashSet(array,12));
		//endregion
				
		//region DS Sheet Program no 5
		//int[] array = { 2, 2, 3, 1, 2 };
		//Console.WriteLine(FindMajorityNBy2ElementUsingTwoLoop(array));
		//Console.WriteLine(FindMajorityNBy2ElementUsingThreePointerTechnique(array));			
		
		//FindMajorityNBy2ElementUsingMooreVoating(array);
		//Console.WriteLine(FindMajorityNBy2ElementUsingDictionary(array));
		// endregion

		//region DS Sheet Program no 6 
		//int[] array = { -7, 1, 5, 2, -4, 3, 0 };
		//Console.WriteLine(FindEqibiliramIndex(array));
		//Console.WriteLine(FindEqibiliramIndexInNTime(array));			
		//endregion
		
		//region DS Sheet Program no 7 
		//int[] array = { 1, 6, 12, 17, 19, 21 };	
		//Console.WriteLine(CeilingSortedArrayLinearSerach(array, 2));
		//Console.WriteLine(CeilingSortedArrayBinarySerach(array, 0));
		//endregion

		//region DS Sheet Program No 8
		//int[] array = { 10, 20, 15, 2, 23, 90, 67 };
		//Console.WriteLine(FindPeekElementUsingLinearSearch(array));
		//endregion
		
		//region DSmSheet Program No 9
 		//int[] array ={ 15, 2, 4, 8,9, 5, 10, 23 };
		//Console.WriteLine(IndexesOfSubArrayEqualToSum(array, 23));
		//endregion 
		
		//region DS Sheet Program No 20	
		 //int []ar1 = {1, 4, 5, 7};
        		//int []ar2 = {10, 20, 30, 40};
		//Console.WriteLine(CloasestPairEqualToSumFromTwoArray(ar1, ar2, 38));
		//endRegion

		//region DS Sheet Program No 21
		int []ar = {10, 20, 30, 40};
		Console.WriteLine(CloasestPairEqualToSumFromSingleArray(ar, 32, ar.Length - 1));
		//endRegion
	}
}