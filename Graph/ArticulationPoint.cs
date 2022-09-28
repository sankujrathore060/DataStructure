using System;
using System.Collections.Generic;
class Graph{
	Dictionary<string, SortedSet<string>> map;
	public Graph(){
		map = new Dictionary<string, SortedSet<string>>();
	}
	public void Add(string node, string nextNode, bool isUnDirected = true){
		if(map.ContainsKey(node)){
			map[node].Add(nextNode);
		}
		else {
			map.Add(node, new SortedSet<string>(){ nextNode });
		}

		if(isUnDirected){
			if(map.ContainsKey(nextNode)){
				map[nextNode].Add(node);
			}
			else {
				map.Add(nextNode, new SortedSet<string>(){ node });
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
	public void DFS(Dictionary<string, int> disc,  Dictionary<string, int> low, string parent, List<string> visitedNode, string startNode, int timer, List<string> result){
		disc[startNode] = timer++;
		low[startNode] = timer++;
		visitedNode.Add(startNode);
		
		if(map.ContainsKey(startNode)){
			SortedSet<string> childs = map[startNode];
			int totalChild = 0;
			foreach(var child in childs){
				if(child == parent)
					continue;

				if(!visitedNode.Contains(child)){
					DFS(disc, low, startNode, visitedNode, child, timer, result);
					low[startNode] = Math.Min(low[startNode], low[child]);
					if(low[child] >= disc[startNode] && parent != "-1"){
						result.Add(startNode);
					}
					totalChild++;
				}
				else {
					low[startNode] = Math.Min(disc[child], low[startNode]);
				}
			}
			if(parent == "-1" && totalChild > 1){
				result.Add(startNode);
			}	
		}
	}
}

public class ArticulationPoint{
	public static void Main(string[] args){
		Graph graph = new Graph();
		Console.WriteLine("Enter Nodes");
		string[] vertices = Console.ReadLine().Split(new char[] {' '});
		
		Console.WriteLine("Enter total Edges");
		int totalEdges = int.Parse(Console.ReadLine());
		
		for(int edge =0; edge < totalEdges; edge++){
			string[] nodes = Console.ReadLine().Split(new char[] {' '});
			graph.Add(nodes[0], nodes[1]);
		}

		Dictionary<string, int> disc = new Dictionary<string, int>();
		Dictionary<string, int> low = new Dictionary<string, int>();
		List<string> visitedNode = new List<string>();
		List<string> result = new List<string>();
		foreach(var vertex in vertices){
			disc.Add(vertex, -1);
			low.Add(vertex, -1);
		}
		foreach(var vertex in vertices){
			if(!visitedNode.Contains(vertex))
				graph.DFS(disc,  low, "-1", visitedNode, vertex, 0, result);
		}
		foreach(var item in result){
			Console.Write(item + " ");
		}
	}
}