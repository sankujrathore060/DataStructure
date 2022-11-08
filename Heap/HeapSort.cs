using System;

class HeapSorting{
	public static void Swapper(int[] arr, int start, int end){
		int temp = arr[start];
		arr[start] = arr[end];
		arr[end] = temp;
	}
	public static void Hepify(int[] arr, int parent, int size){
		int maxChild = parent;
		int leftChild = 2*parent + 1;
		int rightChild = 2*parent + 2;
		if(leftChild <= size && arr[leftChild] > arr[maxChild]){
			maxChild = leftChild;
		}
		if(rightChild <= size && arr[rightChild] > arr[maxChild]){
			maxChild = rightChild;
		}
		if(macChild != parent){
			 Swapper(arr, parent, maxChild);
			 Hepify(arr, maxChild, size);
		}
	}
	
	public static void HeapSort(int[] arr, int length){
		int size = length;
		while(size > 1){
			//Swap root with last node
			 Swapper(arr, 0, length - 1);
			
			//Decrease Size
			size--;
			
			//Place into write Place
			Hepify(arr, 0, size);			
		}
	}

	public static void Main(string[] args){
		int[] arr= { 9, 2, 4, 5, 6,10, 1};

		//Build Heap excluse leaf node
		for(int index = (arr.Length/2)- 1; index >= 0; index++){
			Hepify(arr, index, arr.Length - 1);
		}

		for(int i = 0; i < arr.Length; i++){
			Console.Write(arr[i]);
		} 			
		Console.WriteLine();

		//Heap Sort
		HeapSort(arr, arr.Length);

		for(int i = 0; i < arr.Length; i++){
			Console.Write(arr[i]);
		} 			
		Console.WriteLine();
	}
}