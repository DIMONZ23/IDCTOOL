using IDC.App.ProjectManagement.ViewModels;
using System;
using System.Windows.Input;

namespace IDC.App.ProjectManagement.Command
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private AddDelSortVM _vm;
        public RelayCommand(AddDelSortVM vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _vm.AddRecord();
        }
    }
}
