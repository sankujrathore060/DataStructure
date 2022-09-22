using System;

class Node{
	public int data;
	public Node next;
	public Node(int data){
		this.data = data;
		next = null;
	}
}

class QueueLinked{
	Node frant, rear;
	public QueueLinked(){
		frant = rear = null;
	}
	
	public void Enqueue(int data){
		Node node = new Node(data);
		if(rear == null){
			frant = rear = node;
		}
		else {
			rear.next = node;
			rear = rear.next;
		}
	} 	
	public void Dequeue(){
		if(frant != null){
			frant = frant.next;	
		}
		if (frant == null)
            			rear = null;		
	} 

	public void PrintQueue(){
		Console.WriteLine();
		Node head = frant;
		while(head != null){
			Console.Write(head.data + " ");
			head = head.next;
		}
	}	
	
	public static void Main(string[] args){
		QueueLinked queue = new QueueLinked();
		queue.Enqueue(50);
		queue.Enqueue(40);
		queue.Enqueue(30);
		queue.Enqueue(20);
		queue.Enqueue(10);
		queue.PrintQueue();	
		queue.Dequeue();	
		
		queue.PrintQueue();	
	}
}