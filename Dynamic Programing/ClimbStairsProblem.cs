using System;

public class ClimbStairsProblem{
	
	public static int WaysToClimbStairs(int n, int[] dp){
        		if(n == 0){
           	 		return 1;
        		}
       		 if(n < 0){
           			return 0;
        		}
        		if(dp[n] != -1){
            			return dp[n];
        		}
        		dp[n] = WaysToClimbStairs(n-1, dp) + WaysToClimbStairs(n-2, dp);
       		 return dp[n];
   	 }
    
    	public static int ClimbStairs(int n) {
        		int[] dp = new int[n + 1];
        		for(int index = 0; index < dp.Length; index++ ){
            			dp[index] = -1;
        		}
        		return WaysToClimbStairs(n, dp);
    	}
	public static void TopDownApproch(){
		
		Console.WriteLine("Enter Total Stairs");
		int stairs = int.Parse(Console.ReadLine());
		Console.WriteLine(ClimbStairs(stairs));
	}
	public static void ButtomUpApproch(){
		
		Console.WriteLine("Enter Total Stairs");
		int n = int.Parse(Console.ReadLine());

		int[] dp = new int[n+1]; 
        
        		dp[0] = 1;
        		dp[1] = 1;
        		for(int index = 2; index < dp.Length; index++){
            			dp[index] = dp[index - 1] + dp[index - 2];       
        		}
        		Console.WriteLine(dp[n]); 
	}
	public static void Main(string[] args){
		Console.WriteLine("Top Down");
		TopDownApproch();
		
		Console.WriteLine("Buttom Up");
		ButtomUpApproch();
	}
}