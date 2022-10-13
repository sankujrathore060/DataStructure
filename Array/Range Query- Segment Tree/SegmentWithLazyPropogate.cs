using System;

class SegmentWithLazyPropogate{
	int[] seg, lazy;
		
	public SegmentWithLazyPropogate(int n){
		seg = new int[4*n];
		lazy = new int[4*n];
	}
	public void Build(int index, int start, int end, int[] arr){
		if(start == end){
			lazy[index] = 0;
			seg[index] = arr[start];
			return;
		}

		int mid = start + (end - start)/2;
		Build(2*index + 1, start, mid, arr);
		Build(2*index + 2, mid + 1, end, arr);
		lazy[index] = 0;
		seg[index] = seg[2 * index + 1] + seg[2*index + 2];	
	}
	
	public void Update(int index, int start, int end, int l, int r, int value){
		//Update prev Changes
		if(lazy[index] > 0){
			// Update
			seg[index] = seg[index] + (((end -start) + 1) * lazy[index]);
			//Lazy Propogate child
			if(start != end){
				lazy[2*index + 1] += lazy[index];
				lazy[2*index + 2] += lazy[index];
			}
			lazy[index] = 0;
		}

		//No overlap
		if(start > r || end < l){
			return;
		}

		//Complite Overlap
		if(start >= l && end <= r){
			seg[index] = seg[index] + (((end -start) + 1) *value);
			//Lazy Propogate child
			if(start != end){
				lazy[2*index + 1] += value;
				lazy[2*index + 2] += value;
			}
			return;
		}

		//Partial Overlap
		int mid = start + (end - start)/2;
		Update(2*index + 1, start, mid, l, r, value);		
		Update(2*index + 2, mid + 1, end, l, r, value);
		seg[index] = seg[2 * index + 1] + seg[2*index + 2];	
	}


	public int Query(int index, int start, int end, int l, int r){
		//Update prev Changes
		if(lazy[index] > 0){
			// Update
			seg[index] = seg[index] + (((end -start) + 1) * lazy[index]);
			//Lazy Propogate child
			if(start != end){
				lazy[2*index + 1] += lazy[index];
				lazy[2*index + 2] += lazy[index];
			}
			lazy[index] = 0;
		}

		//No overlap
		if(start > r || end < l){
			return 0;
		}

		//Complite Overlap
		if(start >= l && end <= r){
			return seg[index];
		}

		//Partial Overlap
		int mid = start + (end - start)/2;
		int left = Query(2*index + 1, start, mid, l, r);		
		int right = Query(2*index + 2, mid + 1, end, l, r);
		return left + right;	
	}

	public static void Main(string[] args){
		int n = int.Parse(Console.ReadLine());
		int[] arr = new int[n];
		
		for(int index =0; index < n; index++){
			arr[index] = int.Parse(Console.ReadLine());
		}
		SegmentWithLazyPropogate tree = new SegmentWithLazyPropogate(n);
		tree.Build(0, 0, n -1, arr);

		int q = int.Parse(Console.ReadLine());
		for(int index =0; index < q; index++){
			 string[] queries = Console.ReadLine().Split(new char[] {' '});
			if(int.Parse(queries[0]) == 1){
				Console.WriteLine(tree.Query(0, 0,  n -1, int.Parse(queries[1]), int.Parse(queries[2])));
			}
			else {
				tree.Update(0, 0,  n -1, int.Parse(queries[1]), int.Parse(queries[2]), int.Parse(queries[3]));
			}
				
		}
	}
}