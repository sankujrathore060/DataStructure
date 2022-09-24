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
		else {
			map.Add(node, new SortedSet<string>() { nextNode });
		}
		
		if(isUnDirected){
			if(map.ContainsKey(nextNode)){
				map[nextNode].Add(node);	
			}	
			else {
				map.Add(nextNode, new SortedSet<string>() { node });
			}
		}
	}

	public void Print(){
		foreach(var item in map){
			Console.Write(item.Key + " ->");
			foreach(var innerItem in item.Value){
				Console.Write(innerItem);
			}
			Console.WriteLine();	
		}
	}	

	public bool hasCycle(string currentNode, List<string> visitedNodes, List<string> dfsVisited){
		visitedNodes.Add(currentNode);
		if(map.ContainsKey(currentNode)){
			SortedSet<string> childs = map[currentNode];
			foreach(string child in childs){
				if(!visitedNodes.Contains(child))
				{
					dfsVisited.Add(child);
					bool isCycle = hasCycle(child, visitedNodes, dfsVisited);
					if(isCycle){
						return true;
					}
					dfsVisited.Remove(child);
				}
				else if(dfsVisited.Contains(child)){
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
		Console.WriteLine("Enter total Nodes");
		int totalNodes = int.Parse(Console.ReadLine());
		for(int node = 0; node < totalNodes; node++){
			string[] nodes = Console.ReadLine().Split(new char[] { ' ' });
			graph.Add(nodes[0], nodes[1]);
		}
		graph.Print();

		Console.WriteLine("Enter Start Node");
		string startNode = Console.ReadLine();
		List<string> visitedNodes = new List<string>();
		List<string> dfsVisited = new List<string>();
 		dfsVisited.Add(startNode);
		bool isCycle = graph.hasCycle(startNode, visitedNodes, dfsVisited);
		if(isCycle){
			Console.WriteLine("Yes");
		}
		else {
			Console.WriteLine("No");
		}
	}
}