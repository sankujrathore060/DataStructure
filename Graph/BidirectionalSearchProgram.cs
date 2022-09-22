using System;
using System.Collections.Generic;

class Graph{
	Dictionary<string, SortedSet<string>> map;
	public Graph(){
		map = new Dictionary<string, SortedSet<string>>();
	}

	public void Add(string firstNode, string nextNode, bool isDirected = false){
		if(map.ContainsKey(firstNode)){
			map[firstNode].Add(nextNode);
		}
		else {
			map.Add(firstNode, new SortedSet<string>(){ nextNode });
		}
	
		if(!isDirected){
			if(map.ContainsKey(nextNode)){
				map[nextNode].Add(firstNode);
			}
			else {
				map.Add(nextNode, new SortedSet<string>(){ firstNode });
			}
		}
	}

	public bool IsIntersectNode(string node, List<string> visitedNode){
		return visitedNode.Contains(node);
	}

	public List<string> BidirectionalSearch(string start, string end){
		Queue<string>  forwardQueue = new Queue<string>();
		Queue<string> backwardQueue = new Queue<string>();

		List<string> visitedNodeForward = new List<string>();
		List<string> visitedNodeBackword = new List<string>();

		forwardQueue.Enqueue(start);
		backwardQueue.Enqueue(end);

		while(forwardQueue.Count > 0 && backwardQueue.Count > 0){
			string forwardFrant = forwardQueue.Dequeue();
			string backwordFrant = backwardQueue.Dequeue();
			
			if(!visitedNodeForward.Contains(forwardFrant)){
				visitedNodeForward.Add(forwardFrant);
				if(map.ContainsKey(forwardFrant)){		
					SortedSet<string> childs = map[forwardFrant];
					foreach(var child in childs){
						forwardQueue.Enqueue(child);
					}
				}
			}
			
			if(!visitedNodeBackword.Contains(backwordFrant)){
				visitedNodeBackword.Add(backwordFrant);
				if(map.ContainsKey(backwordFrant)){		
					SortedSet<string> childs = map[backwordFrant];
					foreach(var child in childs){
						backwardQueue.Enqueue(child);
					}
				}
			}
			bool isBackwordContain = IsIntersectNode(forwardFrant, visitedNodeBackword);
			bool isForwardContain = IsIntersectNode(backwordFrant, visitedNodeForward);
			if(isBackwordContain && isForwardContain){
				break;
			}
		}

		List<string> visitedNode = new List<string>();
		foreach(var item in visitedNodeForward){
			visitedNode.Add(item);
		}
		foreach(var item in visitedNodeBackword){
			if(!visitedNode.Contains(item)){
				visitedNode.Add(item);
			}
		}

		return visitedNode;
	}
}

public class BidirectionalSearchProgram{

	public static void Main(string[] args){
		Graph graph = new Graph();
		Console.WriteLine("Enter Total Edges");
		int totalEdges = int.Parse(Console.ReadLine());
		for(int edge = 0; edge < totalEdges; edge++){
			string[] nodes = Console.ReadLine().Split(new char[] {' '});
			graph.Add(nodes[0], nodes[1]);
		}
		Console.WriteLine("Enter Start Node");
		string startNode = Console.ReadLine();

		Console.WriteLine("Enter End Node");
		string endNode = Console.ReadLine();
		
		List<string>  visitedList = graph.BidirectionalSearch(startNode, endNode);
		foreach(var item in visitedList){
			Console.Write(item + "-");
		}
	}
}