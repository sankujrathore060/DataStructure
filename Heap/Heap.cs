using System;
class Heap{
	int[] heap;
	int size;
	public Heap(){
		heap =new int[100];
		size = 0;
	}
	public void Swaper(int[] heap, int start, int end){
		int temp =  heap[start];
		heap[start] = heap[end];
		heap[end] = temp;
	}
	public void Insert(int data){
		size++;
		heap[size] = data;
		int current = size;

		while(current > 1){
			int parent = current/2;
			if(heap[parent] < heap[current]){
				Swaper(heap, parent, current);
				current = parent;
			}
			else {
				return;	
			}
		}
	}
	public void Display(){
		for(int index =1; index <= size; index++){
			Console.Write(heap[index] + " ");
		}
		Console.WriteLine();
	}

	public void Pop(){
		if(size == 0){
			return;
		}
		//Swap Root With last node
		Swaper(heap, 1, size);

		//drop element
		size--;
		
		//check for Heap Property;
		int parent = 1;
		while(parent < size){
			int leftChild = 2*parent;
			int rightChild = 2*parent + 1;
			int maxChild = heap[leftChild] > heap[rightChild]? leftChild : rightChild;
			if(maxChild < size && heap[maxChild] > heap[parent]){
				Swaper(heap, maxChild, parent);		
				parent = maxChild;
			}
			else{
				return;
			}	
		}	
	}
	public static void Main(string[] args){
		Heap heap = new Heap();
		heap.Insert(50);
		heap.Insert(70);
		heap.Insert(60);
		heap.Insert(30);
		heap.Insert(20);
		heap.Insert(15);
		heap.Insert(9);
		heap.Insert(6);
		heap.Insert(5);
		heap.Insert(8);
		heap.Insert(4);
		heap.Insert(10);
		heap.Display();
		heap.Pop();
		heap.Display();
	}
}