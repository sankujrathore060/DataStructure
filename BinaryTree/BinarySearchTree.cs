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
class BinarySearchTree{
	
	public static Node BuildTree(Node root, int item){
		Node node = new Node(item);
		if(root == null){
			return node;	
		}
		if(root.data > item){
			root.left = BuildTree(root.left, item);
		}
		else {
			
			root.right = BuildTree(root.right, item);	
		}
		return root;
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
	public static void Main(string[] args){
		Node root = null;
		int[] treeData = { 10, 8, 12, 4, 6, 15, 7, 19, 2, 22};
		foreach( var item in treeData){
			root = BuildTree(root, item);
		}
		Console.WriteLine("Level Of Travel");
		LevelOfTravel(root);

		Console.WriteLine("Inorder Travel");
		InOrderTraval(root);

		Console.WriteLine("Preorder Travel");
		PreOrderTraval(root);

		Console.WriteLine("Postorder Travel");
		PostOrderTraval(root);
	}
}