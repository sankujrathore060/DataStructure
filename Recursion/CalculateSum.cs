using System;
class CalculateSum{

	public static int Sum(int[] array, int index){
		if(index == 0)
			return array[index];
		return array[index] + Sum(array, index - 1);
	}

	public static void Main(string[] args){
		int[] array = { 6, 2, 3, 8, 9 };
		Console.WriteLine(Sum(array, array.Length - 1));
	}
}