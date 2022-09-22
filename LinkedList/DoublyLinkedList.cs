using System;

class Node{
	public int data;
	public Node next;
	public Node prev;
	public Node(int data){
		this.data = data;
		next = null;
		prev = null;
	}
}

public class DoublyLinkedList{
	Node head;
	public void PushAtBegning(int item){
		Node node = new Node(item);
		if(head == null){
			head = node;
		}
		else {
			node.next = head;
			node.prev = null;
			head.prev = node;
			head = node;				
		}	
	}				
	public void PushAtEnding(int item){
		Node node = new Node(item);
		if(head == null){
			head = node;
		}
		else {
			Node temp = head;
			while(temp.next != null){
				temp = temp.next;
			}
			node.prev = temp;
			node.next = null;
			temp.next  = node;			
		}	
	}

	public void PushAfterNode(int item, int key){
		Node node = new Node(item);
		if(head == null){
			head = node;
		}
		else {
			Node temp = head;
			while(temp != null){
				if(temp.data == key)
					break;
				temp = temp.next;
			}
			Node nextNode = temp.next;
			node.prev = temp;
			node.next = temp.next;
			
			 nextNode.prev = node;
			temp.next = node;
		}	
	}
		
	public void PushBeforeNode(int item, int key){
		Node node = new Node(item);
		if(head == null){
			head = node;
		}
		else {
			Node temp = head;
			while(temp != null){
				if(temp.data == key)
					break;
				temp = temp.next;
			}
			Node prevNode = temp.prev;
			node.prev = temp.prev;
			node.next = temp;
			
			prevNode.next = node;
			temp.prev = node;
			
		}	
	}

	public void PrintNodes(){
		Node temp = head;
		while(temp != null){
			Console.Write(temp.data +"-> ");
			temp = temp.next;
		}
	}

	public void deleteNode(int key){
		Node temp =  head;
		while(temp != null){
			if(temp.data ==key)
				break;
			temp = temp.next;
		}
		Node prev = temp.prev;
		Node next = temp.next;
		prev.next = temp.next;
		next.prev = temp.prev;		
	}
	public void deleteStartNode(){
		Node next = head.next;
		next.prev = null;
		head = next;		
	}
	public void deleteEndNode(){
		Node temp = head;
		while(temp.next != null){
			temp = temp.next;
		}
		Node prev = temp.prev;
		prev.next = null;		
	}
	public static void Main(string[] args){
		DoublyLinkedList list = new DoublyLinkedList();
		list.PushAtEnding(10);
		list.PushAtEnding(5);
		list.PushAtBegning(50);	
		list.PushAtBegning(30);
		list.PushAfterNode(40, 50);
		list.PushBeforeNode(20, 10);
		list.PrintNodes();
		list.deleteNode(20);
		Console.WriteLine();
		list.PrintNodes();
		list.deleteStartNode();
		
		Console.WriteLine();
		list.PrintNodes();
		Console.WriteLine();
		list.deleteEndNode();
		
		list.PrintNodes();
	}
}