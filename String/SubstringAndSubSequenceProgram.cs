using System;
public class SubstringAndSubSequenceProgram{

	public static int SubstringRecusive(int firstIndex, int secoundIndex, string str, string key){
		if(secoundIndex > key.Length - 1){
			return 1;
		}
		if(firstIndex > str.Length - 1){
			return 0;
		}
		if(str[firstIndex] == key[secoundIndex])
		{
			return SubstringRecusive(firstIndex + 1, secoundIndex + 1, str, key) + SubstringRecusive(firstIndex + 1, secoundIndex, str, key);
		}
		return SubstringRecusive(firstIndex + 1, secoundIndex, str, key);	
	}

	public static int CountNoOfKeysubstringContain(string str, string key){
		return SubstringRecusive(0, 0, str, key);
	}

	public static void LongestCommonSubsequesnceString(string str1, string str2){
		int[] alpha= new int[26];
		int[] alpha2= new int[26];
		string matchSubString = "";

		for(int index=0; index < str1.Length; index++){
			alpha[str1[index] - 'a']++;	
		}

		for(int index=0; index < str2.Length; index++){
			alpha2[str2[index] - 'a']++;	
		}
		
		for(int index = 0; index < 26; index++){
			int totalCount = Math.Min(alpha[index], alpha2[index]);
			while(totalCount> 0){
				matchSubString += (char)(index + 'a');
				totalCount--;
			}
		}
		Console.WriteLine(matchSubString);
	}
	
	public static void Main(string[] args){
		//Console.WriteLine(CountNoOfKeysubstringContain("banan", "ban"));
		LongestCommonSubsequesnceString("pink", "kite");
	}
}