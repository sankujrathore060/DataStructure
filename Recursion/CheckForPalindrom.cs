using System;

class CheckForPalindrom{
	public static bool IsPalindrom(string str, int low, int high){
		if(low > high)
			return true;
		if(str[low] != str[high])
			return false;

		return IsPalindrom(str, low + 1, high - 1);
	}
	
	public static void Main(string[] args){
		string element= "abtabCheckForPalindrom";

		Console.WriteLine(IsPalindrom(element, 0, element.Length - 1));
	}
}