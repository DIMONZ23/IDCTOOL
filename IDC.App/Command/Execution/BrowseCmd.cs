using IDC.App.ProjectManagement.ViewModels;
using IDC.App.ViewModels;
using Microsoft.Win32;
using System.Windows.Input;

namespace IDC.App.Command.Execution
{
    public class BrowseCmd : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private ExecuteViewVM _fileVM;
        public BrowseCmd(ExecuteViewVM vm)
        {
            _fileVM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx, *.xls)|*.xlsx;*.xls";
            if (saveFileDialog.ShowDialog() == true)
            {
                _fileVM.SaveFileDirectory = saveFileDialog.FileName;
            }

        }
    }
}
