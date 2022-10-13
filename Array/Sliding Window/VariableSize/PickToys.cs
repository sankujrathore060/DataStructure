using System;
using System.Collections.Generic;

class PickToys{
	public static void Main(string[] args){
		string toys = "abaccab";
		int pickToyTypes = 2, toyPicked = 0;
		int startToy = 0, endToy = 0;
		Dictionary<char, int> toyQuantity = new Dictionary<char, int>();

		while(endToy < toys.Length){
			if(toyQuantity.ContainsKey(toys[endToy])){
				toyQuantity[toys[endToy]]++;
			}
			else {
				toyQuantity.Add(toys[endToy], 1);
			}
			if(toyQuantity.Count < pickToyTypes){
				endToy++;
			}
			else if(toyQuantity.Count == pickToyTypes){
				toyPicked = Math.Max(toyPicked, (endToy - startToy) + 1);
				endToy++;
			}
			else if(toyQuantity.Count > pickToyTypes){
				toyQuantity[toys[startToy]]--;
				if(toyQuantity[toys[startToy]] == 0){
					toyQuantity.Remove(toys[startToy]);
				}

				startToy++;

				//For avoid duplicate Sum
				toyQuantity[toys[endToy]]--;
			}						
		}		
		Console.WriteLine("Toy Picked"+ toyPicked);
	}
}