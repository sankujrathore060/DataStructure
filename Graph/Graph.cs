using System;
using System.Collections.Generic;

class Graph{
	Dictionary<int, List<int>> map;
	public Graph(){
		map = new Dictionary<int, List<int>>();
	}

	public void Add(int node, int nextNode, bool isDirected = false){
		if(map.ContainsKey(node)){
			map[node].Add(nextNode);
		}
		else {
			map.Add(node, new List<int>(){nextNode});
		}
		if(!isDirected)
		{
			if(map.ContainsKey(nextNode)){
				map[nextNode].Add(node);
			}
			else {
				map.Add(nextNode, new List<int>(){node});
			}	
		}										
	}

	public void Print(){
		foreach(KeyValuePair<int, List<int>> item in map){
			Console.Write(item.Key + "->");
			foreach(int inner in item.Value){
				Console.Write(inner);
			}
			Console.WriteLine();
		}
	}

	public static void Main(string[] args){
		Graph graph =  new Graph();
		graph.Add(0, 1);
		graph.Add(0, 4);
		graph.Add(1, 3);
		graph.Add(1, 2);
		graph.Add(2, 3);
		graph.Add(3,4);
		graph.Print();
	}

}


