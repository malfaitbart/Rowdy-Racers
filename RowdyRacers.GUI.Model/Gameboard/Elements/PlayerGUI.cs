using RowdyRacers.Domain.Gameboard;
using RowdyRacers.Domain.Gameboard.Elements;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RowdyRacers.GUI.Model.Gameboard.Elements
{
    public class PlayerGUI : IDrawable
    {

        public static readonly Brush STROKE_COLOR = Brushes.Black;

        private readonly Rectangle drawableShape;
        private readonly Player playerDomain;

        public string Name{ get => playerDomain.Name; }
        public SquareGUI CurrentSquare { get; private set; }
        public UIElement Drawable { get => drawableShape; }

        public PlayerGUI(Player player, Brush playerColor, SquareGUI initialSquare)
        {
            playerDomain = player;
            CurrentSquare = initialSquare;
            drawableShape = CreateRectangle(playerColor);
        }

        private Rectangle CreateRectangle(Brush playerColor)
        {
            return new Rectangle
            {
                Stroke = STROKE_COLOR,
                Fill = playerColor,
                Height = SquareGUI.SQUARE_SIZE,
                Width = SquareGUI.SQUARE_SIZE
            };
        }

        internal void MoveToNewSquare(SquareGUI squareGUI, Square newSquareDomain)
        {
            CurrentSquare = squareGUI;
            CurrentSquare.SquareDomain = newSquareDomain;
        }
    }
}
