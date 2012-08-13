using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTravails
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Console program for knights travails problem =====\n\n");

            Console.WriteLine("Please enter source and destination(algenraic notation) \nseparated by space(i.e a8 b7):\n");
            string inp = Console.ReadLine();

            if (!String.IsNullOrEmpty(inp))
            {                
                string[] inpSquares = inp.Split(' ');
                string src = inpSquares[0].Trim().ToLowerInvariant();
                string dest = inpSquares[1].Trim().ToLowerInvariant();


                var board = new ChessBoard();
                var knightGraph = new KnightGraph(board);
                var shortestPathStrategy = new DijkstraStrategy(graph: knightGraph, source: board.Squares[src]);
                var shortestPath = shortestPathStrategy.GetShortestPathTo(board.Squares[dest]);

                Console.WriteLine(String.Format("Shortest Path from {0} to {1}", src, dest));
                foreach (var square in shortestPath)
                {
                    Console.Write(square+" ");
                }

                Console.WriteLine();
            }            
        }
    }
}
