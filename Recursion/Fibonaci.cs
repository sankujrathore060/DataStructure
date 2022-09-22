using System;

public class Fibonaci{
	public static int fibo(int n){
		if(n == 0){
			return 0;
		}
		if(n == 1)
		{
			return 1;
		}

		return fibo(n -1) + fibo(n - 2);
	}
	
	public static void Main(string[] args){
		Console.Write(fibo(8));	
	}
}