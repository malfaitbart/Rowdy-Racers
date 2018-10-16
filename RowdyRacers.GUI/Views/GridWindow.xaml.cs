
using RowdyRacers.GUI.Model;
using RowdyRacers.GUI.Model.Gameboard;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RowdyRacers.GUI.Views
{
    /// <summary>
    /// Interaction logic for GridWindow.xaml
    /// </summary>
    public partial class GridWindow : Window
    {

        public static readonly uint WINDOW_HEIGHT = 950;
        public static readonly uint WINDOW_WIDTH = 1450;

        private readonly RowdyRacersOrchestrator rowdyRacers;

        public GridWindow()
        {
            InitializeComponent();

            Height = WINDOW_HEIGHT;
            Width = WINDOW_WIDTH;

            rowdyRacers = new RowdyRacersOrchestrator();

            ConfigureCanvas();
            Draw();
        }

        private void ConfigureCanvas()
        {
            gridCanvas.Height = GridGUI.GRID_HEIGHT;
            gridCanvas.Width = GridGUI.GRID_WIDTH;
            gridCanvas.Background = GridGUI.BACKGROUND_COLOR;
        }

        private void Draw()
        {
            gridCanvas.Children.Clear();
            DrawSquaresOfGrid();
            DrawPlayers();
        }

        private void DrawPlayers()
        {
            foreach (var player in rowdyRacers.Players)
            {
                gridCanvas.Children.Add(player.Drawable);
                Canvas.SetTop(player.Drawable, player.CurrentSquare.YCoordinate * player.CurrentSquare.Size);
                Canvas.SetLeft(player.Drawable, player.CurrentSquare.XCoordinate * player.CurrentSquare.Size);
            }
        }

        private void DrawSquaresOfGrid()
        {
            foreach (var square in rowdyRacers.Grid.Squares)
            {
                gridCanvas.Children.Add(square.Drawable);
                Canvas.SetTop(square.Drawable, square.YCoordinate * square.Size);
                Canvas.SetLeft(square.Drawable, square.XCoordinate * square.Size);
            }
        }

        private void ButtonUpClicked(object sender, RoutedEventArgs e)
        {
            rowdyRacers.MoveCurrentPlayerUp();
            Draw();
        }

        private void ButtonRightUpClicked(object sender, RoutedEventArgs e)
        {
            rowdyRacers.MoveCurrentPlayerRightUp();
            Draw();
        }

        private void ButtonRightClicked(object sender, RoutedEventArgs e)
        {
            rowdyRacers.MoveCurrentPlayerRight();
            Draw();
        }

        private void ButtonRightDownClicked(object sender, RoutedEventArgs e)
        {
            rowdyRacers.MoveCurrentPlayerRightDown();
            Draw();
        }

        private void ButtonDownClicked(object sender, RoutedEventArgs e)
        {
            rowdyRacers.MoveCurrentPlayerDown();
            Draw();
        }

        private void ButtonLeftDownClicked(object sender, RoutedEventArgs e)
        {
            rowdyRacers.MoveCurrentPlayerLeftDown();
            Draw();
        }


        private void ButtonLeftClicked(object sender, RoutedEventArgs e)
        {
            rowdyRacers.MoveCurrentPlayerLeft();
            Draw();
        }


        private void ButtonLeftUpClicked(object sender, RoutedEventArgs e)
        {
            rowdyRacers.MoveCurrentPlayerLeftUp();
            Draw();
        }
    }
}
