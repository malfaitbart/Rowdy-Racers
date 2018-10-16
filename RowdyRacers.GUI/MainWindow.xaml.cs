using RowdyRacers.GUI.Views;
using System.Windows;

namespace RowdyRacers.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLaunchGame(object sender, RoutedEventArgs e)
        {
            new GridWindow().ShowDialog();
        }
    }
}
