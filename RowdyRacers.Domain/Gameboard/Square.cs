
namespace RowdyRacers.Domain.Gameboard
{
    public class Square
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public uint Size { get; private set; }

        public Square(int xCoordinate, int yCoordinate, uint size)
        {
            X = xCoordinate;
            Y = yCoordinate;
            Size = size;
        }
    }
}
