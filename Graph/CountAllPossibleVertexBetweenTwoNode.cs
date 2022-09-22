using System;
using System.Collections.Generic;
class Graph{
	Dictionary<string, SortedSet<string>> map;
	public Graph(){
		map = new Dictionary<string, SortedSet<string>>();
	}

	public void Add(string node, string nextNode, bool isDirected = false){
		if(map.ContainsKey(node)){
			map[node].Add(nextNode);
		}
		else {
			map.Add(node, new SortedSet<string>() { nextNode });
		}
		if(!isDirected){
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
			Console.Write(item.Key + "-> ");
			foreach(var data in item.Value){
				Console.Write(data + ",");
			}
			Console.WriteLine();
		}
	}
	public void CountOfPathBetweenTwoNode(string startNode, string endNode, List<string> visitedNode, ref int countOfPathReach, List<List<string>> allPaths){
		if(startNode == endNode){
			allPaths.Add(visitedNode);
			countOfPathReach++;
		}
		else{
		List<string> copyOfVisitedNode = visitedNode;
		copyOfVisitedNode.Add(startNode);
		if(map.ContainsKey(startNode)){
			SortedSet<string> allNode  = map[startNode];
			foreach(var item in allNode){
				if(!copyOfVisitedNode.Contains(item)){
					CountOfPathBetweenTwoNode(item, endNode, copyOfVisitedNode, ref countOfPathReach, allPaths);
				}
			}			
		}
		}
	}
}

class CountAllPossibleVertexBetweenTwoNode{

	public static void Main(string[] args){
		Graph graph = new Graph();
		Console.WriteLine("Enter Total Edges : -");
		int totalEdges = int.Parse(Console.ReadLine());
		for(int edge = 0; edge < totalEdges; edge++){
			string[] splited = Console.ReadLine().Split(new char[] { ' ' });
			graph.Add(splited[0], splited[1], true);
		}
		graph.Print();
		int countOfPathReach = 0;
		List<string> visitedNode = new List<string>();

		Console.WriteLine("Enter the Start Node");
		string startNode = Console.ReadLine();

		Console.WriteLine("Enter the End Node");
		string endNode = Console.ReadLine();
		List<List<string>> allPaths = new List<List<string>>();
		graph.CountOfPathBetweenTwoNode(startNode, endNode, visitedNode, ref countOfPathReach, allPaths);
		Console.WriteLine(countOfPathReach);

		foreach(var item in allPaths){
			foreach(var data in item){
				Console.Write(data + " -> ");
			}
			Console.WriteLine();
		}
	}
}