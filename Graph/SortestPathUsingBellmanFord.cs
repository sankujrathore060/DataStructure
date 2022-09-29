using System;
using System.Collections.Generic;

class Graph{
	Dictionary<string, List<KeyValuePair<string, int>>> map;
	public Graph(){
		map = new Dictionary<string, List<KeyValuePair<string, int>>>();
	}

	public void Add(string node, string nextNode, int cost, bool IsUnDirected = false){
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
	
	public void SortestPathUsingBellmanFord(int nodeCount, string[] nodes, string startNode){
		Dictionary<string, int> distance = new Dictionary<string, int>();
		foreach(var node in nodes){
			distance.Add(node, int.MaxValue);
		}
		distance[startNode] = 0;
		for(int index =1 ; index < nodeCount; index++){
			foreach(var item in map){
				foreach(var inner in item.Value){
					if(distance[item.Key] + inner.Value < distance[inner.Key]){
						distance[inner.Key] = distance[item.Key] + inner.Value;
					}
				}
			}
		}
		bool isNagativeCycle = false;
		foreach(var item in map){
			foreach(var inner in item.Value){
				if(distance[item.Key] + inner.Value < distance[inner.Key]){
					isNagativeCycle = true;
				}
			}
		}
		
		if(isNagativeCycle){
			Console.WriteLine("Nagative Cycle");
		}
		else {
			foreach(var item in distance){
				Console.WriteLine(item + " ");
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
		
		Console.WriteLine("Enter Start Node");
		string startNode = Console.ReadLine();
		graph.SortestPathUsingBellmanFord(vertices.Length, vertices, startNode);		
	}
}