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
			foreach(var data in item.Value){
				Console.Write(data + ",");
			}
			Console.WriteLine();
		}		
	}

	public bool IsCycleDetected(string startNode, List<string> visitedNode){
		Queue<string> queue = new Queue<string>();
		Dictionary<string, string> parent = new Dictionary<string, string>();
		Console.WriteLine("Start");
		queue.Enqueue(startNode);
		visitedNode.Add(startNode);

		while(queue.Count > 0){
			string frant = queue.Dequeue();
			if(map.ContainsKey(frant)){
				SortedSet<string> childs = map[frant];
				foreach(var child in childs){
					if(visitedNode.Contains(child) && parent.ContainsKey(child) && parent[child] != frant){
						return true;		
					}
					if(!visitedNode.Contains(child)){
						queue.Enqueue(child);
						visitedNode.Add(child);
						parent.Add(child, frant);
					}
				}
			}		
		}
		return false;
	}
}

class CycleDetecion{
	public static void Main(string[] args){
		Graph graph = new Graph();
		bool isCycleDetacted = false;
		List<string> visitedNode = new List<string>();
		Console.WriteLine("Enter Total Edges");
		int totalEdges = int.Parse(Console.ReadLine());
		
		for(int edge = 0; edge < totalEdges; edge++){
			string[] data =  Console.ReadLine().Split(' ');
			graph.Add(data[0], data[1], true);			
		}
		graph.Print();

		string[] nodes = { "a","b", "c", "d", "e", "f", "g", "h" };
		foreach(var item in nodes){
			if(!visitedNode.Contains(item)){
				if(graph.IsCycleDetected(item,visitedNode)){
					isCycleDetacted = true;
					break;
				}
			}
		}
		if(isCycleDetacted)
			Console.WriteLine("Yes");
		else 
			Console.WriteLine("No");
	}
}