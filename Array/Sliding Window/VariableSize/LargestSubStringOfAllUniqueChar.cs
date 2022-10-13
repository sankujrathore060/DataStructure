using System;
using System.Collections.Generic;

class LargestSubStringOfAllUniqueChar{
	public static void Main(string[] args){
		string str = "pwtwakew";
		
		int start = 0, end  = 0, subStringLength = 0;
		Dictionary<char, int> map = new Dictionary<char, int>();
		while(end <= str.Length - 1){
			if(map.ContainsKey(str[end])){
				map[str[end]]++;
			}
			else {
				map.Add(str[end], 1);
			}

			if(map.Count < (end - start) + 1){
				map[str[start]]--;
				if(map[str[start]] == 0){
					map.Remove(str[start]);
				}
				start++;
				map[str[end]]--;
			}
			else {
				subStringLength = Math.Max(subStringLength, (end-start) + 1);	
				end++;
			}
		}

		Console.WriteLine(subStringLength);		
	}
}