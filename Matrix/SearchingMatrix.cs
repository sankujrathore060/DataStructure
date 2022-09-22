using System;
public class SearchingMatrix{
	
	public static int FindFirstIndexFromNums(int[] nums){
		int low = 0, high = nums.Length - 1;
		while(low <= high){
			int mid = (low+high)/ 2;
			if((mid == 0 || nums[mid - 1] == 0) && nums[mid] == 1){
				return mid;
			}
			else if(nums[mid] == 0){
				low = mid+1;
			} 
			else{
				high = mid-1;
			}
		}
		return -1;
	}

	public static void FindIndexOfMaximumOnes(int[][] matrix){
		int rowOfMaximumOne = -1, totalOnesCount = 0;
		for(int index = 0; index < 4; index++){
			int firstOneIndex =	FindFirstIndexFromNums(matrix[index]);
			if(firstOneIndex > -1){
				int currentOnesCount = matrix.GetLength(0) - firstOneIndex;
				if(totalOnesCount < currentOnesCount){
					totalOnesCount = currentOnesCount;
					rowOfMaximumOne  = index + 1;
				}
			}
		}
		Console.WriteLine("Highest Ons is {0} at row {1}", totalOnesCount, rowOfMaximumOne);
	}
	
	public static void Main(string[] args){
		 int[][] mat = new int[][]
    {
        new int[] {0, 0, 0, 1},
        new int[] {0, 1, 1, 1},
        new int[] {0, 0, 1, 1},
        new int[] {0, 0, 0, 0}
    };
		FindIndexOfMaximumOnes(mat);
	}
}