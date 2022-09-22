using System;
public class CharacterCountingOnString{
	
	public static void GenerateStringFromSizeAndUniqueChar(int length, int uniqueCharcount){
		string finalString = "";
		for(int index = 0; index < uniqueCharcount; index++){
			finalString += (char)(index + 'a');
		}
		finalString += finalString.Substring(0, length - uniqueCharcount);
		Console.WriteLine(finalString);
	}
	
	public static int FindCountOfWordStringContain(string[] words, string str ){
		int numberOfWordContain = 0;
		for(int index = 0; index < words.Length; index++){
			if(str.Contains(words[index]))
				numberOfWordContain++;
		}
		return numberOfWordContain;	
	}
	
	public static char GetKthCharAfterDecriptingString(string str, int k){
		string number = "", currentString = "", finalString = "";
		
		for(int index = 0; index < str.Length; index++){
			if('0' <= str[index] && str[index] <= '9'){
				number += str[index];
			if(index < str.Length - 1 &&  '0' <= str[index + 1] && str[index + 1] <= '9')
				continue;	
			int count = Convert.ToInt32(number);	
			while(count > 0){
				finalString+= currentString;
 				count--;
			}
			number ="";
			currentString = "";
			
			}
			else {
				currentString+= str[index];
			}
		}
		return finalString[k-1];	
	}
	
	public static int CountCharAtSamePositionInEngAlpha(string str){
		string alphabets = "abcdefghijklmnopqrstuvwxyz";
		int matchCount = 0;
		for(int index = 0; index < str.Length; index++){
			if(str[index] == alphabets[index])
				matchCount++;
		}
		return matchCount;
	}
	
	public static bool CheckTwoHalvesHaveSameCharwithSameFrequency(string str){
		int subLength = str.Length/ 2;
		string leftPart = str.Substring(0, subLength);
		string rightPart = str.Substring((str.Length %2) !=0 ? subLength + 1 : subLength);
		int[] character = new int[26];
		
		for(int index = 0; index < leftPart.Length; index++){
			character[leftPart[index] - 'a']++;
			character[rightPart[index] - 'a']--;
		} 
		foreach(var item in character){
			if(item != 0){
				return false;
			}
		}
		return true;
	}
	
	public static void Main(string[] args){
		//GenerateStringFromSizeAndUniqueChar(5, 3);
		//Console.WriteLine(FindCountOfWordStringContain(new string[] { "is", "a", "xyz", "pqr"}, "This is a Car pqr"));
		//Console.WriteLine(GetKthCharAfterDecriptingString("ab4c12ed3", 21));
		Console.WriteLine(CountCharAtSamePositionInEngAlpha("aeeksforgeeks"));
		Console.WriteLine(CheckTwoHalvesHaveSameCharwithSameFrequency("cbattatbc"));
	}
}