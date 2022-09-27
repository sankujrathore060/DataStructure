using System;
using System .Collections.Generic;
class Graph{
	Dictionary<string, SortedSet<string>> map;
	public Graph(){
		map =  new Dictionary<string, SortedSet<string>>();
	}
	
	public void Add(string node, string nextNode, bool isUnDirected = false){
		if(map.ContainsKey(node)){
			map[node].Add(nextNode);
		}
		else {
			map.Add(node, new SortedSet<string>() {nextNode});
		}
		
		if(isUnDirected){
			if(map.ContainsKey(nextNode)){
				map[nextNode].Add(node);
			}
			else {
				map.Add(nextNode, new SortedSet<string>() {node});
			}
		}
	}

	public void Print(){
		foreach(var item in map){
			Console.Write(item.Key + "->");
			foreach(var inner in  item.Value){
				Console.Write(inner);
			}
			Console.WriteLine();
		}
	}

	public bool IsGenerateCycle(string startNode, string[] nodes){
		Queue<string> queue = new Queue<string>();
		Dictionary<string, int> indegreeOfNode = new Dictionary<string, int>();
	
 		foreach(var node in nodes){
			indegreeOfNode.Add(node, 0);
		}

		foreach(var item in map){
			foreach(var inner in item.Value){
				indegreeOfNode[inner]++;
			}
		}
	
		foreach(var node in indegreeOfNode){
			if(node.Value == 0){
				queue.Enqueue(node.Key);
			}
		}
		int count = 0;
		while(queue.Count > 0){
			string parent = queue.Dequeue();
			count++;
			if(map.ContainsKey(parent)){
				SortedSet<string> childs = map[parent];
				foreach(var child in childs){
					indegreeOfNode[child]--;
					if(indegreeOfNode[child] == 0){
						queue.Enqueue(child);
					}
				}			
			}		
		}
		if(count == nodes.Length){
			return false;
		}
		else {
			return true;
		}
	}
}

public class CycleDetectionInDirectedGraphUsingBFS{
	public static void Main(string[] args){
		Graph graph = new Graph();
		
		Console.WriteLine("Enter All Nodes Space Sep");
		string[] vertices = Console.ReadLine().Split(new char[] { ' ' });
		
		Console.WriteLine("Enter total edges");
		int totalEdges = int.Parse(Console.ReadLine());
		
		for(int edge = 0; edge <  totalEdges; edge++){
			string[] nodes = Console.ReadLine().Split(new char[] { ' ' });
			graph.Add(nodes[0], nodes[1]);
		}

		graph.Print();
		
		Console.WriteLine("Enter Start Node");
		string startNode = Console.ReadLine();
		bool hasCycle = graph.IsGenerateCycle(startNode, vertices);
		if(hasCycle){
			Console.WriteLine("Yes");
		}
		else {
			Console.WriteLine("No");
		}
	}
}