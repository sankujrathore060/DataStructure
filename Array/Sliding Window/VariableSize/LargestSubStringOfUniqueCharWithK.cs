using System;
using System.Collections.Generic;

class LargestSubStringOfUniqueCharWithK{
	public static void Main(string[] args){
		string str = "aabacbebebe";
		int uniqueCount = 3;
		
		int start = 0, end = 0, maxSubString = 0;
		Dictionary<char, int> charCount = new Dictionary<char, int>();
		int uniqueCharCount = 0;
		while(end <= str.Length - 1){
			if(charCount.ContainsKey(str[end])){
				if(charCount[str[end]] == 0){
					uniqueCharCount++;	
				}
				charCount[str[end]]++;
			}
			else {
				charCount.Add(str[end], 1);
				uniqueCharCount++;								
			}
			
			if(uniqueCharCount < uniqueCount){
				end++;
			}
			else if(uniqueCharCount == uniqueCount){
				maxSubString = Math.Max(maxSubString, (end - start) + 1);
				end++;
			}
			else if(uniqueCharCount > uniqueCount){
				charCount[str[start]]--;
				if(charCount[str[start]] == 0){
					uniqueCharCount--;	
				}
				
				charCount[str[end]]--;
				if(charCount[str[end]] == 0){
					uniqueCharCount--;	
				}
				start++;
			}
		}
		Console.WriteLine(maxSubString);
	}
}