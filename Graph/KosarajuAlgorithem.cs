using System;
using System.Collections.Generic;

class Graph{
	Dictionary<string, SortedSet<string>> map;

	public Graph(){
		map = new Dictionary<string, SortedSet<string>>();
	}

	public void Add(string node , string nextNode, bool isUnDirected = false){
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
	
	public void TopologicalSort(string startNode, Stack<string> topologicalSort, List<string> visitedNode){
		visitedNode.Add(startNode);
		if(map.ContainsKey(startNode)){
			SortedSet<string> childs = map[startNode];
			foreach(var child in childs){
				if(!visitedNode.Contains(child)){
					TopologicalSort(child, topologicalSort, visitedNode);
				}
			}
		}
		topologicalSort.Push(startNode);	
	}

	public Dictionary<string, SortedSet<string>> TransposeGraph(){
		Dictionary<string, SortedSet<string>> transposeMap = new Dictionary<string, SortedSet<string>>();
		foreach(var item in map){
			foreach(var inner in item.Value){
				if(transposeMap.ContainsKey(inner)){
					transposeMap[inner].Add(item.Key);
				}
				else {
					transposeMap.Add(inner, new SortedSet<string>(){ item.Key });
				}
			}
		}
		return transposeMap;
	}
	
	public void DFS(string startNode, List<string> visitedNode, Dictionary<string, SortedSet<string>> transposeGraph, List<string> dfs){
		visitedNode.Add(startNode);
		dfs.Add(startNode);
		if(transposeGraph.ContainsKey(startNode)){
			SortedSet<string> childs = transposeGraph[startNode];
			foreach(var child in childs){
				if(!visitedNode.Contains(child)){	
					DFS(child, visitedNode, transposeGraph, dfs);
				}
			}
		}
	}
	
	public List<List<string>> StronglyConenctedComponentUsingKausarajuAlgorithem(string[] vertices){	
		Stack<string> topologicalSort = new Stack<string>();
		List<string> visitedNode = new List<string>();
		
		foreach(var vertex in vertices){
			if(!visitedNode.Contains(vertex)){
				TopologicalSort(vertex, topologicalSort, visitedNode);
			}
		}

		var transposeGraph = TransposeGraph();

		visitedNode = new List<string>();
		List<List<string>> stronglyConnectedComponent = new List<List<string>>();
		foreach(var vertex in vertices){
			if(!visitedNode.Contains(vertex)){
				List<string> dfs = new List<string>();
				DFS(vertex, visitedNode, transposeGraph, dfs);
				stronglyConnectedComponent.Add(dfs);
			}
		}	
		return stronglyConnectedComponent;
	}
}

public class KosarajuAlgorithem{
	public static void Main(string[] args){
		Graph graph = new Graph();
		
		Console.WriteLine("Enter All Nodes");
		string[] vertices = Console.ReadLine().Split(new char[] { ' ' });
		
		Console.WriteLine("Enter total Edges");
		int totalEdges = int.Parse(Console.ReadLine());

		for(int edge = 0; edge < totalEdges; edge++){
			string[] nodes = Console.ReadLine().Split(new char[] { ' ' });
			graph.Add(nodes[0], nodes[1]);
		}
		
		var components = graph.StronglyConenctedComponentUsingKausarajuAlgorithem(vertices);

		foreach(var com in  components){
			foreach(var item in com){
				Console.Write(item + " ");
			}
			Console.WriteLine();
		}
	}
}