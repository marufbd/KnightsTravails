using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTravails
{
    public class KnightGraph : ChessBoardPieceGraph
    {        
        public KnightGraph(ChessBoard board) : base(board)
        {
            AdjacencyList=new Dictionary<Square, List<Square>>();

            //initialize graph edges for knights moves
            foreach (var sq in Board.Squares)
            {
                var sqList = new List<Square>();
                var square = sq.Value;
                
                //add edges to eight possible moves for the knight
                var moveSq = Board.GetSquare(square.RowPosition + 2, square.ColPosition + 1);
                if(moveSq!=null) sqList.Add(moveSq);

                moveSq = Board.GetSquare(square.RowPosition + 2, square.ColPosition - 1);
                if (moveSq != null) sqList.Add(moveSq);

                moveSq = Board.GetSquare(square.RowPosition - 2, square.ColPosition + 1);
                if (moveSq != null) sqList.Add(moveSq);

                moveSq = Board.GetSquare(square.RowPosition - 2, square.ColPosition - 1);
                if (moveSq != null) sqList.Add(moveSq);

                moveSq = Board.GetSquare(square.RowPosition + 1, square.ColPosition + 2);
                if (moveSq != null) sqList.Add(moveSq);

                moveSq = Board.GetSquare(square.RowPosition + 1, square.ColPosition - 2);
                if (moveSq != null) sqList.Add(moveSq);

                moveSq = Board.GetSquare(square.RowPosition - 1, square.ColPosition + 2);
                if (moveSq != null) sqList.Add(moveSq);

                moveSq = Board.GetSquare(square.RowPosition - 1, square.ColPosition - 2);
                if (moveSq != null) sqList.Add(moveSq);

                //add the entry to adjacency list
                AdjacencyList.Add(square, sqList);
            }            
        }        
    }
}
