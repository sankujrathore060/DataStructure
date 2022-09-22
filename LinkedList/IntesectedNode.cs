using System;
using System.Collections.Generic;
public class Node {
	public int data;
	public Node next;
	public Node(int data){
		this.data = data;
		next = null;
	}
}

class LinkedList{
	public Node head1, head2;
	Node common;
	public LinkedList(){
		head1 = null;
		head2 = null;	
	}
	
	public void push(Node commonNode){
		if(common == null){
			common = commonNode;	
		}
		else {
			commonNode.next = common;
			common = commonNode; 
		}
		PrintNode();	
	}

	public int FindIntersectNode(){
		HashSet<int> set = new HashSet<int>();
		Node  temp  = head1;
		while(temp != null){
			set.Add(temp.data);
			temp = temp.next;
		}
		
		Node temp2  = head2;
		while(temp2 != null){
			if(set.Contains(temp2.data))
				return temp2.data;
			
			temp2 = temp2.next;
		}
		return -1;
	}

	public int GetCountOfLinkedNodes(Node head){
		int count = 0;
		while(head != null){
			count++;
			head = head.next;
		}
		return count;
	}
	
	public int GetIntersectNode(int difference, Node h1, Node h2){
		for(int index = 0; index <  difference; index++){
			h1 = h1.next;
		}
		
		while(h1 != null && h2 != null){
			if(h1.data == h2.data)
				return h1.data;
			h1 = h1.next;
			h2 = h2.next;
		}	
		return -1;
	}

	public int FindIntersectNodeUsingCount(){
	       int count1 = GetCountOfLinkedNodes(head1);
	       int count2 = GetCountOfLinkedNodes(head2);
		if(count1 > count2){
			return  GetIntersectNode(count1 - count2, head1, head2);
		}
		else {
			return  GetIntersectNode(count2 - count1, head2, head1);	
		}
	}

	public int FindIntersectNodeUsingTwoPointer(){
		Node ptr1 = head1;
		Node ptr2 = head2;
		if(ptr1 == null || ptr2 == null)
			return -1;
		while(ptr1.data != ptr2.data){
			ptr1 = ptr1.next;
			ptr2 = ptr2.next;
			
			if(ptr1.data == ptr2.data){
				return ptr1.data;
			}
			if(ptr1 == null){
				ptr1 = head2;
			}
			
			if(ptr2 == null){
				ptr2 = head1;
			}
		}
		
		return -1;
	}
	

	
	public void FindIntersectNodeForSortedList(){
		Node ptr1 = head1;
		Node ptr2 = head2;
		
		while(ptr1 != null && ptr2 != null){
			if(ptr1.data == ptr2.data){
				
				push(ptr1);	
				PrintNode();
				ptr1 = ptr1.next;
				ptr2 = ptr2.next;
			}
			else if(ptr1.data < ptr2.data){
				ptr1 = ptr1.next;
			}
			else {
				ptr2 = ptr2.next;
			}	
		}	
	}

	public void PrintNode(){
		while(common!= null){
			Console.Write(common.data + "->");	
			common = common.next;	
		}
			Console.WriteLine();
	}
}

public class IntesectedNode{

	
	public static void Main(string[] args){
		LinkedList list = new LinkedList();	
		        list.head1 = new Node(3);
        			list.head1.next = new Node(6);
        			list.head1.next.next = new Node(9);
        			list.head1.next.next.next = new Node(15);
        			list.head1.next.next.next.next = new Node(30);
        			list.head1.next.next.next.next.next = new Node(60);
 
 
       			 // creating second linked list
        			list.head2 = new Node(6);
       			list.head2.next = new Node(15);
       			list.head2.next.next = new Node(30);
       			list.head2.next.next.next = new Node(50);

		list.FindIntersectNodeForSortedList();
		//list.PrintNode();
	}	
}