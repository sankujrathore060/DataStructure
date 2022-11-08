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


class BinaryTrees{
	public static Node Build(int[] arr, int index){
		if(index > arr.Length - 1){
			return null;
		}

		Node root = new Node(arr[index]);
		root.left = Build( arr, 2*index + 1);
		root.right = Build( arr, 2*index + 2);
		return root;
	}

	public static void DFS(Node root){
		if(root == null)
			return;
		Console.Write(root.data + " ");
		DFS(root.left);
		DFS(root.right);
	}
	
	public static void BFS(Node root){
		Queue<Node> queue = new Queue<Node>();
		queue.Enqueue(root);
		while(queue.Count > 0){
			Node temp = queue.Peek();
			Console.Write(temp.data + " ");
			queue.Dequeue();
			if(temp.left != null){
				queue.Enqueue(temp.left);
			}

			if(temp.right != null){
				queue.Enqueue(temp.right);
			}
		}
		Console.WriteLine();	
	}

	public static void Inorder(Node root){
		if(root == null)
			return;

		Inorder(root.left);
		Console.Write(root.data + " ");
		Inorder(root.right);
	}

	public static void Preorder(Node root){
		if(root == null)
			return;

		Console.Write(root.data + " ");
		Preorder(root.left);
		Preorder(root.right);
	}

	public static void Postorder(Node root){
		if(root == null)
			return;
		
		Postorder(root.left);
		Postorder(root.right);
		Console.Write(root.data + " ");
	}
	public static void Main(string[] args){
		int[] arr = { 1, 3, 5, 7, 11, 17};
		Node root	= null;		
		root = Build(arr, 0);
		//DFS(root);
		BFS(root);	

		Console.WriteLine("Inorder");
		Inorder(root);	

		Console.WriteLine("Preorder");
		Preorder(root);	

		Console.WriteLine("Postorder");
		Postorder(root);
	}
}