using System;
using System.Collections.Generic;

class PriorityQueue{
	public static void Main(string[] args){
		PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
		queue.Enqueue(7, 7);
		queue.Enqueue(10, 10);
		queue.Enqueue(4, 4);
		queue.Enqueue(20, 20);
		
		while(queue.Count > 0){
			Console.Write(queue.Peek() + " ");
			queue.Dequeue();
		}
	}
}