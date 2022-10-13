using System;

public class ArraySearch
{
	public static bool CheckForSumPair(int key, int[] arr){
	    
	    //Sort the array
	    Array.Sort(arr);
	    
	    int low = 0, high = arr.Length - 1;
	    
	    while(low < high){
	        int pairSum = arr[low] + arr[high];
	        if(pairSum == key){
	            return true;
	        }
	        else if(pairSum < key){
	            low++;
	        }
	        else {
	            high--;
	        }
	    }
	    return false;
	}
	
	public static void Main()
	{
        		//int[] arr = {12, 5, 16, 03, 18, 12, 19};
        		//int key = 562;
        
        		//if(CheckForSumPair(key, arr)){
            		//	Console.WriteLine("Exist");
        		//}
       		/else {
            			Console.WriteLine("Not Exist");
        		//}


		//Find Majority Of Element Using Moore Thorem
	}
}