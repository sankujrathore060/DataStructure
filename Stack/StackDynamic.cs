using System;

class Node{
	public int data;
	public Node next;
	public Node(int data){
		this.data = data;
		next = null;
	}
}
public class StackDynamic{
	Node top = null;
	public void Push(int data){
		Node node = new Node(data);
		if(top == null){
                                		top = node;
                                   }
		else {
			node.next = top;
			top = node;
		}
	}

	public int Pop(){
		if(top == null){
			Console.WriteLine("Stack is Empty");
			return -1;
		}
		top = top.next;
		return top.data;
	}

	public int Peek(){
		if(top == null){
			Console.WriteLine("Stack is Empty");
			return -1;
		}
		return top.data;
	}

	public void Print(){
		Node temp  = top;
		while(temp != null){
			Console.Write(temp.data + " ");
			temp  = temp.next;
		}
		Console.WriteLine();
	}

	public static void Main(string[] args){
		StackDynamic stack = new StackDynamic();
		stack.Push(50);
		stack.Print();
		stack.Push(40);
		stack.Print();
		stack.Push(30);
		stack.Print();
		stack.Push(20);
		stack.Print();
		stack.Push(10);
		stack.Print();
		stack.Pop();
		Console.WriteLine(stack.Peek());
		stack.Print();
	}
}