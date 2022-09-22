using System;

class CountToReachDest{
	
	public static int RechToDestination(int n){
		if(n < 0)
			return 0;
		if(n == 0)
			return 1;
		
		return RechToDestination(n-1) + RechToDestination(n -2);
		
	}

	public static void Main(string[] args){
		Console.WriteLine(RechToDestination(3));
	}
}