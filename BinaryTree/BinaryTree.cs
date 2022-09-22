using System;
using System.Collections.Generic;

class Node{
	public int data;
	public Node left;
	public Node right;
	public Node(int data){
		this.data = data;
		left = null;
		right = null;
	}
}


class BinaryTree{
	
	public static Node BuildTree(Node parent){

	Console.WriteLine("Enter Parent Node :- ");
	int data = int.Parse(Console.ReadLine());
	  
	if(data == -1)
	{
		return null;
	}
 	 parent = new Node(data);

	Console.WriteLine("Enter Left part of" + data);
	parent.left = BuildTree(parent.left);

	Console.WriteLine("Enter Right part of" + data);
	parent.right = BuildTree(parent.right);	
	return parent;	
	}

	public static void LevelOfTravel(Node root){
		Queue<Node> queue = new Queue<Node>();
		queue.Enqueue(root);
		queue.Enqueue(null);
		while(queue.Count > 0){
			
			Node temp = queue.Dequeue();
			if(temp == null){
				Console.WriteLine();
				if(queue.Count > 0){
					queue.Enqueue(null);
				}
			}
			else {
			Console.Write(temp.data + " ");
			if(temp.left != null){
				queue.Enqueue(temp.left);
			}

			if(temp.right != null){
				queue.Enqueue(temp.right);
			}
			
			}
		}
	}
	
	public static void InOrderTraval(Node root){
		if(root == null){
			return;
		}

		InOrderTraval(root.left);
		Console.Write(root.data + " ");
		InOrderTraval(root.right);
	}

	public static void PreOrderTraval(Node root){
		if(root == null)
			return;
		Console.Write(root.data + " ");
		PreOrderTraval(root.left);
		PreOrderTraval(root.right);
	}

	public static void PostOrderTraval(Node root){
		if(root == null)
			return;
		PostOrderTraval(root.left);
		PostOrderTraval(root.right);
		Console.Write(root.data + " ");
	}

	public static void BuildTreeFromLevelOfTravel(Node root){
		Console.WriteLine("Enter root : -");
		int data =  int.Parse(Console.ReadLine());
		root = new Node(data);
		Queue<Node> queue = new Queue<Node>();
		queue.Enqueue(root);

		while(queue.Count > 0){
			Node temp = queue.Dequeue();
				
			Console.WriteLine("Enter LeftNode :-" + temp.data + "->");
			int left =  int.Parse(Console.ReadLine());
			if( left  != -1)
			{
				temp.left = new Node(left);
				queue.Enqueue(temp.left);
			}
			Console.WriteLine("Enter RightNode :-" + temp.data + "->");
			int right =  int.Parse(Console.ReadLine());
			if( right  != -1)
			{			
				temp.right = new Node(right);
				queue.Enqueue(temp.right);
			}
		}
	}

	public static void ZigZagTraval(Node root, List<int> record){
		Queue<Node> queue = new Queue<Node>();
		queue.Enqueue(root);
		bool isLeftToRight = true;
		while(queue.Count > 0){
			int[] subRecord = new int[queue.Count];
			for(int index = 0; index < queue.Count; index++){
				Node temp = queue.Dequeue();
				int subindex = isLeftToRight? index:  queue.Count - index - 1;

				subRecord[subindex] = temp.data;

				if(temp.left != null){
					queue.Enqueue(temp.left);
				}
				if(temp.right != null){
					queue.Enqueue(temp.right);
				}
			}
			foreach(var item in subRecord){
				record.Add(item);
			}
  		}
		
	}

	public static void Main(string[] args){

		/*Node root = null;
		 BuildTreeFromLevelOfTravel(root);
		LevelOfTravel(root);*/

		Node root = null;
		root = BuildTree(root);
		
		LevelOfTravel(root);
		
		Console.WriteLine();
		InOrderTraval(root);
		
		Console.WriteLine();
		PreOrderTraval(root);
	
		Console.WriteLine();
		PostOrderTraval(root);

		Console.WriteLine("ZigZag");
		List<int> data =  new List<int>();
		ZigZagTraval(root, data);
		foreach(var item in data){
			Console.Write(item + " ");
		}
	}	
}
