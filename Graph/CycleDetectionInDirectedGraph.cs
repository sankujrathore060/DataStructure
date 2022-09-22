using System;
using System.Collections.Generic;

class Graph{
	Dictionary<string, SortedSet<string>> map;
	public Graph(){
		map = new Dictionary<string, SortedSet<string>>();
	}
	
	public void Add(string node, string nextNode, bool isUnDirected = false){
		if(map.ContainsKey(node)){
			map[node].Add(nextNode);
		}
		else{
			map.Add(node, new SortedSet<string>() { nextNode });
		}

		if(isUnDirected){
			if(map.ContainsKey(nextNode)){
				map[nextNode].Add(node);
			}
			else{
				map.Add(nextNode, new SortedSet<string>() { node });
			}
		}			
	}	

	public bool IsCycleDetect(string startNode, List<string> visitedNode, List<string> dfs_Visited){
		visitedNode.Add(startNode);
		if(map.ContainsKey(startNode)){
			SortedSet<string> childs = map[startNode];
			foreach(var child in childs){
				if(!visitedNode.Contains(child)){
					dfs_Visited.Add(startNode);
					bool isDetect = IsCycleDetect(child, visitedNode, dfs_Visited);
					if(isDetect)
						return true;
					dfs_Visited.Remove(startNode);
				}
				else if(dfs_Visited.Contains(child)){
					return true;
				}
			}
		}
		return false;
	}
	
}
public class CycleDetectionInDirectedGraph{

	public static void Main(string[] args){
		Graph graph = new Graph();

		Console.WriteLine("Enter Total Nodes");
		int totalEdges= int.Parse(Console.ReadLine());

		for(int edge = 0; edge < totalEdges; edge++){
			string[] data = Console.ReadLine().Split(new char[] {' '});
			graph.Add(data[0], data[1]);
		}

		List<string> visitedNode = new List<string>();
		List<string> dfs_Visited = new List<string>();
		bool IsDetected = false;
		string[] nodes = { "a", "b", "c",  "d", "e", "f", "g" };
		foreach(var item in nodes){
			if(!visitedNode.Contains(item)){
				IsDetected = graph.IsCycleDetect(item, visitedNode, dfs_Visited);
			}
		}
		if( IsDetected)
			Console.WriteLine("Yes");
		else 
			Console.WriteLine("No");
	}
}