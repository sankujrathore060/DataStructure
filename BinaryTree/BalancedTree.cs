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

class BalancedTree{
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
	public static int[] IsBalanced(Node root){
		if(root == null)
			return new int[]{1, 0};
		int[] leftInfo = IsBalanced(root.left);
		int[] rightInfo = IsBalanced(root.right);
		int[] currentInfo = new int[2]; 
		
		bool isBalanced = Math.Abs(leftInfo[1] - rightInfo[1]) <= 1;
		if(leftInfo[0] == 1 && rightInfo[0] == 1 && isBalanced){
			currentInfo[0] = 1;
		}
		else {
			currentInfo[0] = 0;
		} 

		currentInfo[1] = Math.Max(leftInfo[1], rightInfo[1]) + 1;	
		Console.WriteLine(currentInfo[1] + " --- "+currentInfo[0]);
		return currentInfo;			
	}
	public static void Main(string[] args){
		Node root = null;
		root = BuildTree(root);

		int[] result = IsBalanced(root);
		if(result[0] == 1){
			Console.Write("True");
		}
		else {
			Console.Write("False");
		}

	}
} 