using System.Windows.Media;
using RowdyRacers.Domain.Gameboard;

namespace RowdyRacers.GUI.Model.Gameboard
{
    public class GridGUI
    {

        public static readonly uint GRID_HEIGHT = 750;
        public static readonly uint GRID_WIDTH = 750;
        public static readonly Brush BACKGROUND_COLOR = Brushes.Gray;

        private readonly Grid gridDomain;

        public SquareGUI[,] Squares { get; }

        public int NumberOfRows { get => gridDomain.NumberOfRows; }
        public int NumberOfColumns { get => gridDomain.NumberOfColumns; }

        public GridGUI(Grid grid)
        {
            gridDomain = grid;
            Squares = new SquareGUI[gridDomain.Squares.GetLength(0), gridDomain.Squares.GetLength(1)];
            GenerateSquaresGUI();
        }

        private void GenerateSquaresGUI()
        {
            for (int row = 0; row < gridDomain.Squares.GetLength(0); row++)
            {
                for (int column = 0; column < gridDomain.Squares.GetLength(1); column++)
                {
                    Squares[row, column] = new SquareGUI(gridDomain.Squares[row, column]);
                }
            }
        }
    }
}
