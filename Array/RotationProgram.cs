using System;
class RotationProgram{
	
	public static void SwapArray(int[] array, int firstIndex, int secoundIndex){
		array[firstIndex] = array[firstIndex] + array[secoundIndex];
		array[secoundIndex] = array[firstIndex] - array[secoundIndex];
		array[firstIndex] = array[firstIndex] - array[secoundIndex];
	}
	public static void PrintArray(int[] array){
		foreach(var item in array){
			Console.Write(item + " ");
		}
	}
	public static void SimpleRotationUsingTempArray(int[] array, int d){
		int[] temp  = new int[array.Length];
		int newindex = 0;	
		
		for(int index = d; index < array.Length; index++){
			temp[newindex++] = array[index];	
		}

		for(int index = 0; index <= d-1; index++){
			temp[newindex++] = array[index];	
		}
	
		for(int index = 0; index < temp.Length; index++){
			array[index] = temp[index];	
		}
		PrintArray(array);
	}
	
	public static void SimpleRotationUsingSimpleLoop(int[] array, int d){
		while(d > 0){
			int last = array[0];
			for(int i = 1; i < array.Length; i++){
				array[i - 1] = array[i];			
			}
			array[array.Length - 1] = last;
			d--;
		}
		Console.WriteLine();
		PrintArray(array);
	}
	
	public static void ReverseArray(int[] array, int start, int end){
		while(start < end){
			SwapArray(array, start, end);
			start++;
			end--;
		}
	}	
	public static void RetationUsingReversalAlgorithem(int [] array, int d, int n){
		ReverseArray(array, 0, n -1);
		ReverseArray(array, n - d, n - 1);
		ReverseArray(array, 0, n - (d + 1));
		PrintArray(array);
	}

	public static int FindGCD(int a, int b){
		if(b == 0){
			return a;		
		}
		else {
			return FindGCD(b, a%b);
		}
	}

	public static void RotationUsingJungglingAlgorithem(int[] array, int d, int n){
		d = d%n;
		int gcd = FindGCD(d, n), temp = 0, j = 0, k = 0;
		for(int index = 0; index  < gcd; index++){
			
			temp = array[index];
			j = index;
			while(true){
				k = (j + d) % n;
				
				if(array[k] == array[index])
					break;
				array[j] = array[k];
				j = k;
			}	
			array[j] = temp;
		}
		Console.WriteLine();
		PrintArray(array);
	} 
	public static void RotationRightUsingJungglingAlgorithem(int[] array, int d, int n){
		d = d%n;
		int gcd = FindGCD(d, n), temp = 0, j = 0, k = 0;
		
		for(int index = 0; index  < gcd; index++){			
			temp = array[index];
			j = index;
			while(true){
				k = j - d;
				if(k < 0){
					k = n + k;
				}
				Console.WriteLine("K is :- " + k + " ?");	
				if(k == index)
				   break;
				array[j] = array[k];
				j = k;
			}	
			array[j] = temp;
		}
		Console.WriteLine("Right");
		PrintArray(array);
	} 
	
	public static int FindHighestRotationSumWithPosition(int[] array){
		int sum =  int.MinValue;
		
		for(int i = 0; i < array.Length; i++){		
			int currentSum = 0;
			for(int j= 0; j <  array.Length; j++ ){
				int index = (i + j) % array.Length;
				currentSum += j * array[index];			
			}	
			sum = Math.Max(sum, currentSum);	
		}
		return sum;
	}
	
	public static int FindHighestRotationSumWithPositionUsingFirstFormula(int[] array){
		int currentSum = 0, prevVal = 0;
		
		for(int i = 0; i < array.Length; i++){
			currentSum += array[i];
			prevVal += (i * array[i]); 
		}
		
		int res = prevVal;
		
		for(int i = 1; i < array.Length; i++){
			int currentVal = prevVal - (currentSum - array[i - 1]) + (array[i -1] * (array.Length - 1));
			prevVal = currentVal;
			res = Math.Max(res, currentVal);	
		}
		return res;
	}	
	
	public static int GetRotaionCountForSortedArray(int[] array){
		for(int index = 0; index < array.Length - 1; index++){
			if(array[index] > array[index + 1])
				return index + 1;
		}
		return 0;
	}
	public static int GetRotaionCountForSortedArrayUsingBinarySearch(int[] array){
		int low = 0, high = array.Length - 1;
		while(low < high){
			int mid = (low + high) / 2;
			if(array[mid] > array[mid + 1])	{
				return mid + 1;
			}
			if(array[mid] < array[low]){
				high = mid;	
			}
			else {
				low = mid + 1;
			}
		}
		return 0;
	}
	
	public static int FindLowestElement(int[] array){
		int low = 0, high = array.Length - 1;
		if(array.Length == 1){
			return array[0];
		}
		while(low < high){
			int mid = (low + high) / 2;
			Console.WriteLine(low +"-"+ mid +"-"+high);
			if(mid == low)
				return Math.Min(array[low], array[high]);
			if(array[mid] < array[mid +1] && array[mid] < array[mid -1])
				return array[mid];
			if(array[mid] > array[mid +1] && array[mid] > array[mid -1])
				return array[mid+1];
			if(array[mid] < array[high] && array[mid] < array[mid +1])
				high = mid - 1;
			else
				low = mid + 1;
		}
		return 0;
	}
	
	public static void reverse(int[] array, int firstIndex, int lastIndex){
		while(firstIndex <  lastIndex){
			array[firstIndex] = array[firstIndex] + array[lastIndex];
			array[lastIndex] = array[firstIndex] - array[lastIndex];
			array[firstIndex] = array[firstIndex] - array[lastIndex];
			firstIndex++;
			lastIndex--;
		}
	}

	public static void CalculateRotationUsingRevarsalAlgo(int[] array, int start, int end, int rotations){
			reverse(array, start, end);

			reverse(array, start, start + rotations - 1);
			reverse(array, start + rotations, end);
	}

	public static void RotationProgramWithQueries(int[] array, int[][] queries, int rotations, int index){		
		
		PrintArray(array);
		
		Console.WriteLine();
		for(int i = 0; i < rotations; i++){
			int start = queries[i][0];
			int end = queries[i][1];
			
			Console.WriteLine(start +"-"+end);
			CalculateRotationUsingRevarsalAlgo(array, start , end, 1);
		}
		
		Console.WriteLine();
		PrintArray(array);
		Console.WriteLine();
		Console.WriteLine(array[index]);		
	}

	public static void RearrangeArray(int[] array, int n){
		int[] finalArray = new int[array.Length];
		for(int i = 0; i < array.Length; i++){
			finalArray[array[i]] = 
		}
	} 
		
	public static void Main(string[] args){
		//region DS Sheet Program No	
		//	SimpleRotationUsingTempArray(new int[]{1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 }, 3);
		//	SimpleRotationUsingSimpleLoop(new int[]{1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 }, 3);
		//endregion
		//region DS Sheet Program No
		//	int[] array =new int[]{1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 };
			//RetationUsingReversalAlgorithem(array, 4, array.Length);
		//	RotationUsingJungglingAlgorithem(array, 4, array.Length);
			
		//	int[] array2 =new int[]{1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 };
		//	
		//	RotationRightUsingJungglingAlgorithem(array2, 4, array2.Length);
		//endregion	
		//region DS Sheet Progrtam No
		//	int[] array = { 4, 5, 1, 2, 3};
		//	Console.WriteLine(FindHighestRotationSumWithPosition(array));
		//	Console.WriteLine(FindHighestRotationSumWithPositionUsingFirstFormula(array));
		//endregion
		// region DS Sheet Program No
		//	int[] array = {3, 4, 5,1,2};
		//	Console.WriteLine(GetRotaionCountForSortedArray(array));
		//	Console.WriteLine(GetRotaionCountForSortedArrayUsingBinarySearch(array));
		//endregion
		// region Ds Sheet Program No
		//	int[] array = { 3, 4, 5 ,6, 7, 8, 9, 1, 2};
		//	Console.WriteLine(FindLowestElement(array));
		//endregion	
		//region DS Sheet Program No
		 //  int[] arr = { 1, 2, 3, 4, 5 };
  
        		//int rotations = 2;
        		// int[][] ranges = {new int[] { 0, 2 },
                               // new int[]{ 0, 3 } };
		//int index = 1;
		//RotationProgramWithQueries(arr, ranges , rotations, index);
		//endregion
	}
}