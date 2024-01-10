using IDC.App.ProjectManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDC.App.Command.ProjectManagement
{
    public class EditARS : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private AddDelSortVM _vm;
        public EditARS(AddDelSortVM vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _vm.EditRecord();
        }
    }
}
