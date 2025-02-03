using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;

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
                C0.Width = new GridLength(280, GridUnitType.Pixel);
            else
                C0.Width = new GridLength(8, GridUnitType.Star);

            var rotateTransform = new RotateTransform
            {
                Angle = C0IsCollapsed ? 0 : 180
            };
            leftCollapseButton.RenderTransform = rotateTransform;
            leftCollapseButton.RenderTransformOrigin = new Point(0.5, 0.5);
            C0IsCollapsed = !C0IsCollapsed;
        }
    }
}
