using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IDC.App.Command.Execution;
using IDC.App.Models;
using IDC.App.ViewModels;

namespace IDC.App.Views
{
    /// <summary>
    /// Interaction logic for ExecutionScreen.xaml
    /// </summary>
    public partial class ExecutionScreen : Window
    {
        ExecuteViewVM _vm;
        public ExecutionScreen(ExecuteViewVM vm)
        {
            InitializeComponent();
            _vm = vm;
            DataContext = _vm;
            _getRule = new ExecuteProjectCmd(_vm);
        }
        ICommand _getRule { get; set; }
        private void browseSaveFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
