using RowdyRacers.Domain;
using RowdyRacers.Domain.Gameboard;
using RowdyRacers.GUI.Model.Gameboard;
using RowdyRacers.GUI.Model.Gameboard.Elements;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace RowdyRacers.GUI.Model
{
    public class RowdyRacersOrchestrator
    {

        public GridGUI Grid { get; }
        public IList<PlayerGUI> Players { get; }

        public PlayerGUI CurrentPlayer { get => Players[rowdyRacersGame.CurrentActivePlayerIndex]; }

        private RowdyRacersGame rowdyRacersGame;

        public RowdyRacersOrchestrator()
        {
            rowdyRacersGame = new RowdyRacersGame(new Grid(GridGUI.GRID_WIDTH, GridGUI.GRID_HEIGHT, SquareGUI.SQUARE_SIZE));
            Grid = new GridGUI(rowdyRacersGame.Grid);
            Players = CreatePlayers();
        }

        private IList<PlayerGUI> CreatePlayers()
        {
            var players = new List<PlayerGUI>(rowdyRacersGame.Players.Count)
            {
                // TODO: Refactoring --> For now, limited to only 2 players + Potentionally unsafe.
                new PlayerGUI(rowdyRacersGame.Players[0], Brushes.DarkRed, Grid.Squares[Grid.NumberOfRows - 1, 0]),
                new PlayerGUI(rowdyRacersGame.Players[1], Brushes.DarkSlateBlue, Grid.Squares[0, Grid.NumberOfColumns - 1])
            };
            return players;
        }

        public void MoveCurrentPlayerUp() { MovePlayer("Up"); }
        public void MoveCurrentPlayerRightUp() { MovePlayer("RightUp"); }
        public void MoveCurrentPlayerRight() { MovePlayer("Right"); }
        public void MoveCurrentPlayerRightDown() { MovePlayer("RightDown"); }
        public void MoveCurrentPlayerDown() { MovePlayer("Down"); }
        public void MoveCurrentPlayerLeftDown() { MovePlayer("LeftDown"); }
        public void MoveCurrentPlayerLeft() { MovePlayer("Left"); }
        public void MoveCurrentPlayerLeftUp() { MovePlayer("LeftUp"); }

        // Todo: moveAction should not be a string
        private void MovePlayer(string moveAction)
        {
            var currentMovingPlayer = CurrentPlayer;
            var movedToSquare = rowdyRacersGame.PerformMoveAction(moveAction);
            currentMovingPlayer.MoveToNewSquare(Grid.Squares[movedToSquare.Y, movedToSquare.X], movedToSquare);
        }

    }
}
