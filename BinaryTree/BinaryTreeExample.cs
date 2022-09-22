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

class BinaryTreeExample{
	
	public static Node BuildTree(Node root){
		Console.WriteLine("Enter node data : - ");
		int data = int.Parse(Console.ReadLine());
		
		if(data == -1){
			return null;
		}
		root = new Node(data);
		
		Console.WriteLine("Enter left node for : - {0} ", data);
		root.left = BuildTree(root.left);
		 
		Console.WriteLine("Enter right node for : - {0} ", data);
		root.right = BuildTree(root.right);
		return root;
	} 

	public static int HightOfTree(Node root){
		if(root == null)
			return 0;
		return Math.Max(HightOfTree(root.left) , HightOfTree(root.right)) + 1;
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

	public static int Height(Node root){
		if(root == null)
			return 0;
		return Height(root.left) +Height(root.right) + 1;
	}
	public static int FindHighestDiameter(Node root){
		if(root == null){
			return 0;
		}
		
		int left = FindHighestDiameter(root.left);
		int right = FindHighestDiameter(root.right);
		int current = Height(root.left) + Height(root.right) + 1;
		return Math.Max(left, Math.Max(right, current));		
	}
	public static int[] FindFastHighestDiameter(Node root){
		if(root == null){
			return new int[]{0,0};
		}
		 int[] leftPart = FindFastHighestDiameter(root.left);
		int[] rightPart = FindFastHighestDiameter(root.right);
		int left = leftPart[0];
		int right = rightPart[0];
		int current = leftPart[1] + rightPart[1] + 1;
		int[] result = new int[2];
		result[0] = Math.Max(left, Math.Max(right, current));
		result[1] = Math.Max(leftPart[1], rightPart[1]) +1;
		return result;		
	}

	public static void Main(string[] args){
		Node root = null;
		root = BuildTree(root);
		Console.WriteLine(HightOfTree(root));
		LevelOfTravel(root);
		Console.WriteLine(FindHighestDiameter(root));
		int[] result = FindFastHighestDiameter(root);
		Console.WriteLine("-----------------------------");
		Console.WriteLine(Math.Max(result[0], result[1]));
	}
}