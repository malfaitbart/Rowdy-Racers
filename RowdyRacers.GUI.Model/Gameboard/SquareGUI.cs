using RowdyRacers.Domain.Gameboard;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RowdyRacers.GUI.Model.Gameboard
{
    public class SquareGUI : IDrawable
    {

        public static readonly uint SQUARE_SIZE = 50;
        public static readonly Brush BACKGROUND_COLOR = Brushes.Orange;
        public static readonly Brush STROKE_COLOR = Brushes.Black;

        private readonly Rectangle drawableShape;
        public Square SquareDomain { get; set;  }

        public int XCoordinate { get => SquareDomain.X; }
        public int YCoordinate { get => SquareDomain.Y; }
        public uint Size { get => SquareDomain.Size; }
        public UIElement Drawable { get => drawableShape; }

        internal SquareGUI(Square square)
        {
            SquareDomain = square;
            drawableShape = CreateUIElement();
            AddMouseDownEventTo(drawableShape);
        }

        private void AddMouseDownEventTo(Rectangle rectangle)
        {
            rectangle.AddHandler(Rectangle.MouseDownEvent, (RoutedEventHandler)HandleEvent);
        }

        private void HandleEvent(object sender, RoutedEventArgs e)
        {
            if (e is MouseButtonEventArgs)
            {
                ((Rectangle)sender).Fill = Brushes.Aqua;
            }
        }

        public Rectangle CreateUIElement()
        {
            return new Rectangle
            {
                Stroke = STROKE_COLOR,
                Fill = BACKGROUND_COLOR,
                Height = SquareDomain.Size,
                Width = SquareDomain.Size
            };
        }

    }
}
