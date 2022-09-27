using System;
using System.Collections.Generic;

class Graph{
	Dictionary<string, List<KeyValuePair<string, int>>> map;
	public Graph(){
		map = new Dictionary<string, List<KeyValuePair<string, int>>>();
	}
	
	public void Add(string node, string nextNode, int cost){
		if(map.ContainsKey(node)){
			map[node].Add(new KeyValuePair<string, int>(nextNode, cost));
		}
		else {
			map.Add(node, new List<KeyValuePair<string, int>>() {  new KeyValuePair<string, int>(nextNode, cost) });
		} 
	}

	public void Print(){
		foreach(var item in map){
			Console.Write(item.Key + "->");
			foreach(var inner in item.Value){				
				Console.Write("(" + inner.Value  + ")" + inner.Key + ",");
			}
			Console.WriteLine();
		}
	}

	public void TopologicalSort(string currentNode, List<string> visitedNode, Stack<string> topologicalSort){
		visitedNode.Add(currentNode);
		if(map.ContainsKey(currentNode)){
			List<KeyValuePair<string, int>>  childs = map[currentNode];
			foreach(var child in childs){
				if(!visitedNode.Contains(child.Key)){
					TopologicalSort(child.Key, visitedNode, topologicalSort);
				}
			}
		}
		topologicalSort.Push(currentNode);
	}

	public void FindSortestPath(string startNode,  Dictionary<string, int> distance, Stack<string> topologicalSort){
		distance[startNode] = 0;
		while(topologicalSort.Count > 0){
			string data = topologicalSort.Pop();
			if(distance[data] != int.MaxValue){
				if(map.ContainsKey(data)){
					List<KeyValuePair<string, int>> childs = map[data];
					foreach(var child in childs){
						int parentDistance = distance[data];
						int currentDistance = parentDistance + child.Value;
						distance[child.Key] = Math.Min(distance[child.Key], currentDistance);
					}
				}
			}
		}
	}
}

public class SortedPathInDirectedGraph{
	public static void Main(string[] args){
		Graph graph = new Graph();
		
		Console.WriteLine("Enter all vertex spec sep");
		string[] vertices = Console.ReadLine().Split(new char[] { ' ' });
		
		Console.WriteLine("Enter Total Edges");
		int totalEdges = int.Parse(Console.ReadLine());
		
		for(int edge = 0; edge < totalEdges; edge++){
			string[] nodes = Console.ReadLine().Split(new char[] {' '});
			int cost = int.Parse(Console.ReadLine());
			graph.Add(nodes[0], nodes[1], cost);
		}

		graph.Print();

		 List<string> visitedNode = new List<string>();
		 Stack<string> topologicalSort = new Stack<string>();
		for(int vertex = 0; vertex < vertices.Length; vertex++){
			if(!visitedNode.Contains(vertices[vertex])){
				graph.TopologicalSort(vertices[vertex], visitedNode, topologicalSort);	
			}
		}
		Dictionary<string, int> distance =  new Dictionary<string, int>();
		foreach(var vertex in vertices){
			distance.Add(vertex, int.MaxValue);
		}
		
		 Console.WriteLine("Enter Start Node and EndNode");			                   
		 string startNode = Console.ReadLine();
		graph.FindSortestPath(startNode, distance, topologicalSort);
		
		foreach(var item in distance){
			Console.Write(item + " ");
		}
	}
}