using ActManager.Events;
using Prism.Events;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ActManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool C0IsCollapsed = false;
        private readonly Duration _animationDuration = new Duration(TimeSpan.FromSeconds(0.3));

        public MainWindow(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<PanelToggleEvent>().Subscribe(AnimatePanel);

            InitializeComponent();
        }
        private void AnimatePanel(bool show)
        {
            // Анимация выдвижения панели
            var panelAnimation = new DoubleAnimation
            {
                Duration = _animationDuration,
                EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseInOut},
                To = show ? 0 : 600
            };

            // Анимация затемнения
            var overlayAnimation = new DoubleAnimation
            {
                Duration = _animationDuration,
                EasingFunction = new QuadraticEase(),
                To = show ? 0.5 : 0
            };


            overlayAnimation.Completed += (s, e) =>
            {
                Overlay.Visibility = show ? Visibility.Visible : Visibility.Hidden;
            };

            if (show)
            {
                Overlay.Visibility = Visibility.Visible;
                ShadowRightRegion.Opacity = 1;
            }
            else
            {
                ShadowRightRegion.Opacity = 0;
            }

                PanelTransform.BeginAnimation(TranslateTransform.XProperty, panelAnimation);
            Overlay.BeginAnimation(Border.OpacityProperty, overlayAnimation);
        }

        private void Overlay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AnimatePanel(false);
        }
    }
}
