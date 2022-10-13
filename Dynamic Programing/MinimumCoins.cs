using System;
using System.Collections.Generic;
class MinimumCoins{
	
	public static KeyValuePair<int, List<int>> Approach1(int[] coins, int amount){
		if(amount == 0){
			List<int> allCoins = new List<int>();
			return new KeyValuePair<int, List<int>>(0, allCoins);
		}

		if(amount < 0){
			List<int> allCoins = new List<int>();
			return new KeyValuePair<int, List<int>>(int.MaxValue, allCoins);
		}
		int cuurentMinCoins = int.MaxValue;
		List<int> cuurentOptimizeCoins = new List<int>();
		foreach(var coin in coins){
			KeyValuePair<int, List<int>> coinsDetail = Approach1(coins, amount - coin);
			if(coinsDetail.Key <cuurentMinCoins){			
				cuurentMinCoins = coinsDetail.Key;
				cuurentMinCoins++;
				cuurentOptimizeCoins = coinsDetail.Value;
				cuurentOptimizeCoins.Add(coin	);
			}
		}
		
		return new KeyValuePair<int, List<int>>(cuurentMinCoins, cuurentOptimizeCoins);
	} 		
	
	public static KeyValuePair<int, List<int>> Approach2(int[] coins, int amount, Dictionary<int, KeyValuePair<int, List<int>>> dp){
		if(amount == 0){
			List<int> allCoins = new List<int>();
			return new KeyValuePair<int, List<int>>(0, allCoins);
		}

		if(amount < 0){
			List<int> allCoins = new List<int>();
			return new KeyValuePair<int, List<int>>(int.MaxValue, allCoins);
		}
		if(dp.ContainsKey(amount)){
			return  dp[amount];
		}
		int cuurentMinCoins = int.MaxValue;
		List<int> cuurentOptimizeCoins = new List<int>();
		foreach(var coin in coins){
			KeyValuePair<int, List<int>> coinsDetail = Approach2(coins, amount - coin, dp);
			if(coinsDetail.Key != int.MaxValue && coinsDetail.Key <cuurentMinCoins){			
				cuurentMinCoins = coinsDetail.Key;
				cuurentMinCoins++;
				cuurentOptimizeCoins = new List<int>(coinsDetail.Value);
				cuurentOptimizeCoins.Add(coin);
			}
		}
		
		dp.Add(amount, new KeyValuePair<int, List<int>>(cuurentMinCoins, cuurentOptimizeCoins));  
		return  dp[amount];
	} 		
	
	public static KeyValuePair<int, List<int>> Approach3(int[] coins, int amount, Dictionary<int, KeyValuePair<int, List<int>>> dp){
		List<int> allCoins = new List<int>();
		dp.Add(0, new KeyValuePair<int, List<int>>(0, allCoins));
		for(int index = 1; index <= amount; index++){
			int curentMinCoins = int.MaxValue;			
			List<int> curentOptimizeCoins = new List<int>();
			foreach(var coin in coins){
				if(index - coin >= 0 ){
					KeyValuePair<int, List<int>> coinsDetail = dp[index - coin];
					if(coinsDetail.Key != int.MaxValue && coinsDetail.Key <curentMinCoins){			
						curentMinCoins = coinsDetail.Key;
						curentMinCoins++;
						curentOptimizeCoins = new List<int>(coinsDetail.Value);
						curentOptimizeCoins.Add(coin);
					}
				}	
			}
			dp.Add(index, new KeyValuePair<int, List<int>>(curentMinCoins, curentOptimizeCoins));  
		}
		return dp[amount];
	} 
	public static void Main(string[] args){
		
		Console.WriteLine("Enter Amount");
		int amount = int.Parse(Console.ReadLine());

		Console.WriteLine("Enter total Coins");	
		int totalCoins = int.Parse(Console.ReadLine());
		int[] coins = new int[totalCoins]	;
		
		for(int index = 0; index < totalCoins; index++){
			coins[index] = int.Parse(Console.ReadLine());
		}
		
		//Using Recursion
		//KeyValuePair<int, List<int>> coinDetail = Approach1(coins, amount);	
		//Console.Write(coinDetail.Key + ":- ");
		//foreach(var coin in coinDetail.Value){
		//	Console.Write(coin + ",");
		//}

		//Using Top Down Approach Of DP
		//Dictionary<int, KeyValuePair<int, List<int>>> dp = new Dictionary<int, KeyValuePair<int, List<int>>>();
		//KeyValuePair<int, List<int>> coinDetail = Approach2(coins, amount, dp);	
		//Console.Write(coinDetail.Key + ":- ");
		//foreach(var coin in coinDetail.Value){
		//	Console.Write(coin + ",");
		//}
		
		// Using Buttom Up Approch OfDp
		Dictionary<int, KeyValuePair<int, List<int>>> dp = new Dictionary<int, KeyValuePair<int, List<int>>>();
		KeyValuePair<int, List<int>> coinDetail = Approach3(coins, amount, dp);	
		Console.Write(coinDetail.Key + ":- ");
		foreach(var coin in coinDetail.Value){
			Console.Write(coin + ",");
		}
		
	}
}