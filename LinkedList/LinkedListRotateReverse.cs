using System;
class Node{
	public int data;
	public Node next;
	public Node(int data){
		this.data = data;
		next = null;
	}
}

public class LinkedListRotateReverse{
	Node head = null;
	public void Push(int item){
		Node node = new Node(item);
		if(head ==null){
			head  = node;
		}
		else{
			node.next =  head;
			head = node;
		}
	}
	public void Print(){
		Console.WriteLine();
		Node temp = head;
		while(temp != null){
			Console.Write(temp.data);
			temp  = temp.next;
		}
	}
	
	public void Reverse(){
		Console.WriteLine();
		
		Node current = head, prev = null, next = null;
		while(current != null){
			next = current.next;
			current.next = prev;
			prev = current;
			current = next;
		}
		head = prev;
	}
	
	public static void Main(string[] args){
		LinkedListRotateReverse list = new LinkedListRotateReverse();
		list.Push(3);
		list.Push(2);
		list.Push(1);
		list.Print();
		list.Reverse();
		list.Print();
	}		
}