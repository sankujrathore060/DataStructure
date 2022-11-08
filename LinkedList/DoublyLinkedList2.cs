using System;

class Node{
	public int data;	
	public Node next;
	public Node prev;
	public Node(int data){
		this.data = data;
		prev = null;
		next = null;
	}
}

class DoublyLinkedList2{
	Node head;
	public DoublyLinkedList2(){
		head = null;
	}
	
	public void InsertAtHead(int data){
		if(head == null){
			head = new Node(data);
			return;
		}
		
		Node node = new Node(data);
		node.next = head;
		head.prev = node;
		head = node;
	}

	public void InsertAtTail(int data){
		if(head == null){
			head = new Node(data);
			return;
		}
		
		Node temp = head;
		while(temp.next != null){
			temp= temp.next;
		}
		Node node = new Node(data);
		temp.next = node;
		node.prev = temp;
	}

	public void InsertAtMid(int data, int position){
		if(head == null || position == 1){
			InsertAtHead(data);
			return;
		}
		
		Node current = head;
		while(position > 1 && current != null){
			current= current.next;
			position--;
		}

		if(current == null){
			InsertAtTail(data);
			return;
		}

		Node node = new Node(data);

		node.next = current;
		node.prev = current.prev;
		current.prev.next = node;
		current.prev = node;
	}
	
	public void Delete(int position){
		if(position == 1){
			Node temp = head;
			head.next.prev = null;
			head = head.next;
			temp.next = null;		
		}
		else {
			Node current = head;
			while(position > 1 && current != null){
				current = current.next;
				position--;
			}
			if(current == null)
				return;
			if(current.next == null){
				Node prev = current.prev;
				prev.next = current.next;
				current.prev = null;
				current.next = null;
			}
			else {
				Node prev = current.prev;
				prev.next = current.next;
				current.next.prev = prev;
				current.prev = null;
				current.next = null;
			}
			
		}		
	}

	public void Print(){
		Node temp =  head;
		while(temp != null){
			Console.Write(temp.data + " ");
			temp =  temp.next;
		}
		Console.WriteLine();
	}
	public void PrintPrev(){
		Node temp =  head;
		while(temp.next != null){
			temp =  temp.next;
		}
		while(temp != null){
			Console.Write(temp.data + " ");
			temp = temp.prev;
		}
		
		Console.WriteLine();
	}
	public static void Main(string[] args){
		DoublyLinkedList2 list = new DoublyLinkedList2();
		Console.WriteLine("Enter Total value of Node");
		int n = int.Parse(Console.ReadLine());

		for(int index = 0; index < n; index++){
			string[] record = Console.ReadLine().Split(new char[] {' '});

			switch(record[0]){
				case "h":
					list.InsertAtHead(int.Parse(record[1]));
					break;
				case "t":
					list.InsertAtTail(int.Parse(record[1]));
					break;
				case "m":
					list.InsertAtMid(int.Parse(record[1]), int.Parse(record[2]));
					break;
			}		
		}

		list.Print();
		Console.WriteLine("Head = "+list.head.data);	
		list.PrintPrev();
		Console.WriteLine("Enter Delete Node");
		int data = int.Parse(Console.ReadLine());
		list.Delete(data);
		Console.WriteLine("Head = "+list.head.data);
		list.Print();
		list.PrintPrev();	
	}
}