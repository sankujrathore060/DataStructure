using System;

class MaximumSumOfNonAdjanctElement{
	
	public static int Approach1(int[] nums, int index){
		if(index < 0){
			return 0;
		}
		if(index == 0){
			return nums[0];
		}
		int include = Approach1(nums, index - 2) + nums[index];
		int notInclude = Approach1(nums, index - 1);
		return Math.Max(include, notInclude);
		
	}
	public static int Approach2(int[] nums, int index, int[] dp){
		if(index < 0){
			return 0;
		}
		if(index == 0){
			return nums[0];
		}
		if(dp[index] != -1){
			return dp[index];
		}
		int include = Approach2(nums, index - 2, dp) + nums[index];
		int notInclude = Approach2(nums, index - 1, dp);
		dp[index] = Math.Max(include, notInclude);
		return dp[index];
	}
	public static int Approach3(int[] nums){
		//create dp
		int[] dp = new int[nums.Length];
		
		// initialize base condition
		dp[0] = nums[0];
		
		for(int index = 1; index < nums.Length; index++){
			int include = int.MinValue, notInclude = int.MinValue;
			if(index - 2 >= 0)
			 	include = dp[index - 2] + nums[index];
			notInclude = dp[index - 1];
			dp[index] = Math.Max(include, notInclude);
		}
		return dp[nums.Length-1];
	}

	public static int Approach4(int[] nums){
		
		int prev1 = 0;
                                   int  prev2 = nums[0];
		int ans = 0;
		for(int index = 1; index < nums.Length; index++){
			int include = int.MinValue, notInclude = int.MinValue;
			if(index - 2 >= 0)
			 	include = prev1 + nums[index];
			notInclude = prev2;
			ans = Math.Max(include, notInclude);
			prev1= prev2;
			prev2 = ans;
		}
		return ans;
	}
	public static void Main(string[] args){
		Console.WriteLine("Enter Array");
		string[] inputs = Console.ReadLine().Split(new char[]{' '});
		int[] nums  = new int[inputs.Length];
		for(int index = 0; index < inputs.Length; index++){
			nums[index] = int.Parse(inputs[index]);
		}	

		//Recursion	
		//int maxSum = Approach1(nums, inputs.Length-1);	
		//Console.WriteLine(maxSum);

		//Using Top Down Approach
		//int[] dp = new int[inputs.Length + 1];
		//for(int i = 0; i < dp.Length; i++){
		//	dp[i] = -1;
		//}
		//int maxSum =  Approach2(nums, inputs.Length-1, dp);	
		//Console.WriteLine(maxSum);
		
		//Using Buttom Up Approach
		//int maxSum =  Approach3(nums);	
		//Console.WriteLine(maxSum);

		//Using Optimize Method
		int maxSum = Approach4(nums);
		Console.WriteLine(maxSum);
	}
}	