using System;

class QueueUsingArray{
	int[] queue;
	int frant;
	int rear;
	int size;
	public QueueUsingArray(int size){
		queue = new int[size];
		this.size = size;
		frant = 0;
		rear = 0;
	}

	public void Enqueue(int data){
		if(rear == size){
			Console.WriteLine("Queue Overflow");
			return;
		}
		queue[rear] = data;
		rear++;
	}

	public int Dequeue(){
		if(frant == rear){
			Console.WriteLine("Queue Empty");
			return -1;
		}
		int data = queue[frant];
		queue[frant] = -1;
		frant++;
		if(frant == rear){
			frant = 0;
			rear = 0;
		}
		return data;
	}
	
	public int Peek(){
		if(frant == rear){
			Console.WriteLine("Queue Empty");
			return -1;
		}
		return queue[frant];
	}

	public int Count(){
		if(rear == size){
			return (rear - 1) + frant;	
		}
		return rear - frant;
	}

	public static void Main(string[] args){
		QueueUsingArray queue = new QueueUsingArray(4);
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

		Console.WriteLine("Pop Element" + queue.Dequeue());
		Console.WriteLine(queue.Peek());
		Console.WriteLine(queue.Count());
	}
}