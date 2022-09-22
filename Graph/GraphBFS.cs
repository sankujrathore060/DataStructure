using System;
using System.Collections.Generic;

class  GraphBFS{
	Dictionary<string, SortedSet<string>> map;
	public GraphBFS(){
		map = new Dictionary<string, SortedSet<string>>();
	}

	public void Add(string node, string nextNode){
		if(map.ContainsKey(node)){
			map[node].Add(nextNode);
		}
		else {
			map.Add(node, new SortedSet<string>() { nextNode });
		}

		if(map.ContainsKey(nextNode)){
			map[nextNode].Add(node);
		}
		else {
			map.Add(nextNode, new SortedSet<string>() { node });
		}
	}

	public void Print(){
		foreach(var item in map){
			Console.Write(item.Key  +"->");
			foreach(var inner in item.Value){
				Console.Write(inner);
			}
			Console.WriteLine();
		}
	}

	public List<string> BFS(string node){	
		List<string> visitedNode= new List<string> ();
		Queue<string> queue = new Queue<string>();
		
		if(!visitedNode.Contains(node)){
			queue.Enqueue(node);
			while(queue.Count > 0){
				string data = queue.Dequeue();
				if(!visitedNode.Contains(data)){		
					 visitedNode.Add(data);
					if(map.ContainsKey(data))
					{
						SortedSet<string>  connectedNodes = map[data];
						foreach(var item in connectedNodes){
							queue.Enqueue(item);
						}
					}
				}
			}			
		}
		
		return visitedNode;
	}

	public void DFS(string node, List<string> visitedNode){	
		visitedNode.Add(node);
		SortedSet<string> connectedNodes= map[node];
		
		foreach(var item in connectedNodes){
			if(!visitedNode.Contains(item)){
				DFS(item, visitedNode);
			}
		}
	}

	public static void Main(string[] args){
		GraphBFS graph = new GraphBFS();
				
		Console.WriteLine("Enter Total Edegs");
		int totalEdges = int.Parse(Console.ReadLine());
		
		Console.WriteLine("Enter All Node");
		for(int edges = 0; edges <  totalEdges; edges++){
			string[] nodes = Console.ReadLine().Split(new char[] {' '});
			graph.Add(nodes[0], nodes[1]);	
		}

		graph.Print();
		Console.Write("Enter Node for Start :- ");
		string start = Console.ReadLine();
		List<string>  set = graph.BFS(start);	
			
		foreach(var item in set){
			Console.Write(item + " ");
		}
		 List<string> visitedNode = new List<string>();
		graph.DFS(start, visitedNode);
		Console.WriteLine();
		foreach(var item in visitedNode){
			Console.Write(item + " ");
		}	
	}
}