using System;
using System.Collections.Generic;

class Graph{
	Dictionary<string, List<KeyValuePair<string, int>>> map;
	public Graph(){
		map = new Dictionary<string, List<KeyValuePair<string, int>>>();
	}

	public void Add(string node, string nextNode, int cost, bool IsUnDirected = true){
		if(map.ContainsKey(node)){
			map[node].Add(new KeyValuePair<string, int>(nextNode, cost));
		}
		else {
			map.Add(node, new List<KeyValuePair<string, int>>() { new KeyValuePair<string, int>(nextNode, cost)});
		}
		if(IsUnDirected){
			if(map.ContainsKey(nextNode)){
				map[nextNode].Add(new KeyValuePair<string, int>(node, cost));
			}
			else {
				map.Add(nextNode, new List<KeyValuePair<string, int>>() { new KeyValuePair<string, int>(node, cost)});
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
	
	public string GetSortestCostVertexKey(Dictionary<string, int> set){
		int cost = int.MaxValue;
		string vertex = "";
		foreach(var item in set){
			if(item.Value < cost){
				cost = item.Value;
				vertex = item.Key;
			}
		}
		return vertex;
	}

	public void SortestPathUsingDijkstraAlgo(Dictionary<string, int> distance, string startNode){
		Dictionary<string, int> set = new Dictionary<string, int>();
		distance[startNode] = 0;		
		set.Add(startNode, 0);

		while(set.Count > 0){
			string sortestKey = GetSortestCostVertexKey(set);
			int sortestKeyCost = set[sortestKey];
			set.Remove(sortestKey);
			if(map.ContainsKey(sortestKey)){
				var childs = map[sortestKey];
				foreach(var child in childs){
					int totalCost = sortestKeyCost + child.Value;
					if(distance[child.Key] > totalCost){
						if(set.ContainsKey(child.Key)){
							set[child.Key] = totalCost;
						}
						else {
							set.Add(child.Key, totalCost);
						}
						distance[child.Key] = totalCost;
					}
				}
			}
		}
	}
}

public class SortestPathUsingDijkstra{
	public static void Main(string[] args){
		Graph graph = new Graph();
		
		Console.WriteLine("Enter all Vertices");
		string[] vertices = Console.ReadLine().Split(new char[] {' '});
		
		Console.WriteLine("Enter total Edges");
		int totalEdges = int.Parse(Console.ReadLine());
		
		for(int edge = 0; edge < totalEdges; edge++ ){
			string[] vertexDirection = Console.ReadLine().Split(new char[] {' '});
			int cost =  int.Parse(Console.ReadLine());
			
			graph.Add(vertexDirection[0], vertexDirection[1], cost);
		}
		Dictionary<string, int> distance = new Dictionary<string, int>();
		foreach(var vertex in vertices){
			distance.Add(vertex, int.MaxValue);
		}
			
		Console.WriteLine("Enter Start Node");
		string startNode = Console.ReadLine();

		graph.SortestPathUsingDijkstraAlgo(distance, startNode);
		foreach(var item in distance){
			Console.Write(item + " ");
		}
	}
}