using System;

class Node{
	public int data;
	public Node next;
	public Node(int data){
		this.data = data;
		next = null;
	}
}

class SinglyLinkedListWithHeadTail{
	public Node head;

	public SinglyLinkedListWithHeadTail(){
		head = null;
	}

	public void InsertAtHead(int data){
		if(head == null){
			head = new Node(data);
			return;
		}
		
		Node node  = new Node(data);
		node.next = head;
		head = node;
	}

	public void InsertAtTail(int data){
		if(head == null){
			head = new Node(data);
			return;
		}
		Node tail = head;
		while(tail.next != null){
			tail = tail.next;
		}
		
		Node node  = new Node(data);
		tail.next = node;
		tail = node;
	}
	
	public void InsertAtMiddle(int data, int key){
		if(head == null){
			InsertAtHead(data);
			return;
		}

		Node temp = head;
		while(temp.data != key){
			temp = temp.next;
		}

		if(temp.next == null){
			InsertAtTail(data);
			return;
		}		
		Node node  = new Node(data);
		node.next = temp.next;
		temp.next = node;
	}

	public void Delete(int position){
		if(position == 1){
			Node temp = head;
			head = head.next;
			temp.next = null;
		}
		else {
			Node prev = null;
			Node current = head;

			while(position > 1){
				prev = current;
				current = current.next;
				position--;
			}

			prev.next = current.next;
			current.next = null;			
		}
	}

	public void Print(){
		Node temp = head;
		while(temp != null){
			Console.Write(temp.data + " ");
			temp = temp.next;
		}
		Console.WriteLine();
	}
	
	public static void Main(string[] args){
		SinglyLinkedListWithHeadTail list = new SinglyLinkedListWithHeadTail();

		list.InsertAtHead(10);
		list.InsertAtHead(20);
		list.InsertAtHead(30);
		list.InsertAtHead(40);
		list.InsertAtHead(50);
		list.Print();

		list.InsertAtTail(60);
		list.InsertAtTail(70);
		list.Print();

		list.InsertAtMiddle(90, 30);
		list.Print();
		list.InsertAtMiddle(100, 70);
		list.Print();
		//list.head = null;
		list.InsertAtMiddle(110, 70);
		list.Print();
		list.Delete(1);
		list.Delete(5);
		list.Print();
		Console.WriteLine("Head ->" + list.head.data);
	}
}