using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTravails
{
    public abstract class ChessBoardPieceGraph
    {
        protected ChessBoard Board;

        protected Dictionary<Square, List<Square>> AdjacencyList;

        protected ChessBoardPieceGraph(ChessBoard board)
        {
            Board = board;
        }

        public Dictionary<Square, List<Square>> EdgesAdjacencyList { get { return AdjacencyList; } }
        public IEnumerable<Square> Vertexes { get { return Board.Squares.Select(x=>x.Value); } }
    }
}
