using System;
using System.Collections.Generic;

public class Graph{
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

	public void Print(){
		foreach(var item in map){
			Console.Write(item.Key + "->");
			foreach(var inner in item.Value){
				Console.Write(inner);
			}
			Console.WriteLine();
		}
	}

	public void TopologicalSort(string startNode, List<string> visitedNode, Stack<string> topologicalList){	
		visitedNode.Add(startNode);
		if(map.ContainsKey(startNode)){
			SortedSet<string> childs = map[startNode];
			foreach(var child in childs){
				if(!visitedNode.Contains(child))
				 	TopologicalSort(child, visitedNode, topologicalList);
			}
		}
		topologicalList.Push(startNode);
	}
}

public class TopologicalSorts{
	public static void Main(string[] args){
		Graph graph = new Graph();
		Console.WriteLine("Enter total edges");
		int totalEdges = int.Parse(Console.ReadLine());
		for(int edge = 0; edge < totalEdges; edge++){
			string[] nodes = Console.ReadLine().Split(new char[]{' '});
			graph.Add(nodes[0], nodes[1]);								
		}
		graph.Print();
		List<string> visitedNode = new List<string>();
		Console.WriteLine("Enter Start Node:-");
		Stack<string> topologicalList = new Stack<string>();
		string startNode = Console.ReadLine();
		graph.TopologicalSort(startNode, visitedNode, topologicalList);
		while(topologicalList.Count > 0){
			Console.Write(topologicalList.Pop() + " ");
		}
	}
}