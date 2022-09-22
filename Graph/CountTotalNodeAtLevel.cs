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
	public int CountOfNodesAtLevel(int level, string item){
		Dictionary<string, int> levelOfGraph = new Dictionary<string, int>();
		List<string> visitedNode = new List<string>();
		Queue<string> queue = new Queue<string>();
		queue.Enqueue(item);
		levelOfGraph.Add(item, 0);
		
		while(queue.Count > 0){
			string parent = queue.Dequeue();
			
			if(!visitedNode.Contains(parent)){
				
				visitedNode.Add(parent);
				SortedSet<string> childs = map[parent];
				if(childs.Count > 0){
					foreach(var child in childs){
						if(!visitedNode.Contains(child)){
							levelOfGraph.Add(child, levelOfGraph[parent] + 1);
							queue.Enqueue(child);
						}
					}					
				}
			}
		}
		
		
		int countOfNodes = 0;
		foreach(KeyValuePair<string, int> le in levelOfGraph){
			Console.WriteLine(le.Value);
			if(le.Value == level){
				countOfNodes++;
			}			
		}
		return countOfNodes;
	}
}

class CountTotalNodeAtLevel{

	public static void Main(string[] args){
		Graph graph = new Graph();
		Console.WriteLine("Enter Total Edges : -");
		int totalEdges = int.Parse(Console.ReadLine());
		for(int edge = 0; edge < totalEdges; edge++){
			string[] splited = Console.ReadLine().Split(new char[] { ' ' });
			graph.Add(splited[0], splited[1]);
		}
		graph.Print();
		Console.WriteLine("Enter level from graph to get count of nodes :- ");
		int level = int.Parse(Console.ReadLine());
		Console.WriteLine("Enter Start Node :- ");
		string startNode = Console.ReadLine();
		Console.WriteLine(graph.CountOfNodesAtLevel(level, startNode));
	}
}