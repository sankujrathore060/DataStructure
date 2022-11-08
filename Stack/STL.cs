using System;
using System.Collections.Generic;

class STL{
	public static void Main(string[] args){
		Stack<int> stack = new Stack<int>();
		
		stack.Push(10);
		Console.WriteLine(stack.Peek());	
		
		stack.Push(20);
		Console.WriteLine(stack.Peek());	
		
		stack.Push(30);
		Console.WriteLine(stack.Peek());	
		
		Console.WriteLine(stack.Pop());
		
		Console.WriteLine(stack.Peek());	
		
		stack.Push(50);
		Console.WriteLine(stack.Peek());	
		Console.WriteLine(stack.Count);
	}
}