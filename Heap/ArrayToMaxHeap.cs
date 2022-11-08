using System;

class ArrayToMaxHeap{
	
	public static void Swapper(int[] arr, int start, int end){
		int temp = arr[start];
		arr[start] = arr[end];
		arr[end] = temp;
	}

	public static void Hepify(int[] arr, int size, int parent){
		
		int leftChild = 2 *parent + 1;
		int rightChild = 2*parent +2;
		int maxChild  = parent;

		if(leftChild <=size && arr[leftChild] > arr[maxChild]){
			maxChild = leftChild;
		}
		if(rightChild <=size && arr[rightChild] > arr[maxChild]){
			maxChild = rightChild;
		}
		if(maxChild != parent){
			Swapper(arr, parent, maxChild);
			Hepify(arr, size,  maxChild);
		}
	} 

	public static void Main(string[] args){
		int[] arr = {6, 1, 3, 2,  55, 54};
		for(int i = (arr.Length / 2) - 1; i >= 0; i--){
			Hepify(arr, arr.Length - 1, i);
		}
		for(int i = 0; i < arr.Length; i++)	{
			Console.Write(arr[i] + " ");
		}			 
	}
}