using System;
class Heap{
	int[] data;
	int size;
	public Heap(){
		data = new int[200];
		size = 0;
	}

	public int GetSize(){
		return size;
	}

	public void InsertHeap(int item){
		size++;
		data[size] = item;
		int index = size;
		while(index > 1){
			int parent = index/ 2;
			if(data[parent] < data[index]){
				int temp = data[parent];
				data[parent] = data[index];
				data[index] = temp;
				index = parent;
			}
			else {
				return;
			}
		}
	}

	public void PrintHeap(){
		for(int index =1; index <= size; index++){
			Console.Write(data[index] + " ");
		}
	}

	public void DeleteHeapItem(){
		if(size == 0){
			Console.Write("Heap is Empty");
			return;
		}

		data[1] = data[size];
		size--;
		int index = 1;
		while(index < size){
			int leftChildIndex = 2*index;
			int rightChildIndex = 2*index+1;
			if(data[index] <  data[leftChildIndex])
			{
				int temp = data[leftChildIndex];
				data[leftChildIndex] = data[index];
				data[index] = temp;
				index = leftChildIndex;
			}
			else if(data[index] <  data[rightChildIndex])
			{
				int temp = data[rightChildIndex];
				data[rightChildIndex] = data[index];
				data[index] = temp;
				index = rightChildIndex;
			}
			else {
				return;
			} 
		}
	}


	public void Hepify(int index, int length){
		int parent = index;
		int leftChild = 2 * index;
		int rightChild = 2 * index + 1;
		if(leftChild <= length && data[parent] < data[leftChild]){
			parent = leftChild;
		}
		if(rightChild <= length && data[parent] < data[rightChild]){
			parent = rightChild;
		}

		if(parent != index){
			int temp = data[parent];
			data[parent] = data[index];
			data[index] = temp;
			Hepify(parent, length);
		}
		else {
			return;
		}
	
	}

	public void HeapSort(){
		int count = size;
		while(count > 1){
			//Swap
			int temp = data[count];
			data[count] = data[1];
			data[1] = temp;
			
			count--;
					
			//Hepify
			Hepify(1, GetSize());
			
		}
	}
}


class HeapDemo{
	public static void Main(string[] args){
		Heap heap = new Heap();
		heap.InsertHeap(55);
		heap.InsertHeap(65);
		heap.InsertHeap(40);
		heap.InsertHeap(20);
		heap.InsertHeap(31);
		heap.InsertHeap(75);
		heap.PrintHeap();
		heap. DeleteHeapItem();
		Console.WriteLine();
		heap.PrintHeap();
		for(int index = heap.GetSize() / 2; index >0; index--){	
			heap.Hepify(index, heap.GetSize());
		}
		Console.WriteLine();
		heap.PrintHeap();

		heap.HeapSort();	
		Console.WriteLine("Heap Sort");
		heap.PrintHeap();	
	}
}