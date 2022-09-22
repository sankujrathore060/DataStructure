using System;
class Node{
	public int data;
	public Node next;
	public Node(int data){
		this.data = data;
		next = null;
	}
}

public class LinkedListReverseEveryKNode{
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

		
	public void ReverseWithK(int k){
		Console.WriteLine();

		Node start = head, prevNode = null;
		while(start != null){
			Node prev = null, next = null, current = start;
			int loopBy = k;
			while(loopBy > 0 && current != null)
			{
				next = current.next;
				current.next = prev;
				prev = current;
				current = next;
				loopBy--;
			}
			//prevNode.next = prev;
			start = next;
			prevNode = prev;
		}
		head = prevNode;
	}


	public void Rotate(int k){
		
	}
	
	public static void Main(string[] args){
		LinkedListReverseEveryKNode list = new LinkedListReverseEveryKNode();
		list.Push(8);
		list.Push(7);
		list.Push(6);
		list.Push(5);
		list.Push(4);
		list.Push(3);
		list.Push(2);
		list.Push(1);
		list.Print();
		//list.Reverse();
		list.ReverseWithK(3);
		list.Print();
	}		
}