using System;
public class SinglyLinkedList{
	public class Node{
		public int data = 0;
		public Node next;	
		public Node(int data){ this.data = data;  next = null;}
	}	
	public class LinkedList{
		public Node head;
		public LinkedList(){
			head = null;
		}
		public void AddItem(int data){
			Node element = new Node(data);
			element.next = head;
			head = element; 
		}
		public void AddAfter(Node prevNode, int data){
			Node element = new Node(data);
			if(prevNode == null)
			{
				Console.Write("Previous Node not found");
			}
			else {	
				element.next = prevNode.next;
				 prevNode.next = element; 
			}
		}
		public void PrintItem(){
			if(head == null){
				Console.WriteLine("head is null");
			
			}
			else {
			Node currentNode = head;
			while(currentNode != null){
				Console.WriteLine(currentNode.data + "->");
				currentNode = currentNode.next;
			}
			}
		}
		public void DeleteNode(int data){
			if(head.data == data){
				head = head.next;
			}
			else {
				Node temp = head, prev = null;
				while(temp!= null && temp.data != data){
					prev = temp;
					temp = temp.next;
				}
				if(temp == null){
					Console.WriteLine("Not Found");
				}
				else {
					prev.next = temp.next;
				}
			}
		}

		public int Count(bool isRecursive = false){
			if(isRecursive)
			{
				return CountRecursively(head);
			}
			else {
				Node temp = head;
				int count = 0;
				while(temp != null){
					count++;
					temp = temp.next;
				}
				return count;
			}		
		}
		public int CountRecursively(Node node){
			if(node == null){
				return 0;
			}
			
			return 1 + CountRecursively(node.next);
		}
	}
	public static void Main(string[] args){
		LinkedList  list = new LinkedList();
		list.AddItem(30);
		list.AddItem(10);
		list.AddAfter(list.head,20);
		list.PrintItem();
		Console.WriteLine("After Delete");
		//list.DeleteNode(20);
		list.PrintItem();
		//Console.WriteLine(list.Count());
		Console.WriteLine(list.Count(true));
	}
}