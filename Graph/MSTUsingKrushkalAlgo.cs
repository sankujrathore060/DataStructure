using System;
using System.Collections.Generic;

class Edge{
	public string node, nextNode;
	public int cost;
	public Edge(string node, string nextNode, int cost){
		this.node = node;
		this.nextNode = nextNode;
		this.cost = cost;
	}
}

class Graph{
	List<Edge> edges;

	public Graph(){
		edges = new List<Edge>();	
	}
	public void Add(string node, string nextNode, int cost){
		edges.Add(new Edge(node, nextNode, cost));
	}

	public void Sort(){
		edges.Sort(delegate(Edge e1, Edge e2) { return e1.cost - e2.cost; });
	}
	
	public void InitializeDS(Dictionary<string, string> parent, Dictionary<string, int> rank, string[] vertices){
		foreach(var vertex in vertices){
			parent.Add(vertex, vertex);
			rank.Add(vertex, 0);
		}
	}

	public string FindParent(string node, Dictionary<string, string> parent){
		if(parent[node] == node){
			return node;
		}
		parent[node] = FindParent(parent[node], parent);
		return parent[node];
	}

	public void UnionVertices(string node, string nextNode, Dictionary<string, string> parent, Dictionary<string, int> rank){
		string parentOfNode = FindParent(node, parent);
		string parentOfNextNode = FindParent(nextNode, parent);

		if(rank[parentOfNode] < rank[parentOfNextNode]){
			parent[parentOfNode] = parent[parentOfNextNode];
		}
		else if(rank[parentOfNode] > rank[parentOfNextNode]){
			parent[parentOfNextNode] = parent[parentOfNode];
		}
		else {
			parent[parentOfNode] = parent[parentOfNextNode];
			rank[parentOfNextNode]++;
		}
	}
	
	public int KrushkalAlgoForMST(string[] vertices){
		Dictionary<string, string> parent = new Dictionary<string, string>(); 
		Dictionary<string, int> rank = new Dictionary<string, int>();
		Sort();

		// initialize require DS
		InitializeDS(parent, rank, vertices);

		
		int minCost = 0;	
		foreach(var edge in edges){
			string parentOfNode = FindParent(edge.node, parent);
			string parentOfNextNode = FindParent(edge.nextNode, parent);
			if(parentOfNode != parentOfNextNode){
				minCost+=edge.cost;
				UnionVertices(edge.node, edge.nextNode, parent, rank);
			}
		}
		return minCost;
	}
}

public class MSTUsingKrushkalAlgo{
	public static void Main(string[] args){
		Graph graph = new Graph();
		
		Console.WriteLine("Enter all vertices");
		string[] vertices = Console.ReadLine().Split(new char[]{' '});
		
		Console.WriteLine("Enter All Edges");
		int totalEdges = int.Parse(Console.ReadLine());
		
		for(int edge = 0; edge < totalEdges; edge++){
			string[] nodes = Console.ReadLine().Split(new char[]{' '});
			int cost = int.Parse(Console.ReadLine());
			
			graph.Add(nodes[0], nodes[1], cost);
		}

		int mstWeight = graph.KrushkalAlgoForMST(vertices);
		Console.WriteLine("Minimum Weight is:-" + mstWeight);	
	}
}