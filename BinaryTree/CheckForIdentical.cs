using System;
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

class CheckForIdentical{
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
	public static bool IsIdentical(Node root1, Node root2){
		if(root1 == null && root2 == null){
			return true;
		}
		if(root1 != null && root2 == null){
			return false;
		}
		if(root1 == null && root2 != null){
			return false;
		}
		
		bool leftIdentical = IsIdentical(root1.left, root2.left);
		bool rightIdentical = IsIdentical(root1.right, root2.right);
		
		if(leftIdentical && rightIdentical && root1.data == root2.data){
			return true;
		}
		else{
			return false;
		} 	
	}
	public static void Main(string[] args){
		Node root1 = null, root2 = null;
		BuildTree(root1);
		Console.Write("other tree");
		BuildTree(root2);
		Console.WriteLine(IsIdentical(root1, root2));
	}
}