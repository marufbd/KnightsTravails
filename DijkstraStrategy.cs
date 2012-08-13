using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTravails
{
    public class DijkstraStrategy : SingleSourceShortestPathStrategy
    {
        private const int MAX_DISTANCE = 256;

        public DijkstraStrategy(Square source, ChessBoardPieceGraph graph) : base(source, graph)
        {
            //might want to initialize shortest paths to all destinations
        }

        public override List<Square> GetShortestPathTo(Square destination)
        {
            var sourceNode = new Node() {Square = Source};
            sourceNode.Distance = 0;
            var q = new List<Node>();
            q.Add(sourceNode);
            Graph.Vertexes.Where(sq => sq != Source).Select(sq => new Node() {Square = sq}).ToList().ForEach(
                n => q.Add(n));
            
            while (q.Count!=0)
            {
                var u = q.First();

                if(u.Square.Equals(destination))
                {
                    return GenPath(u);
                }
                if(u.Distance==MAX_DISTANCE)
                    break;
                q.Remove(u);

                foreach (var square in Graph.EdgesAdjacencyList[u.Square])
                {
                    if(!q.Where(n=>n.Square==square).Any())
                        continue;

                    int alt = u.Distance + 1;  // u has 1 distamce to all neighbors
                    var v = q.Single(n => n.Square==square);
                    if(alt<v.Distance)
                    {
                        v.Distance = alt;
                        v.Previous = u;
                    }                   
                }

                q = q.OrderBy(n => n.Distance).ToList();
            }            
            
            return new List<Square>();
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

        private class Node
        {
            public Square Square;    // initially null
            public Node Previous;  // initially null 

            public int Distance = MAX_DISTANCE; // a very large number for node distance
        }
    }
    
}
