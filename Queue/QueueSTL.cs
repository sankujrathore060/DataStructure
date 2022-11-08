using System;
using System.Collections;

class QueueSTL{
	public static void Main(string[] args){
		Queue queue = new Queue();
		queue.Enqueue(10);
		Console.WriteLine(queue.Peek());
		
		queue.Enqueue(20);
		Console.WriteLine(queue.Peek());

		queue.Enqueue(30);
		Console.WriteLine(queue.Peek());

		queue.Enqueue(40);
		Console.WriteLine(queue.Peek());

		queue.Enqueue(50);
		Console.WriteLine(queue.Peek());

		Console.WriteLine(queue.Dequeue());
		Console.WriteLine("Frant " + queue.Peek());
		Console.WriteLine(queue.Count);
	}
}
