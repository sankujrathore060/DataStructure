using System;
using System.Collections.Generic;

class MinimumWindowSubString{
	public static void Main(string[] args){
		int start = 0, end = 0;
		string str = "TOTMTAPTAT", pattern = "TTA";
		
		Dictionary<char, int> patternCount = new Dictionary<char, int>();
		
		foreach(var item in pattern.ToCharArray()){
			if(patternCount.ContainsKey(item)){
				patternCount[item]++;
			}
			else {
				patternCount.Add(item, 1);
			}
		}

		int patternSize = patternCount.Count, lengthOfSubArray = int.MaxValue; 
		while(end <=  str.Length - 1){
			if(patternCount.ContainsKey(str[end])){
				patternCount[str[end]]--;
				if(patternCount[str[end]] == 0){
					patternSize--;
				}
				
				if(patternSize == 0){
					
					 while(start <= end){
						if(patternCount.ContainsKey(str[start])){
							
							if(patternCount[str[start]] < 0){
						     		patternCount[str[start]]++;
                                                                                                              		start++;
							}
							else {
								break;
							}
						}
						else {
							start++;
						}
						
					}     
					 	
					 lengthOfSubArray = Math.Min(lengthOfSubArray, (end -start) + 1);								
					
				}
				end++;
			}	
			else {
				end++;
			}
		}

		Console.WriteLine(lengthOfSubArray);
	}
}