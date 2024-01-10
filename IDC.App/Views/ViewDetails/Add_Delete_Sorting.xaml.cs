using IDC.App.Models;
using IDC.App.ProjectManagement.ViewModels;
using IDC.App.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IDC.App.Views.ViewDetails
{
    /// <summary>
    /// Interaction logic for Add_Delete_Shorting.xaml
    /// </summary>
    public partial class Add_Delete_Sorting : UserControl
    {
        private AddDelSortVM _vm;
        public Add_Delete_Sorting(AddDelSortVM vm)
        {
            InitializeComponent();
            _vm = vm;
            DataContext = _vm;
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Nếu ký tự không phải là chữ cái từ A-Z, hủy sự kiện nhập.
            if (!char.IsLetter(e.Text, 0) || char.IsLower(e.Text, 0))
            {
                e.Handled = true;
            }
           
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Ngăn người dùng dán (paste) văn bản vào TextBox.
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                e.Handled = true;
            }
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy ViewModel từ DataContext của UserControl
            if (DataContext is AddDelSortVM viewModel)
            {
                viewModel.SelectedItem = (sender as DataGrid)?.SelectedItem as AddDeleteSortModels;
            }
        }
      


    }
}
