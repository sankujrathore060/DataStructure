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

class CheckForSumTree{
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
	
	public static int[] IsSumTree(Node root){
		if(root == null){
			return new int[]{1, 0};		
		}
		if(root.left == null && root.right == null){
			return new int[]{1, root.data};		
		}
		int[] leftInfo = IsSumTree(root.left);
		int[] rightInfo = IsSumTree(root.right);
		int isLeft = leftInfo[0];
		int isRight = rightInfo[0];
		bool isCurrent = (leftInfo[1] + rightInfo[1]) == root.data;
		int[] currentInfo = new int[2];
		if(isLeft == 1&& isRight == 1&& isCurrent){
			currentInfo[0] = 1;
		}
		else {
			currentInfo[0] = 0;
		} 
		currentInfo[1] = leftInfo[1] + rightInfo[1];
		return currentInfo;
	}
		
	public static void Main(string[] args){
		Node root = null;
		root = BuildTree(root);

		int[] info =  IsSumTree(root);
		if(info[0] == 1){
			Console.WriteLine("Sum Tree");
		}
		else {
			Console.WriteLine("Not Sum Tree");
		}
	}
}