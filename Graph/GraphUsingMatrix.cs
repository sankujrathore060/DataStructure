using System;

class GraphUsingMatrix{
	int[,] map;
	public GraphUsingMatrix(int nodes){
		map = new int[nodes, nodes];
	}	
	
	public void Add(int node, int nextNode, bool isDirected = false){
		map[node, nextNode] = 1;
		if(isDirected){
			map[nextNode, node] = 1;
		}
	}

	public void Print(){
		Console.WriteLine(map.Length);
		for(int node = 0; node < map.GetLength(0); node++){
			Console.Write(node + "->");
			for(int nextNode = 0; nextNode < map.GetLength(0); nextNode++){
				if(map[node, nextNode] == 1){	
					Console.Write(nextNode);
				}
			}
			Console.WriteLine();
		}
	}

	public static void Main(string[] args){
		Console.WriteLine("Enter total Nodes");
		
		int n = int.Parse(Console.ReadLine());
		GraphUsingMatrix matrix = new GraphUsingMatrix(n);
		
		Console.WriteLine("Enter total Edes");
		int m = int.Parse(Console.ReadLine());
		
		for(int edge = 0; edge <  m; edge++){
			string[] nodes = Console.ReadLine().Split(new char[]{' '});
			matrix.Add(int.Parse(nodes[0]), int.Parse(nodes[1]));
		}

		matrix.Print();	
	}
}