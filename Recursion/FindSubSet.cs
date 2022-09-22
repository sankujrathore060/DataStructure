using System;
using System.Collections.Generic;
class FindSubSet{
	
	public static void Subset(int[] nums, int index, List<int> output, List<List<int>> subset){
		if(index > nums.Length - 1)
		{
			 subset.Add(output);
			 return;
		}	
		Subset(nums, index +1, output, subset);
		
		List<int> result = new List<int>(output);
		result.Add(nums[index]);
		Subset(nums, index +1, result, subset);
	}

	
	public static void Main(string[] args){
		int[] nums = {1, 2, 3};
		List<List<int>> subset = new List<List<int>>();
		List<int> output = new List<int>();
		Subset(nums, 0, output, subset);
		foreach(var item in subset){
			string str = "";
			foreach(var item_inner in item){
				str+= item_inner + ",";		
			}
			Console.Write("{" + str + " }");
		}
 	}
}