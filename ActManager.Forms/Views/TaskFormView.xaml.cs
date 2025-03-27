using ActManager.Domain.Models;
using ActManager.Forms.Converters;
using ActManager.Forms.ViewModels;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace ActManager.Forms.Views
{
    /// <summary>
    /// Interaction logic for TaskFormView
    /// </summary>
    public partial class TaskFormView : UserControl
    {
        private readonly GoalStatus[] _allStatuses;
        public TaskFormView()
        {

            InitializeComponent();
            _allStatuses = Enum.GetValues(typeof(GoalStatus)).Cast<GoalStatus>().ToArray();
            var viewModel = new TaskFormViewModel();
            DataContext = viewModel;
            viewModel.SelectedStatusDescription = EnumDescriptionConverter.GetDescription(viewModel.Goal.Status);
        }
        private void ComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender is ComboBox comboBox && DataContext is TaskFormViewModel viewModel)
            {
                var text = comboBox.Text;
                if (string.IsNullOrEmpty(text))
                {
                    comboBox.ItemsSource = _allStatuses;
                }
                else
                {
                    comboBox.ItemsSource = _allStatuses
                        .Where(status => EnumDescriptionConverter.GetDescription(status)
                            .Contains(text, StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                }
                comboBox.IsDropDownOpen = true;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && DataContext is TaskFormViewModel viewModel)
            {
                if (comboBox.SelectedItem is GoalStatus selectedStatus)
                {
                    viewModel.SelectedStatusDescription = EnumDescriptionConverter.GetDescription(selectedStatus);
                }
            }
        }
    }
}
