using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ActManager.Modules.Buildings.Helpers
{
    public class SelectableItemsControl : ItemsControl
    {
        // DependencyProperty для SelectedItem
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(object),
                typeof(SelectableItemsControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        // Событие SelectionChanged
        public static readonly RoutedEvent SelectionChangedEvent =
            EventManager.RegisterRoutedEvent(
                nameof(SelectionChanged),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(SelectableItemsControl));

        public event RoutedEventHandler SelectionChanged
        {
            add => AddHandler(SelectionChangedEvent, value);
            remove => RemoveHandler(SelectionChangedEvent, value);
        }

        // Attached Property IsSelected для контейнеров
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.RegisterAttached(
                "IsSelected",
                typeof(bool),
                typeof(SelectableItemsControl),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

        public static bool GetIsSelected(DependencyObject obj) =>
            (bool)obj.GetValue(IsSelectedProperty);

        public static void SetIsSelected(DependencyObject obj, bool value) =>
            obj.SetValue(IsSelectedProperty, value);

        // Callback для изменения SelectedItem
        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (SelectableItemsControl)d;
            control.UpdateAllContainers();
            control.RaiseSelectionChangedEvent(e.OldValue, e.NewValue);
        }

        // Вызов события SelectionChanged
        private void RaiseSelectionChangedEvent(object oldValue, object newValue)
        {
            var args = new RoutedEventArgs(SelectionChangedEvent) { Source = this };
            RaiseEvent(args);
        }

        // Переопределяем метод подготовки контейнера
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            var container = element as FrameworkElement;

            if (container != null)
            {
                // Привязываем обработчик клика
                container.MouseLeftButtonDown -= ItemContainer_MouseLeftButtonDown;
                container.MouseLeftButtonDown += ItemContainer_MouseLeftButtonDown;

                // Устанавливаем начальное состояние IsSelected
                SetIsSelected(container, item == SelectedItem);
            }
        }

        // Обработчик клика по элементу
        private void ItemContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var container = sender as FrameworkElement;
            var item = container?.DataContext;
            if (item != null)
            {
                SelectedItem = item;
                e.Handled = true;
            }
        }

        // Обновление состояния всех контейнеров
        private void UpdateAllContainers()
        {
            foreach (var item in Items)
            {
                var container = ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                if (container != null)
                {
                    SetIsSelected(container, item == SelectedItem);
                }
            }
        }

        // Переопределяем очистку контейнера
        protected override void ClearContainerForItemOverride(DependencyObject element, object item)
        {
            var container = element as FrameworkElement;
            if (container != null)
            {
                container.MouseLeftButtonDown -= ItemContainer_MouseLeftButtonDown;
            }
            base.ClearContainerForItemOverride(element, item);
        }
    }
}
