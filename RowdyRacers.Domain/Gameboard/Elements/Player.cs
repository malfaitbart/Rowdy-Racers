
namespace RowdyRacers.Domain.Gameboard.Elements
{
    public class Player
    {

        public string Name { get; }
        public Square CurrentSquare { get; set; }

        public Player(string name, Square initialSquare)
        {
            Name = name;
            CurrentSquare = initialSquare;
        }
    }
}
