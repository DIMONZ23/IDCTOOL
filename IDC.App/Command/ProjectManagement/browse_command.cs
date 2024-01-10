using IDC.App.ProjectManagement.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDC.App.ProjectManagement.Command
{
    internal class BrowseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private ProjectDetailVM _fileVM;
        public BrowseCommand(ProjectDetailVM vm)
        {
            _fileVM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files (*.xlsx, *.xls)|*.xlsx;*.xls";
            if (openFileDialog.ShowDialog() == true) 
            {
                _fileVM.BaseFilePath = openFileDialog.FileName; 
            }
           
        }
    }
}
