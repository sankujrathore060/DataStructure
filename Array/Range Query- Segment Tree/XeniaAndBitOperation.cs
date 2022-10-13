using System;

class XeniaAndBitOperation{
	public int[] seg;
	public XeniaAndBitOperation(int n){
		seg = new int[4 * n];
	}
	
   	public void Build(int index, int start, int end, int[] arr, bool isxor){
		if(start == end)
		{
			seg[index] = arr[start];
			return;
		}

		int mid = start + ( end - start) / 2;
		Build( 2 * index + 1, start, mid, arr, !isxor);
		Build(2 * index + 2, mid + 1, end, arr, !isxor);
		if(isxor){
			seg[index] = seg[2 * index + 1]^ seg[2 * index + 2];
		}
		else {
			seg[index] = seg[2 * index + 1] | seg[2 * index + 2];		
		}
	}
	public void Update(int index, int start, int end, int currentIndex, int value, bool isxor){
		if(start == end){
			seg[index] = value;
			return;
		}	
		int mid = start + ( end - start) / 2;
		if(currentIndex <= mid){
			Update(2 * index + 1, start, mid, currentIndex, value, !isxor);
		}
		else {
			Update(2 * index + 2, mid + 1, end, currentIndex, value, !isxor);
		}
		if(isxor){
			seg[index] = seg[2 * index + 1]^ seg[2 * index + 2];
		}
		else {
			seg[index] = seg[2 * index + 1] | seg[2 * index + 2];		
		}
	}

	public static void Main(string[] args){
		int n = int.Parse(Console.ReadLine());
		int[] arr = new int[n];

		for(int index = 0; index < n; index++){
			arr[index] = int.Parse(Console.ReadLine());
		}

		XeniaAndBitOperation tree = new XeniaAndBitOperation(n);	
		if(n % 2 != 0){	
			tree.Build(0, 0, n-1, arr, false);
		}
		else {
			tree.Build(0, 0, n-1, arr, true);
		}

		int q = int.Parse(Console.ReadLine());
		for(int index = 0; index < q; index++){
			var queries = Console.ReadLine().Split(new char[] {' '});
			if(n % 2 != 0){	
				tree.Update(0, 0, n-1, int.Parse(queries[0]), int.Parse(queries[1]), false);
			}
			else {
				tree.Update(0, 0, n-1, int.Parse(queries[0]), int.Parse(queries[1]), true);
			}
		}

		Console.WriteLine(tree.seg[0]);
	}
}