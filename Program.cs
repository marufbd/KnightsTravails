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
            
            Console.WriteLine("Please enter source and destination(algebraic notation) \nseparated by space(i.e a8 b7):\n");
            string inp = Console.ReadLine();

            while (!String.IsNullOrEmpty(inp) && !inp.ToLowerInvariant().Equals("q") )
            {                
                string[] inpSquares = inp.Split(' ');
                string src = inpSquares[0].Trim().ToLowerInvariant();
                string dest = inpSquares[1].Trim().ToLowerInvariant();


                var board = new ChessBoard();
                var knightGraph = new KnightGraph(board);
                var shortestPathStrategy = new DijkstraAlgorithm(graph: knightGraph, source: board.Squares[src]);
                var shortestPath = shortestPathStrategy.GetShortestPathTo(board.Squares[dest]);

                Console.WriteLine(String.Format("Shortest Path from {0} to {1} : ", src, dest));
                if(shortestPath==null) 
                    Console.WriteLine("unreachable");
                else
                    shortestPath.ForEach(sq=>Console.Write(sq+" "));
                
                Console.Write("\nWant to continue?(y/n)");
                string cont = Console.ReadLine();
                if(!cont.ToLowerInvariant().Equals("y"))
                    break;

                Console.WriteLine("\nEnter source and destination separated by space");
                inp = Console.ReadLine();
            }

            Console.WriteLine();
        }

    }
}
