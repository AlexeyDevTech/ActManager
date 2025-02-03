using System.Windows;

namespace ActManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool C0IsCollapsed = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!C0IsCollapsed)
                C0.Width = new GridLength(280,GridUnitType.Pixel);
            else
                C0.Width = new GridLength(8, GridUnitType.Star);
            C0IsCollapsed = !C0IsCollapsed;
        }
    }
}
