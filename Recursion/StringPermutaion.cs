using System;
using System.Collections.Generic;

class StringPermutaion{
	public static void FindPermutation(char[] str, int start, List<string> permutations){
		if(start >= str.Length){
			permutations.Add(new string(str));
			return;
		}
		int keyIndex = start;
		for(int index = start; index < str.Length; index++){
			// Swapping
			char temp =  str[keyIndex];
			 str[keyIndex] = str[index];
			 str[index] = temp;
			

			FindPermutation( str, start + 1, permutations);
			//Backtrack
			 temp =  str[keyIndex];
			 str[keyIndex] = str[index];
			 str[index] = temp;
			
			
		}
	}
	public static void Main(string[] args){
		string str = "abc";
		List<string> permutations = new List<string>();
		FindPermutation(str.ToCharArray(), 0, permutations);

		foreach(var item in permutations){
			Console.Write(item  + " - ");
		}	
	}
}