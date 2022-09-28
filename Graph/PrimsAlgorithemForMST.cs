using System;
using System.Collections.Generic;
class Graph{
	Dictionary<string, List<KeyValuePair<string, int>>> map;

	public Graph(){
		map = new Dictionary<string, List<KeyValuePair<string, int>>>();
	}

	public void Add(string node, string nextNode, int cost, bool isUndirected = true){
		if(map.ContainsKey(node)){
			map[node].Add(new KeyValuePair<string, int>(nextNode, cost));
		}
		else {
			map.Add(node, new List<KeyValuePair<string, int>>(){ new KeyValuePair<string, int>(nextNode, cost) });
		}

		if(isUndirected){
			if(map.ContainsKey(node)){
				map[node].Add(new KeyValuePair<string, int>(nextNode, cost));
			}
			else {
				map.Add(node, new List<KeyValuePair<string, int>>(){ new KeyValuePair<string, int>(nextNode, cost) });
			}

		}
	}

	public string FindMinimumVertexKey(Dictionary<string, int> vertexCost, Dictionary<string, bool> mst){
		int minCost = int.MaxValue;
		string minVertex = "";
		foreach(var item in vertexCost){
			if(mst[item.Key] != true && item.Value < minCost){
				minCost = item.Value;
				minVertex = item.Key;
			}
		}
		return minVertex;
	}

	public Dictionary<string, KeyValuePair<string, int>> MinimumSpanningTree(string startNode, string[] vertices){
		Dictionary<string, int> vertexCost = new Dictionary<string, int>();
		Dictionary<string, bool> mst = new Dictionary<string, bool>();
		Dictionary<string, string> parent = new Dictionary<string, string>();
		
		foreach(var vertex in vertices){
			vertexCost.Add(vertex, int.MaxValue);
			mst.Add(vertex, false);
			parent.Add(vertex, "-1");
		}

		vertexCost[startNode] = 0;		
		
		for(int vertex = 0; vertex < vertices.Length; vertex++){
			string minVertex = FindMinimumVertexKey(vertexCost, mst);
			if(map.ContainsKey(minVertex)){
				var childs = map[minVertex];
				mst[minVertex] = true;
				foreach(var child in childs){
					if(mst[child.Key] == false && vertexCost[child.Key] > child.Value){
						parent[child.Key] = minVertex;
						vertexCost[child.Key]  = child.Value;
					}
				}
			}
		}
		
		Dictionary<string,KeyValuePair<string, int>> result = new Dictionary<string, KeyValuePair<string, int>>();
		foreach(var item in parent){
			if(item.Value != "-1"){
				result.Add(item.Key, new KeyValuePair<string, int>(item.Value, vertexCost[item.Key]));
			}
		}
		return result;
	}
}

public class PrimsAlgorithemForMST{
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

		Dictionary<string,KeyValuePair<string, int>> result = graph.MinimumSpanningTree(startNode, vertices);
		foreach(var item in  result){
			Console.Write(item + " ");
		}
	}
}
