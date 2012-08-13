using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTravails
{
    public class ChessBoard
    {
        private int _row = 8;
        private int _col = 8;

        private const string Alphabets = "abcdefgh";

        public readonly Dictionary<string, Square> Squares = new Dictionary<string, Square>();

        public ChessBoard()
        {
            for (int i = 0; i < _row; i++)
            {
                Char ch = 'a';
                for (var j = 0; j < _col; j++)
                {
                    string key = "" + Alphabets[j] + (i + 1);
                    Squares.Add(key, new Square(key, i + 1, j + 1));
                }
            }
        }
        
        public Square GetSquare(int  row, int col)
        {
            if (row > _row || row < 1 || col > _col || col < 1) return null;

            return Squares["" + Alphabets[col-1] + row];
        }
    }

    public class Square
    {
        private readonly string _key;

        public int RowPosition = -1;
        public int ColPosition = -1;
        
        public Square(string key, int rPos, int cPos)
        {
            this._key = key;
            this.RowPosition = rPos;
            this.ColPosition = cPos;
        }

        public override string ToString()
        {
            return _key;
        }
    }
}
