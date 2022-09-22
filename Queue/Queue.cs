using System;

public class Queue{
	int[] items;
	int frant;
	int rear;
	int max;
	
	public Queue(int size){
		items = new int[size];
		frant = 0;
		rear = -1;
		max = size - 1;	
	}	

	public int Enqueue(int data){
		if(rear == max){
			Console.WriteLine("Queue is Full");
			return -1;
		}
		items[++rear] = data;
		return items[rear];
	}
	public int Dequeue(){
		if(frant == rear + 1){
			Console.WriteLine("Queue is Empty");
			return -1;
		}
		int data = items[frant++];
		
		return data;
	}

	public int Peek(){
		if(frant == rear + 1){
			Console.WriteLine("Queue is Empty");
			return -1;
		}
		int data = items[frant];
		
		return data;
	}

	public static void ReverseQueue(ref Queue q){
		
		if(q.rear ==  -1)
			return;
		int data = q.Peek();
		q.Dequeue();
		ReverseQueue(ref q);
		q.Enqueue(data);
	}

	public void PrintQueue(){
		Console.WriteLine();
		for(int index = frant; index <= rear;index++){
			Console.Write(items[index] + " ");
		}
	}

	public static void Main(string[] args){

		Queue queue = new Queue(5);
		queue.Enqueue(10);
		queue.Enqueue(20);
		queue.Enqueue(30);
		queue.Enqueue(40);
		queue.Enqueue(50);

		//Console.WriteLine(queue.Peek());
		//queue.Dequeue();
		//Console.WriteLine(queue.Peek());
		queue.PrintQueue();
		ReverseQueue(ref queue);
		queue.PrintQueue();
	}
}