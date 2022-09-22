using System;
using System.Collections.Generic;
class FindSubSequence{

	public static void CalSubSequence(string str, int index, string output, List<string> subsequence){	
		if(index >= str.Length){
			subsequence.Add(output);
			return;
		}
		CalSubSequence(str, index + 1, output, subsequence);
		output += str[index];
		CalSubSequence(str, index + 1, output, subsequence);
	}

	public static void Main(string[] args){
		List<string> subsequence = new List<string>();
		string output = string.Empty;
		CalSubSequence("abc", 0, output, subsequence);
		foreach(var item in subsequence){
			Console.Write(item + "-");
		}
	}
}