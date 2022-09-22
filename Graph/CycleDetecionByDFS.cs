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

	public bool IsCycleDetected(string startNode, string parent, List<string> visitedNode){
		visitedNode.Add(startNode);
		if(map.ContainsKey(startNode)){
			SortedSet<string> childs = map[startNode];
			foreach(var item in childs){
				if(!visitedNode.Contains(item)){
					bool isDetect = IsCycleDetected(item, startNode, visitedNode);	
					if(isDetect)
						return true;
				}
				else if(item != parent){
					return true;
				}
			}
		}
		return false;
	}
}

class CycleDetecionByDFS{
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
				if(graph.IsCycleDetected(item, "",visitedNode)){
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