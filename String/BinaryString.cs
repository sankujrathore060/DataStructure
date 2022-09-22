using System;
using System.Collections.Generic;

public class BinaryString{
	
	public static int FindCountOfNonConsecutiveOnesBinaryNo(int N){
		int zeroCount = 1;
		int oneCount = 1;
		int sum = zeroCount + oneCount;
		if(N == 1) return sum;
		for(int index = 1; index < N; index++){
			oneCount = zeroCount;
			zeroCount = sum;
			sum = zeroCount + oneCount;
		}
		return sum;
	}

	public static bool CheckBinaryStringInFormOfSquare(string str){

		int[] alpha = new int[26];
		if((str.Length%2) != 0) return false;
		for(int index = 1; index <  str.Length; index+=2){
			if(str[index] != str[index - 1]){
				return false; 
			}
			else {
				alpha [str[index] - 'a']+=2;
			}
		}

		for(int index = 0; index < 26; index++){
			if(alpha[0] > 2){
				return false;
			}
		}
		return true;
	}

	public static void SwapperArrayElement(char[] alphabets, int firstIndex, int secoundIndex){
		char temp = alphabets[firstIndex];
		alphabets[firstIndex] = alphabets[secoundIndex];
		alphabets[secoundIndex] = temp;
	}

	public static string findNextLargestNumber(string str){
		char[] strArray = str.ToCharArray();
		int index = strArray.Length - 2;
		for(index = strArray.Length - 2; index  >=0; index--){
			if(strArray[index] == '0' && strArray[index + 1] == '1'){
				SwapperArrayElement(strArray, index, index + 1);
				break;
			}
		}
		
		if(index == -1) return "no max element found";

		int low = index + 2, high = strArray.Length - 1;
		while(low < high){
			if(strArray[low] == '1' && strArray[high] == '0'){
				SwapperArrayElement(strArray, low, high);
				low++;
				high--;
			}
			else{
				low++;
			}
		}
		return new string(strArray);		
	}
	
	public static int MinFlipCountCharacterToMakeAllStringSame(string str){
		int low = 0, mid = low+1 , high = str.Length - 1;
		int zeroFlips = 0, oneFlips = 0;
		
		while(mid <= high){
			if(str[low] == str[mid]){
				mid++;
			}
			else{
				if(str[low]  == '0'){
					zeroFlips++;
				}
				else {
					oneFlips++;
				}
				low = mid;
				mid++;
			}
		}
		if(zeroFlips > 0 || oneFlips > 0)
		{	
			if(str[high]  == '0'){
				zeroFlips++;
			}
			else {
				oneFlips++;
			}
		}
		return Math.Min(zeroFlips,oneFlips);	
	}
	
	public static List<string> GenerateNBitGrayCode(int N){
		List<string> binaryList = new List<string>();
		for(int index = 0; index < (1<<N); index++){
			binaryList.Add(Convert.ToString(index, 2));
		}
		if(N == 1) return  binaryList;
		int low =	2, mid = low+1;
		while(mid <  (1<<N)){
			string temp = binaryList [low];
			binaryList [low] = binaryList [mid];
			binaryList [mid] = temp;
			low+=4;
			mid = low+1;
		}
		return  binaryList;
	}
	
	public static void Main(string[] args){
		//Console.WriteLine(FindCountOfNonConsecutiveOnesBinaryNo(3));
		//Console.WriteLine(CheckBinaryStringInFormOfSquare("a"));
		//Console.WriteLine(findNextLargestNumber("01100"));
		//Console.WriteLine(MinFlipCountCharacterToMakeAllStringSame("010101100011"));
		List<string> binaryList = GenerateNBitGrayCode(3);
		foreach(var item in binaryList){
			Console.WriteLine(item);
		}
	}
}