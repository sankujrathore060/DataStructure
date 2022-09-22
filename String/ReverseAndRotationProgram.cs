using System;

public class ReverseAndRotationProgram{
	
	public static void GenerateAllRotationOfString(string str){
		Console.WriteLine(str);
		for(int index = 0; index  <  str.Length -1; index++){
			Console.WriteLine( str.Substring(index + 1) + str.Substring(0, index+1));
		}
	}
	public static bool CheckS2isRotationOfS1(string s1, string s2){
		if(s1 == s2)
		    return true;
		for(int index = 0; index  <  s1.Length -1; index++){
			if(s1.Substring(index + 1) + s1.Substring(0, index+1) == s2 ){
				return true;
			}
		}
		return false;
	}
	public static int MinNumberOfRotationrequiredToGetSameString(string str){
		
		for(int index = 0; index  <  str.Length -1; index++){
			if(str.Substring(index + 1) + str.Substring(0, index+1) == str ){
				return index + 1;
			}
		}
		return str.Length;
	}
	public static void ReverseStringWithPreserveSpace(string str){
		char[] strArray = str.ToCharArray();
		int low =0, high = strArray.Length - 1;
		while(low < high){
			if(strArray[low] == ' '){
				low++;
				continue;
			}
			if(strArray[high] == ' '){
				high--;
				continue;
			}
			char temp = strArray[low];
			strArray[low] = strArray[high];
			strArray[high] = temp;
			low++;
			high--;
		}
		Console.WriteLine(new string(strArray));
	}
	public static void Main(string[] args){
		GenerateAllRotationOfString("geeks");
		Console.WriteLine(MinNumberOfRotationrequiredToGetSameString("aaaa"));
		Console.WriteLine(CheckS2isRotationOfS1("ABCD", "ABCD"));
		ReverseStringWithPreserveSpace("internship at geeks for geeks");
	}
}