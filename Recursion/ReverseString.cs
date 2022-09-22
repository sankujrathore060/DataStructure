using System;

class ReverseString{
	public static void SwapString(char[] str, int low, int high){
		char temp = str[low];
		str[low] = str[high];
		str[high] = temp;
	}
	public static void Reverse(char[] str, int low, int high){
		if(low > high){
			return;
                                }
		SwapString(str, low, high);
		low++;
		high--;
		Reverse(str, low, high);
	}	

	public static void Main(string[] args){
		string str ="Helloh";
		char[] strArray = str.ToCharArray();
		Reverse(strArray, 0, str.Length - 1);
		Console.WriteLine(new string(strArray));
	}
}