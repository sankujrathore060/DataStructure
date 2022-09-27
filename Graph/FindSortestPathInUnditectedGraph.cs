using System;
using System.Collections.Generic;

class Graph{
	Dictionary<string, SortedSet<string>> map;
	public Graph(){
		map = new Dictionary<string, SortedSet<string>>();
	}

	public void Add(string node, string nextNode, bool isUndirected = true){
		if(map.ContainsKey(node)){
			map[node].Add(nextNode);
		}
		else {
			map.Add(node, new SortedSet<string>() { nextNode });
		}
		if(isUndirected){
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

	public List<string> SmallestPathBetweenTwoNode(string sourceNode, string destinationNode){
		List<string> visitedNode = new List<string>();
		Queue<string> queue = new Queue<string>();
		queue.Enqueue(sourceNode);
		
		Dictionary<string, string> parent = new Dictionary<string, string>();		
		
		while(queue.Count > 0){
			string frant = queue.Dequeue();
			if(map.ContainsKey(frant)){
				SortedSet<string> childs = map[frant];
				foreach(var child in childs){
					if(!visitedNode.Contains(child)){
						visitedNode.Add(child);
						parent.Add(child, frant);
						queue.Enqueue(child);	
					}
				}
			}
		}
		List<string> sortestPath = new List<string>();
		string currentNode = destinationNode;
		while(currentNode  != sourceNode){
			sortestPath.Add(currentNode);
			currentNode = parent[currentNode];
		}
		sortestPath.Add(currentNode);
		sortestPath.Reverse();
		
		return sortestPath;
	}

}

public class FindSortestPathInUnditectedGraph{
	public static void Main(string[] args){
		Graph graph = new Graph();
		Console.WriteLine("Enter total Edges");
		int totalEdges = int.Parse(Console.ReadLine());
		for(int edge = 0; edge < totalEdges; edge++){
			string[] nodes = Console.ReadLine().Split(new char[] { ' ' });
			graph.Add(nodes[0], nodes[1]);
		}

		graph.Print();

		Console.WriteLine("Enter source and destination Node");
		string[] pathNodes = Console.ReadLine().Split(new char[] {' '});
		List<string> sortestPath = graph.SmallestPathBetweenTwoNode(pathNodes[0], pathNodes[1]);
		foreach(var item in sortestPath){
			Console.Write(item + "->");
		}
	}
}