using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTravails
{
    public class DijkstraAlgorithm : SingleSourceShortestPathStrategy
    {
        private const int INFINITE_DISTANCE = 256; // simulate infinity assuming this will be greater than any Nodes's distance from any source

        public DijkstraAlgorithm(Square source, ChessBoardPieceGraph graph) : base(source, graph)
        {
            //might want to initialize shortest paths to all destinations
        }

        public override List<Square> GetShortestPathTo(Square destination)
        {
            //Nodes are initialized with node.distance=MAX_DISTANCE and node.Previous as null by constructor
            var sourceNode = new Node() {Square = Source}; // wrapping source Square into a graph Node
            sourceNode.Distance = 0;  // Initialize source Node distance=0, source to source distance is zero

            var q = new Dictionary<Square, Node> { { Source, sourceNode } };  // initialise nodes(vertexes collection) 
                                                                              // using Square keyed Dictionary for low-cost lookup with Square 
                                                                              // instead of a custom-implemented priority Queue
            Graph.Vertexes.Where(sq => sq != Source).Select(sq => new Node() {Square = sq}).ToList().ForEach(
                n => q.Add(n.Square, n));

            bool unreachable = false;                           // flag to detect if destination unreachable although for knight graph its not possible
            while (q.Count != 0)                                // The main loop
            {
                var p = q.OrderBy(x => x.Value.Distance).First();  // popping keyvalue pair with Node having minimum distance, Start node in first case
                
                var u = p.Value;                                // Getting the actual Node

                if(u.Square==destination)                       // If the Square(wrapped by the current node) is destination, return with shortest path, terminate search
                {
                    return GenPath(u);
                }
                if(u.Distance==INFINITE_DISTANCE)               // rest of Nodes unreachable, so the destination
                {
                    unreachable = true;
                    break;
                }                                   
                
                q.Remove(p.Key);                                // remove entry from Nodes queue(here the dictionary)

                foreach (var square in Graph.EdgesAdjacencyList[u.Square])    // for each neighbor of u
                {
                    if(!q.ContainsKey(square))                                // where square is not removed from q yet
                        continue;                                             

                    int alt = u.Distance + 1;  // u has 1 distance to all its neighbors
                    var v = q[square];         // get the Node from q
                    if (alt < v.Distance)      // Relax (u,v,a)
                    {
                        v.Distance = alt;
                        v.Previous = u;
                    }                   
                }                
            }

            return unreachable ? null : new List<Square>();  // return null if unreachable, empty list means source and destination are same
        }

        private List<Square> GenPath(Node dest)
        {
            var path = new List<Square>();
            while (dest.Previous!=null)
            {
                path.Add(dest.Square);
                dest = dest.Previous;
            }

            path.Reverse();

            return path;
        }


        /// <summary>
        /// Graph Node class for use with the algorithm
        /// It wraps a Square and has additional properties like distance, Previous for use by this algorithm particularly
        /// as long as there is no class of alogos to use Node commonly it is made private for brevity
        /// </summary>
        private class Node
        {
            public Square Square;    // initially null
            public Node Previous;  // initially null 

            public int Distance = INFINITE_DISTANCE; // a very large number for node distance
        }
        
    }

    
}
