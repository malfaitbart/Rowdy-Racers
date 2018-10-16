
using System;

namespace RowdyRacers.Domain.Gameboard
{
    public class Grid
    {
        public Square[,] Squares { get; }

        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public uint SizeOfASingleSquare { get; private set; }
        public int NumberOfRows { get => Squares.GetLength(0); }
        public int NumberOfColumns { get => Squares.GetLength(1); }

        public Grid(uint width, uint height, uint sizeOfASingleSquare)
        {
            Width = width;
            Height = height;
            SizeOfASingleSquare = sizeOfASingleSquare;
            Squares = GenerateSquares();
        }

        public bool IsValidPositionInGrid(int Y, int X)
        {
            return Y >= 0 && Y < NumberOfRows && X >= 0 && X < NumberOfColumns;
        }

        private Square[,] GenerateSquares()
        {
            var squares = new Square[Height / SizeOfASingleSquare, Width / SizeOfASingleSquare];
            for (int row = 0; row < Height / SizeOfASingleSquare; row++)
            {
                for (int column = 0; column < Width / SizeOfASingleSquare; column++)
                {
                    squares[row, column] = new Square(column, row, SizeOfASingleSquare);
                }
            }
            return squares;
        }

    }
}
