using System;
public class SortingStringProgram{
	
	public static string SortStringUsingArray(string element){
		char[] elements = element.ToCharArray();
		
		Array.Sort(elements);
		return new string(elements);
	}
	public static string SortString(string element){
		int[] elements = new int[26];
		int[] capitalElements = new int[26];
		for(int index =0; index < element.Length; index++){
			if('A' <= element[index] && element[index] <= 'Z'){
				capitalElements[element[index] - 'A']++;
			}
			else {
				elements[element[index] - 'a']++;
			}
		}
		string finalElement = "";
		for(int index = 0; index <elements.Length; index++ ){
			while(elements[index] > 0){
				finalElement += (char)(index + 'a');
				elements[index]--;
			}
			while(capitalElements[index] > 0){
				finalElement += (char)(index + 'A');
				capitalElements[index]--;
			}
		}
		return finalElement;
	}
	
	public static string SortArrayOfStringAccordinglLength(string[] s, int n){

		
		Array.Sort(s, delegate(string s1, string s2) { return s1.Length - s2.Length;  });
		return string.Join(" ", s);
		
	}
	public static int SortByAlphabet(string s1, string s2){
		int low = 0, high = Math.Min(s1.Length, s2.Length);
		while(s1[low] == s2[low] && low <= high){
			low++;
			continue;
		}
		
		if(low <= high){
			return s1[low].CompareTo(s2[low]);
		}
		return s1.CompareTo(s2);		
	}
	public static string SortArrayOfStringUsingOrder(string[] s){
		Array.Sort(s, delegate(string s1, string s2) { return SortByAlphabet(s1, s2); });
		string finalString = "";
		for(int index = 1; index < s.Length; index++){
			if(s[index] != s[index - 1])
				finalString = finalString  +" "+ s[index - 1];
		}
	
		finalString  = finalString  +" "+ s[s.Length - 1];
		return finalString;
	}	

	public static int compareTowString(string first, string secound){
		int index = 0;
		while(index < first.Length - 1 && first[index] == secound[index])
			index++;
		if(index <first.Length -1 && first[index] < secound[index])
			return -1;
		if(index < first.Length -1&& first[index] > secound[index])
			return 1;
		return 0;
	}
	
	public static int SearchKeyFromArray(string[] array, string key){
		int lower = 0, higher = array.Length - 1;
		while(lower <= higher){
			int mid = (lower + higher)/ 2;
			if(string.IsNullOrEmpty(array[mid])){
				int left = mid - 1;
				int right = mid + 1;
				while(left >= lower && right <= higher){
					if(!string.IsNullOrEmpty(array[right]))
					{
						mid = right;
						break;
					}
					else if(!string.IsNullOrEmpty(array[left]))
					{
						mid = left;
						break;
					}		
					left--;
					right++;			
				}		
			}
	
			if(compareTowString(array[mid], key) == 0){
				return mid;		
			}
			else if(compareTowString(array[mid], key) == -1){
				lower = mid +1;
			}
			else {
				higher = mid - 1;
			}
		}

		return -1;
	}
	
	public static void Main(string[] args){
		//Console.WriteLine(SortStringUsingArray("hello"));
		//Console.WriteLine(SortString("HhelloAa"));
		 //String[] arr = {"GeeksforGeeks", "I", "from", "am"};
        		//int n = arr.Length;
		//Console.WriteLine(SortArrayOfStringAccordinglLength(arr, n));
		//Console.WriteLine(SortArrayOfStringUsingOrder(new string[] { "abc", "xy", "bcd" }));
		Console.WriteLine(SearchKeyFromArray(new string[] { "for", "", "", "", "geeks","ide", "", "practice", "","", "quiz", "", "" }, "ide"));
	}
}