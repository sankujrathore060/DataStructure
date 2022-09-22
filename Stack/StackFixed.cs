using System;

public class StackFixed{
	private int[] items;
	private int max;
	private int top;
	
	public StackFixed(int size){
		items = new int[size];
		max = size - 1;
		top = -1;
	}

	public int Push(int data){
		if(top == max){
			Console.WriteLine("Stack is Full");
			return -1;
		}
		items[++top] = data;
		return data;
	}
	public int Pop(){
		if(top == -1){
			Console.WriteLine("Stack is Empty");
			return -1;
		}
		return items[top--];
	}
	public int Peek(){
		if(top == -1){
			Console.WriteLine("Stack is Empty");
			return -1;
		}
		return items[top];
	}
	public void PrintStack(){
		for(int index = top; index > -1; index--)
			Console.Write(items[index] + " ");
		Console.WriteLine();
		
	}
	public static void Main(string[] args){
		StackFixed stack = new StackFixed(6);
		stack.Push(50);
		stack.PrintStack();

		stack.Push(40);
		stack.PrintStack();

		stack.Push(30);
		stack.PrintStack();

		stack.Push(20);
		stack.PrintStack();

		stack.Push(10);	
		stack.PrintStack();	
		
		stack.Pop();
		Console.WriteLine(stack.Peek());
		
		stack.PrintStack();	
	}
}