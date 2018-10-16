using RowdyRacers.Domain.Gameboard;
using RowdyRacers.Domain.Gameboard.Elements;
using System.Collections.Generic;

namespace RowdyRacers.Domain
{
    public class RowdyRacersGame
    {

        public Grid Grid { get; }
        public List<Player> Players { get; }

        public int CurrentActivePlayerIndex { get; private set; }

        public RowdyRacersGame(Grid grid)
            : this(grid, new List<Player>() {
                new Player("Player 1", grid.Squares[grid.NumberOfRows - 1, 0]),
                new Player("Player 2", grid.Squares[0, grid.NumberOfColumns - 1]) })
        {
        }

        public RowdyRacersGame(Grid grid, List<Player> players)
        {
            Grid = grid;
            Players = players;
        }

        // TODO: Refactoring --> It should not use a string as the type of a moveAction
        public Square PerformMoveAction(string moveAction)
        {
            Square newSquareOfPlayer;
            switch (moveAction)
            {
                case "Up": newSquareOfPlayer = MovePlayerToNewSquare(-1, 0); break;
                case "RightUp": newSquareOfPlayer = MovePlayerToNewSquare(-1, 1); break;
                case "Right": newSquareOfPlayer = MovePlayerToNewSquare(0, 1); break;
                case "RightDown": newSquareOfPlayer = MovePlayerToNewSquare(1, 1); break;
                case "Down": newSquareOfPlayer = MovePlayerToNewSquare(1, 0); break;
                case "LeftDown": newSquareOfPlayer = MovePlayerToNewSquare(1, -1); break;
                case "Left": newSquareOfPlayer = MovePlayerToNewSquare(0, -1); break;
                case "LeftUp": newSquareOfPlayer = MovePlayerToNewSquare(-1, -1); break;
                default: newSquareOfPlayer = MovePlayerToNewSquare(0, 0); break;
            }
            SwitchPlayer();
            return newSquareOfPlayer;
        }

        public void SwitchPlayer()
        {
            CurrentActivePlayerIndex = (CurrentActivePlayerIndex == Players.Count - 1) ? 0 : ++CurrentActivePlayerIndex;
        }

        private Square MovePlayerToNewSquare(int dY, int dX)
        {
            var newY = Players[CurrentActivePlayerIndex].CurrentSquare.Y + dY;
            var newX = Players[CurrentActivePlayerIndex].CurrentSquare.X + dX;
            if (Grid.IsValidPositionInGrid(newY, newX))
            {
                Players[CurrentActivePlayerIndex].CurrentSquare = Grid.Squares[Players[CurrentActivePlayerIndex].CurrentSquare.Y + dY, Players[CurrentActivePlayerIndex].CurrentSquare.X + dX];
            }
            return Players[CurrentActivePlayerIndex].CurrentSquare;

        }

    }
}
