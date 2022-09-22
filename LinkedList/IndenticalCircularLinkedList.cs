using System;

class Node{
	public int data;
	public Node next;
	public Node(int data){
		this.data =data;
		next = null;
	}
}

class IndenticalCircularLinkedList{
	public Node fillEmptyNode(Node last, int item){
		if(last != null)
			return last;
		Node node = new Node(item);
		last = node;
		last.next = last;
		return last;
	}

	public Node fillFromEnd(Node last, int item){
		if(last == null)
			return fillEmptyNode(last, item);

		Node node =  new Node(item);
		node.next = last.next;
		last.next = node;
		last = node;
		return last;
	}

	public int getNodeCount(Node list){
		int count = 0;
		Node temp = list.next;
		while(temp != list.next){
			count++;
			list = list.next;
		}
		return count;
	}
	
	public bool isIdentical(Node list1, Node list2){
		int firstCount = getNodeCount(list1);
		int secCount = getNodeCount(list2);
		
		if(firstCount != secCount)
			return false;

		int count = 0;
		Node temp1 = list1;
		Node temp2 = list2;
		bool isNotIdenticle = false;
		while(true){
			if(temp1.data == temp2.data){
				count++;
				temp1 = temp1.next;
				if(count == firstCount)
					return true;
			}
			else {
				temp1 = list1;
				count = 0;
				if(isNotIdenticle){
					return false;
				}
			}
			if(temp2.next == list2){
				isNotIdenticle = true;
			}
			temp2 = temp2.next;
		}		
	} 
	
	public static void Main(string[] args){
		IndenticalCircularLinkedList list = new IndenticalCircularLinkedList();
		Node last = null;
		last =  list.fillFromEnd(last, 1);
		last =  list.fillFromEnd(last, 2);
		last =  list.fillFromEnd(last, 3);
		last =  list.fillFromEnd(last, 4);
		last =  list.fillFromEnd(last, 5);
		last =  list.fillFromEnd(last, 1);
		last =  list.fillFromEnd(last, 2);
		last =  list.fillFromEnd(last, 6);
		
		IndenticalCircularLinkedList list2 = new IndenticalCircularLinkedList();
		Node last2 = null;
		last2 =  list2.fillFromEnd(last2, 5);
		last2 =  list2.fillFromEnd(last2, 1);
		last2 =  list2.fillFromEnd(last2, 2);
		last2 =  list2.fillFromEnd(last2, 6);
		last2 =  list2.fillFromEnd(last2, 1);
		last2 =  list2.fillFromEnd(last2, 2);
		last2 =  list2.fillFromEnd(last2, 3);
		last2 =  list2.fillFromEnd(last2, 4);
		Console.WriteLine(list.isIdentical(last, last2));
		
	}

}