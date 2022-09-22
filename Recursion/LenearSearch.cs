using System;

class LenearSearch{
	public static int Search(int[] array,int key, int start){
		if(start == -1)
			return -1;
		if(array[start] == key){
			return start;	
		}
		return Search(array, key, --start);
	}
	
	public static void Main(string[] args){
		int[] array = { 5, 4, 2, 1, 8, 9 };
		Console.WriteLine(Search(array, 8, array.Length - 1));
	}
}