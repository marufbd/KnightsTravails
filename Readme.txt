=====================================================
A VS2010 Console App for the Knights travails problem

Running:
- Just run the KnightsTravails console program, 
it will prompt to enter source and destination squares represented by algebraic notation separated by space. 
For example, you can type: a1 d3
- The program will determine the shortest path for the knight from lower left square of the chessboard(a1) to the square at postition (3, 4) for (Row,Column).

Overview:
- The problem is conceived as a graph theory problem.
Squares of the chessboard represent Vertices and Edges are represented by valid moves between two squares.
For this knights travails problem, a knights graph has been intilialised and 
Dijktra's single-source shortest path algorithm is applied to that graph to determine the shortest path.
