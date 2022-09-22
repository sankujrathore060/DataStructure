using System;

class JumpSearch{
	//Time:- O(sqrt(n))
	public static int IterativeSearch(int[] array, int length, int key){
		int step = (int)Math.Sqrt(length);
		int prev = 0;
		while(array[Math.Min(step, length)-1] < key){
			prev = step;
			step+= (int)Math.Sqrt(length);
			if(prev >= length)
				return -1;
		}
		while(array[prev] < key){
			prev++;
			if(prev == Math.Min(step, length))
				return -1;
		}
		if(array[prev] == key){
			return prev;
		}
		return -1;
	}	

	public static void Main(string[] args){
		int[] array= { 1, 5, 6, 7, 8, 9, 12, 15, 25};
		Console.WriteLine(IterativeSearch(array,  array.Length, 15));
	}
}