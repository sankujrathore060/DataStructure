using System;

class Node{
	public int data;
	public Node next;
	public Node(int data){
		this.data = data;
		next = null;
	}		
}

class CircularLinkedList{
	public Node head;
	public Node pushToEmpty(Node last, int data){
		if(last != null)
			return last;
		Node node  = new Node(data);
		last = node;
		last.next = last;
		return node;	
	}

	public Node pushAtBeginning(Node last, int data){
		if(last == null)
			return pushToEmpty(last, data);

		Node node  = new Node(data);
		node.next = last.next;
		last.next = node;
		return last;	
	}
	public Node pushAtEnding(Node last, int data){
		if(last == null)
			return pushToEmpty(last, data);

		Node node  = new Node(data);
		node.next = last.next;
		last.next = node;
		last = node;
		return last;	
	}

	public Node pushAfter(Node last, int data, int key){
		if(last == null)
			return pushToEmpty(last, data);
		Node temp = last.next;
		Node node = new Node(data);
		do{
			if(temp.data == key){
				node.next = temp.next;
				temp.next = node;
				if(node  == last){
					last = node;
				}	
				return last;
			}
			temp = temp.next;
		} while(temp !=  last.next);
		return last;
	}

	public void PrintList(Node last){
		if(last != null)
		{
			Node current =  last.next;
			do{
				Console.Write(current.data + "->");
				current = current.next;
			} while(current != last.next);
		}
	}
	public Node DeleteNodeFromList(Node last, int item){
		if((last == null) || (last.data == item && last.next == last)){
			return last;
		}
		Node prevNode = last, currentNode = last.next;
		do{
			if(currentNode.data == item){
				prevNode.next = currentNode.next;
				if(currentNode == last){
					last = prevNode;
				}
				break;	
			}
			prevNode = currentNode;
			currentNode = currentNode.next;
		} while(currentNode != last.next);
		
		return last;		
	}

	public bool CheckForLinkedListIsCircular(Node head1){
		if(head1 == null)
			return true;

		Node temp = head1.next;
		while(temp != head1){
			if(temp.next == null)
				return false;
			temp = temp.next;
		}	
		return true;	
	}
	public int GetCountOfNodes(Node last){
		int count = 0;
		if(last == null)
			return count;

		Node temp = last.next;
		do{
			count++;
			temp = temp.next;
		}while(temp != last.next);	
		return count;	
	}
	public static void Main(string[] args){
		CircularLinkedList list = new CircularLinkedList();
		Node last = null;
		last = list.pushAtBeginning(last, 10);
		last = list.pushAtEnding(last, 20);
		last = list.pushAtEnding(last, 40);
		last = list.pushAtBeginning(last, 50);
		list.PrintList(last);
		last = list.pushAfter(last, 30, 20);
		Console.WriteLine();
		list.PrintList(last);
		
		last = list.DeleteNodeFromList(last, 30);
		Console.WriteLine();
		
		list.PrintList(last);
		CircularLinkedList temp = new CircularLinkedList();
		temp.head = new Node(20);
		temp.head.next = new Node(50);
		Console.WriteLine(temp.CheckForLinkedListIsCircular(temp.head));
		
		Console.WriteLine(temp.CheckForLinkedListIsCircular(last));
		Console.WriteLine(temp.GetCountOfNodes(last));
	}
}
