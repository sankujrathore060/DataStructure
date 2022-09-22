using System;

class SayDigitsProgram{
	
	public static string SayDigits(string num, string[] digits){
		if(num.Length == 1)
			return digits[int.Parse(num)];

		return SayDigits(num.Substring(0, 1), digits) + SayDigits(num.Substring(1), digits);
	}
	public static void SayDigitsByNumber(int num, string[] digits){
		if(num == 0)
			return;
		int rem = num % 10;
		num = num / 10;
		SayDigitsByNumber(num, digits);
		Console.Write(digits[rem]);
	}

	public static void Main(string[] args){
		string num = "4532";
		string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
		Console.WriteLine(SayDigits(num, digits));

		SayDigitsByNumber(4532, digits);
	}
}