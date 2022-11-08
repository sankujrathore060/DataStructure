using System;

class Node{
	public int data;
	public Node next;

	public Node(int data){
		this.data = data;
		next = null;
	}
}

class CircularLinkedList2{
	public Node tail;
	public CircularLinkedList2(){
		tail = null;
	}
	
	public void InsertAtTail(int data){
		if(tail == null){
			Node node = new Node(data);
			node.next = node;
			tail = node;
		}
		else {
		
			Node node = new Node(data);
			node.next = tail.next;
			tail.next = node;
			tail = node;	
		}
	}
	
	public void InsertAfterData(int data, int key){
		if(tail == null){
			InsertAtTail(data);
		}
		else {
			if(tail.data == key){
				InsertAtTail(data);
			}
			else{
			
				Node current = tail.next;
				while(current != tail && current.data != key){
					current = current.next;	
				}

				if(current == tail){
					Console.WriteLine("No record Found with key");
					return;
				}

				Node node = new Node(data);
				node.next = current.next;
				current.next = node;
			}				
		}
	}

	public void InsertBeforeData(int data, int key){
		if(tail == null){
			InsertAtTail(data);
		}
		else {
				Node current = tail.next;
				Node prev  = tail;
				if(current == prev){
					if(current.data == key){
						Node node = new Node(data);
						node.next = current;
						prev.next = node;
					}
				}
				else {

				while(current.data != key && current.next != tail.next){
					prev = current;
					current = current.next;
				}
				if(current.data != key )
					return;
				Node node = new Node(data);
				node.next = current;
				prev.next = node;
				}
							
		}
	}
	
	public void Print(){
		Node temp = tail;
		do{
			Console.Write(temp.data + " ");
			temp = temp.next;
		}while(temp != tail);

		Console.WriteLine();
	}

	public void Delete(int value){
		if(tail == null)
			return;
		
		Node prev = tail;
		Node current = tail.next;
		
		if(prev == current){
			if( current.data == value){
				tail.next = null;
				tail = null;
			}
		}
		else {
			while(current.data != value && current.next != tail.next){
				prev = current;
				current = current.next;
			}

			if(current.data != value)
				return;

			prev.next = current.next;
			if(current == tail)
				tail = current.next;
			
			current.next = null;
			current = null;
		}
	}

	public static void Main(string[] args){
		CircularLinkedList2 list = new CircularLinkedList2();
		list.InsertAtTail(10);
		list.Print();
		Console.WriteLine("Head" + list.tail.data);

		list.InsertAtTail(20);
		list.Print();
		Console.WriteLine("Head" + list.tail.data);
		
		list.InsertAtTail(30);
		list.Print();
		Console.WriteLine("Head" + list.tail.data);

		list.InsertAfterData(15, 20);
		list.Print();
		Console.WriteLine("Head" + list.tail.data);

		list.InsertBeforeData(19, 30);
		list.Print();
		Console.WriteLine("Head" + list.tail.data);

		list.InsertBeforeData(18, 10);
		list.Print();
		Console.WriteLine("Head" + list.tail.data);

		list.InsertAtTail(5);
		list.Print();
		Console.WriteLine("Head" + list.tail.data);

		list.Delete(30);
		list.Print();
		Console.WriteLine("Head" + list.tail.data);
		
		list.Delete(10);
		list.Print();
		Console.WriteLine("Head" + list.tail.data);
	}
}