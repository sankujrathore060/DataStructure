using System;

class Node{
	public char data;
	public Node[] children;
	public bool isTerminal;

	public Node(char data){
		this.data = data;
		children = new Node[26];
		isTerminal = false;
	}
}

class Trie{	
	Node root;
	public Trie(){
		root  = new Node('0');
	}
	
	public void InsertUtil(string word, Node node){
		if(word.Length == 0){
			node.isTerminal = true;
			return;
		}

		//assume all latter in capital latter
		int index = word[0] - 'A';
		Node child;
		if(node.children[index] != null){
			child = node.children[index];	
		}	
		else {
			child = new Node(word[0]);
			node.children[index] = child;
		}
		InsertUtil(word.Substring(1), child);
	}

	public void InsertWord(string word){
		InsertUtil(word, root);		
	}

	public bool SearchUtil(Node node, string word){
		if(word.Length == 0){
			return node.isTerminal;
		}

		int index = word[0] - 'A';
		Node child;
		if(node.children[index] != null){
			child = node.children[index];
		}
		else {
			return false;
		}
		
		return SearchUtil(child, word.Substring(1));		
	}

	public bool SearchWord(string str){
		return SearchUtil(root, str);
	}

	public static void Main(string[] args){
		Trie trie = new Trie();

		trie.InsertWord("ABCD");
		trie.InsertWord("TIME");
		trie.InsertWord("BOY");
		trie.InsertWord("DOG");
		trie.InsertWord("DEAR");
		Console.WriteLine(trie.SearchWord("DEA"));
	}
}
