using System;
public class BasicProgram{
	
	public static string CopyRecursivly(char[] array, int index){
		if(index == 0){
			return array[0].ToString();
		}
		else{
			return  array[index] + CopyRecursivly(array, index - 1) + "";
		}
	}


	public static string CopyString(string first){
		char[] firstArray = first.ToCharArray();
		//char[] secoundArray = new char[firstArray.Length];

		return CopyRecursivly(firstArray, firstArray.Length - 1);
		
		//for(int index = 0; index < firstArray.Length; index++){
		//	secoundArray[index] = firstArray[index];
		//}
		//return string.Join("",secoundArray);
	}
	
	public static bool CheckForStringPaligram(string str){
		bool[] mark = new bool[26];
		int alphaIndex =  -1;
		for(int index = 0; index < str.Length; index++){
			if('A' <= str[index] && str[index] <= 'Z'){
				alphaIndex = str[index] - 'A';
			}
			else if('a' <= str[index] && str[index] <= 'z'){
				alphaIndex = str[index] - 'a';
			}
			mark[alphaIndex] = true;
		}

		foreach(var item in mark){
			if(!item){
				return false;
			}
		}
		return true;
	}
	
	public static void FindAllMissingCharFromString(string str){
		bool[] mark = new bool[26];
		int alphaIndex =  -1;
		for(int index = 0; index < str.Length; index++){
			if('A' <= str[index] && str[index] <= 'Z'){
				alphaIndex = str[index] - 'A';
			}
			else if('a' <= str[index] && str[index] <= 'z'){
				alphaIndex = str[index] - 'a';
			}
			mark[alphaIndex] = true;
		}
		string nonMatchChar = "";
		for(int index = 0; index < mark.Length; index++){
			if(!mark[index]){
				char nonChar = (char)(97 + index);
				nonMatchChar = nonMatchChar + nonChar.ToString();
			}
		}
		Console.WriteLine();
		Console.WriteLine(nonMatchChar);
	}

	public static void CheckIsPanagramicLipogram(string str){
		bool[] mark = new bool[26];
		for(int index = 0; index < str.Length; index++){
			int alphaIndex = -1;
			if('A' <= str[index] && str[index] <= 'Z'){
				alphaIndex = str[index] - 'A';
			}
			else if('a' <= str[index] && str[index] <= 'z'){
				alphaIndex = str[index] - 'a';
			}
			else {
				continue;
			}
			mark[alphaIndex] = true;
		}
		int counter = 0;
		foreach(var item in mark){
			if(!item)
			    counter++;
		}
		if(counter == 0){
			Console.WriteLine("Panagram");
		}
		else if(counter == 1){
			Console.WriteLine("Panagramix Lipogram");
		}
		else {
			Console.WriteLine("Lipogram");
		}
	}

	public static char? FindHighestCountChar(int[] count){
		int maxCount = int.MinValue;
		char? maxCountChar = null;	
		for(int index = 0; index < count.Length; index++){
			if(count[index] > maxCount){
				maxCount = count[index];
				maxCountChar =  (char)(97 + index);
			}	
		}
		return maxCountChar;			
	}
	
	public static string RearrangeString(string str){
		int[] alphabetCount= new int[26];
		
		string finalString = string.Empty;
		for(int element =0; element < str.Length; element++){
			alphabetCount[str[element] - 'a']++;
			finalString+= ' ';
		}		
		char highestCountChar =  FindHighestCountChar(alphabetCount) ?? str[0];
		int highestCountCharCount = alphabetCount[highestCountChar - 'a'];
		if(highestCountCharCount > (str.Length +1) /2){
			return "Not able to rearrange string";
		}

		int nextIndex = 0;
		while(highestCountCharCount > 0){
			finalString = finalString.Substring(0, nextIndex) + highestCountChar + finalString.Substring(nextIndex + 1);
			nextIndex+=2;
			highestCountCharCount--;
		}
		alphabetCount[highestCountChar - 'a'] = 0;
		for(int index = 0; index < alphabetCount.Length; index++){
			while(alphabetCount[index] > 0){
				nextIndex = nextIndex >= str.Length? 1: nextIndex;
				finalString = finalString.Substring(0, nextIndex) + (char)('a' + index) + finalString.Substring(nextIndex+1);
				nextIndex+=2;
				alphabetCount[index]--;
			}
		}
		return finalString;			
	}
	
	public static bool checkStringInNumeric(string str){
		for(int index = 0; index < str.Length; index++){
			if(!('0' <= str[index] && str[index] <= '9'))
				return false;	
		}
		return true;
	}

	public static string ChangeStringToNewCharacterSet(char[] charSet, string element){
		char[] alphabetSet = new char[26];
		for(int alphabet = 0; alphabet < charSet.Length; alphabet++){
			alphabetSet[charSet[alphabet] - 'a'] = (char) ('a' + alphabet);
		}
		string changedElement = "";
		for(int alphabet = 0; alphabet < element.Length; alphabet++){
			changedElement+= alphabetSet[element[alphabet] - 'a'];
		}
		return changedElement;
	}

	public static string ChangeStringToNewCharacterSetUsingString(string charSet, string element){
		string alphabetsSet = "abcdefghijklmnopqrstuvwxyz";
		
		string changedElement = "";
		for(int alphabet = 0; alphabet < element.Length; alphabet++){
			changedElement+= alphabetsSet[charSet.IndexOf(element[alphabet])];
		}
		return changedElement;
	}

	public static string RoundGivenNumberToNearestMultipuleOf10(long number){
		long quotient = number / 5;
		long result = quotient * 5;
		return ((quotient % 2)	== 0 ? result : result + 5).ToString();
	}

	public static string RoundGivenNumberToNearestMultipuleOf10WithString(string number, int length){
		char[] numberArray = number.ToCharArray();
		if(numberArray[length - 1] == '1' || numberArray[length - 1] == '2' || numberArray[length - 1] == '3' || numberArray[length - 1] == '4' || numberArray[length - 1] == '5'){
			numberArray[length - 1]  = '0';
		}
		else {
			for(int index = length - 1; index >=0; index--){
				if(numberArray[index] == '9'){
					numberArray[index] = '0';
				}
				else {
					numberArray[index]  = (char)(((numberArray[index] - '0')+ 1) + 48);
				}
			}
			number = new string(numberArray);
			number = number[0] == '0' ? "1" + number: number; 
		}
		return number;
	}
		
	public static void Main(string[] args){
		//string first = "Hello World";
		//string secound = CopyString(first);
		//Console.Write(secound);
		
		//first = "The quick brown fox jumps over the lazy dog";
		//Console.Write(CheckForStringPaligram(first));
		//FindAllMissingCharFromString("Hello World");
		//CheckIsPanagramicLipogram("The quick brown fox jumps over the lazy do");
		//Console.WriteLine(RearrangeString("aaabc"));
		//Console.WriteLine(checkStringInNumeric("1345"));
		 string charSet = "qwertyuiopasdfghjklzxcvbnm";
        		string str = "egrt";
		Console.WriteLine(ChangeStringToNewCharacterSet(charSet.ToCharArray(), str));
		Console.WriteLine(ChangeStringToNewCharacterSetUsingString("qwertyuiopasdfghjklzxcvbnm", str));
		Console.WriteLine(RoundGivenNumberToNearestMultipuleOf10(69999999));
		Console.WriteLine(RoundGivenNumberToNearestMultipuleOf10WithString("69999999999999999999999999", 26));
	}
}