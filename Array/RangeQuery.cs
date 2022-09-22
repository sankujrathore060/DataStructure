public class RangeQuery{
	
	public static void CreateSparshTable(int[] nums, int[,] lookup){
		for(int index = 0; index < nums.Length)
			lookup[index,0] = index;
		
		for(int column = 1; Math.Pow(2, column) < nums.Length; column++){
			for(int row = 0; ((row + Math.Pow(2, column)) - 1) < nums.Length; row++){
				if(nums[lookup[row,column - 1]] < nums[lookup[row+Math.Pow(2, column - 1),column - 1]]){
					lookup[row,column] = lookup[row,column - 1];
				}
				else {
					lookup[row,column] = lookup[row+Math.Pow(2, column - 1),column - 1];
				}
			}
		}
	}
	public static int query(int L, int R){
		int length = (R- L) + 1;
		int j = (int)Math.Log(length);
		   if (nums[lookup[L, j]] <= nums[lookup[R - (1 << j) + 1, j]])
            			return nums[[lookup[L, j]];
     
        		else
            			return nums[[lookup[R - (1 << j) + 1, j]];
	}
	public static void Main(string[] args){
		int[] nums = {};
		
		int[,] lookup = new int[nums.Length,(int)Math.Log(nums.Length)];
		CreateSparshTable(nums, lookup);
		 Console.WriteLine(query(0, 4));
        		Console.WriteLine(query(4, 7));
        		Console.WriteLine(query(7, 8));
	}
}