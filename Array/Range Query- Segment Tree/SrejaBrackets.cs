using System;

class Node{
	public int open, close, full;
	public Node(int _open, int _close, int _full){
		open = _open;
		close = _close;
		full = _full;
	}
}

class SrejaBrackets{
	Node[] seg;
	public SrejaBrackets(int size){
		seg = new Node[4 * size];
	}	

	public void Build(int index, int start, int end, string[] arr){
		if(start == end){
			if(arr[start] == "(")
				seg[index] = new Node(1, 0,0) ;
			else if(arr[start] == ")")
				seg[index] = new Node(0, 1,0) ;
			return;
		}
		
		int mid = start + (end - start)/ 2;
		Build(2*index + 1, start, mid, arr);
		Build(2*index + 2, mid + 1, end, arr);
		
		int fullyBracket = seg[2*index + 1].full + seg[2*index + 2].full + 
			Math.Min(seg[2*index + 1].open, seg[2*index + 2].close);
		int openBracket = seg[2*index + 1].open + seg[2*index + 2].open-
			Math.Min(seg[2*index + 1].open, seg[2*index + 2].close);
		
		int closeBracket = seg[2*index + 1].close + seg[2*index + 2].close -
			Math.Min(seg[2*index + 1].open, seg[2*index + 2].close);

		seg[index] = new Node(openBracket, closeBracket, fullyBracket);		
	}

	public Node Query(int index, int start, int end, int l, int r){
		//No Overlap start end l r || l r start end
		if(end < l || start > r){
			return new Node(0, 0, 0);
		}

		//Complete Overlap l <= start && r>= end
		if(l <= start && r>= end){
			return seg[index];
		}

		int mid = start + (end - start)/2;
		Node left = Query(2 * index + 1, start, mid, l, r);
		Node right = Query(2 * index + 2, mid + 1, end, l, r);

		int fullyBracket = left.full + right.full + 
			Math.Min(left.open, right.close);
		int openBracket = left.open + right.open-
			Math.Min(left.open, right.close);
		
		int closeBracket = left.close + right.close -
			Math.Min(left.open, right.close);

		return new Node(openBracket, closeBracket, fullyBracket);	
	}

	public static void Main(string[] args){
		int n = int.Parse(Console.ReadLine());
		string[] arr =  new  string[n];
		
		for(int index = 0; index < n; index++){
			arr[index] =  Console.ReadLine();
		}
		
		SrejaBrackets brackets = new SrejaBrackets(n);
		brackets.Build(0, 0, n -1, arr);

		int q = int.Parse(Console.ReadLine());

		for(int index = 0; index < q; index++){
			string[] queries =  Console.ReadLine().Split(new char[] {' '});
			Node ans = brackets.Query(0, 0,n -1, int.Parse(queries[0]), int.Parse(queries[1]));
			Console.WriteLine(ans.full);			
		}
	}
}



