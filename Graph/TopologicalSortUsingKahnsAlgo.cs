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
		foreach(KeyValuePair<string, SortedSet<string>> item in map){
			Console.Write(item.Key + "->");
			foreach(var inner in item.Value){
				Console.Write(inner);
			}
			Console.WriteLine();
		}
	}

	public void TopologicalSort(string startNode, string[] vertices, List<string> topologicalList){
		Queue<string> queue = new Queue<string>();
		Dictionary<string, int> indegree = new Dictionary<string, int>();
		foreach(var vertex in vertices){
			 indegree.Add(vertex, 0);
		}
		foreach(var node in map){
			foreach(var nextNode in node.Value){
				indegree[nextNode]++;
			}
		}
		
		foreach(var item in indegree){
			if(item.Value == 0){				
				queue.Enqueue(item.Key);
			}
		}

		while(queue.Count > 0){
			string currentNode = queue.Dequeue();
			if(map.ContainsKey(currentNode)){
				SortedSet<string> childs = map[currentNode];
				foreach(var child in childs){
					indegree[child]--;
					if(indegree[child] == 0){
						queue.Enqueue(child);
					}
				}
			}
			topologicalList.Add(currentNode);
		}
	}
}

//BFS Technique
public class TopologicalSortUsingKahnsAlgo{
	public static void Main(string[] args){
		Graph graph = new Graph();
		
		//Get Total Edges
		Console.WriteLine("Enter total edges");
		int totalEdges = int.Parse(Console.ReadLine());
		
		Console.WriteLine("Enter All Vertices By Space Sep");
		string[] vertices = Console.ReadLine().Split(new char[] {' '});
		
		for(int edge = 0; edge < totalEdges; edge++){
			string[] nodes = Console.ReadLine().Split(new char[] {' '});
			graph.Add(nodes[0], nodes[1]);
		}

		// Print Graph		
		graph.Print();
		
		Console.WriteLine("Enter Start Node");
		string startNode = Console.ReadLine();
		List<string> topologicalList = new List<string>();

		graph.TopologicalSort(startNode, vertices, topologicalList);

		Console.WriteLine();
		foreach(var item in topologicalList){
			Console.Write(item + ",");
		}
	}		
}