using System;
using System.Collections.Generic;
class SpecialStack{
	int[] items;
	int max;
	int top;
	Stack<int> min = new Stack<int>();
	
	public SpecialStack(int size){
		items = new int[size];
		max = size-1;
		top = -1;
	}
		
	public int Push(int data){
		if(max == top){
			return -1;
		}
		items[++top] = data;
		if(min.Count == 0){
			min.Push(items[top]);
		}
		else{
			int prev = min.Peek();
			min.Push(Math.Min(items[top], prev));
		}
 		return data;		
	}	

	public int Pop(){
		if(top == -1){
			return -1;
		}
		return items[top--];		
	}

	public int Peek(){
		if(top == -1){
			return -1;
		}
		return items[top];
	}

	public int GetMin(){
		return min.Peek();
	}

	public static void Main(string[] args){
		SpecialStack ss = new SpecialStack(5);
		ss.Push(5);
		ss.Push(3);
		ss.Push(6);
		ss.Push(1);
		ss.Push(15);
		ss.Push(0);
		ss.Pop();
		Console.WriteLine(ss.GetMin());
	}	
}