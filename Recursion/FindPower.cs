using System;

class FindPower{
	public static int Power(int a, int b){
		if(b == 0)
		    return 1;
		if(b == 1)
		    return a;

		int result = Power(a, b/2);

		if((b%2) == 0)
		{
			return result* result;
		}
		return  a*result* result;
	}
 
	public static void Main(string[] args){
		Console.WriteLine(Power(3,5));
	}

}