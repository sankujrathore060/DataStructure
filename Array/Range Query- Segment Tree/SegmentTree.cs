using System;

class SegmentTree {
	int[] seg;
	public SegmentTree(int n){
		seg = new int[4*n];
	} 	
	
	public void Build(int index,int start, int end, int[] arr){
		if(start == end){
			seg[index] = arr[start];
			return;
		}
		
		int mid = start + (end - start) / 2;

		Build(2 * index + 1, start, mid, arr);
		Build(2 * index + 2, mid + 1, end, arr);
		seg[index] = Math.Min(seg[2 * index + 1], seg[2 * index + 2]);
		Console.WriteLine(seg[index]);
	}
	
	public int Query(int index, int start, int end, int l, int r){
		//range no overlap- start end l r Or l r start end
		if(start > r || end < l){
			return int.MaxValue;
		}
		
		//complete onverlap  l start end r
		if(start >= l && end <= r){
			return seg[index];
		}

		//partialy overlap  start l end r Or l start r end
		int mid = start + (end - start) / 2;
		// Query On Left Part
		int left = Query(2 * index + 1, start, mid, l, r);
		
		// Query On Right Part
		int right = Query(2 * index + 2, mid + 1, end, l, r);
		
		return Math.Min(left, right);
	}
	
	public void Update(int index, int start, int end, int changeIndex, int value){
		if(start == end){
			seg[index] = value;
			return;
		}	

		int mid = start + (end - start) / 2;
		if(changeIndex <= mid){
			Update(2 * index + 1, start, mid, changeIndex, value);
		}
		else {
			Update(2 * index + 2, mid + 1, end, changeIndex, value);
		}

		seg[index] = Math.Min(seg[2*index + 1], seg[2*index + 2]);
	}
	public static void Main(string[] args){
		Console.WriteLine("Enter arr size");
		int n = int.Parse(Console.ReadLine());
		int[] arr = new int[n];
		
		Console.WriteLine("Enter arr data");
		for(int index = 0; index < n; index++){
			arr[index] = int.Parse(Console.ReadLine());
		}				

		SegmentTree tree = new SegmentTree(n);
		tree.Build(0, 0, n - 1, arr);
		Console.WriteLine("Build Successfully");	
		
		 Console.WriteLine("Enter total query");
		int q =  int.Parse(Console.ReadLine());
		for(int index = 0; index < q; index++){


			string[] queries = Console.ReadLine().Split(new char[] {' '});
			if(queries[0] == "a"){
				int ans = tree.Query(0, 0, n -1, int.Parse(queries[1]), int.Parse(queries[2]));
				Console.WriteLine(ans);
			}
			else {
				tree.Update(0, 0, n -1,  int.Parse(queries[1]), int.Parse(queries[2]));				
			}
		}		
	}
}