using System;

class StackUsingArray{
	int top;
	int[] s;
	int size;
	public StackUsingArray(int size){
		top = -1;
		s = new int[size];
		this.size = size;
	}

	public void Push(int data){
		if(top == size - 1){
			Console.WriteLine("Stack Overflow");
			return; 
		}
		top++;
		s[top] = data;
	}

	
	public int Pop(){
		if(top == -1){
			Console.WriteLine("Stack Empty");
			return -1;
		}

		int data = s[top];
		top--;
		return data;
	}

	public int Peek(){
		if(top == -1){
			Console.WriteLine("Stack Empty");
			return -1;
		}
		return s[top];
	}	

	public bool IsEmpty(){
		if(top == -1)
			return true;
		return false;
	}

	public int Count(){
		return s.Length;
	}

	public static void Main(string[] args){
		StackUsingArray stack = new StackUsingArray(4);
		stack.Push(50);
		Console.WriteLine(stack.Peek());

		stack.Push(40);
		Console.WriteLine(stack.Peek());
	
		stack.Push(30);
		Console.WriteLine(stack.Peek());
	
		stack.Push(20);
		Console.WriteLine(stack.Peek());
		
		//stack.Push(10);
		Console.WriteLine(stack.Peek());
		Console.WriteLine("Pop Element"+ stack.Pop());
		
		Console.WriteLine(stack.Peek());
		Console.WriteLine(stack.IsEmpty());
		Console.WriteLine(stack.Count());
		stack.Pop();stack.Pop();stack.Pop();stack.Pop();
		Console.WriteLine(stack.IsEmpty());
	}
}