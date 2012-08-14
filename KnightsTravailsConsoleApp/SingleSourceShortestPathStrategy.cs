using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTravails
{
    public abstract class SingleSourceShortestPathStrategy
    {
        protected ChessBoardPieceGraph Graph;
        protected Square Source;

        protected SingleSourceShortestPathStrategy(Square source, ChessBoardPieceGraph graph)
        {
            Source = source;
            Graph = graph;
        }

        public abstract List<Square> GetShortestPathTo(Square destination);
    }
}
