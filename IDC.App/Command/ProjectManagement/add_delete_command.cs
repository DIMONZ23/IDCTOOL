using IDC.App.ProjectManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDC.App.ProjectManagement.Command {
    internal class AddDeleteCommand : ICommand {
        public event EventHandler? CanExecuteChanged;
        private MainVM vm_;
        public AddDeleteCommand(MainVM vm)
        {
            vm_ = vm;
        }
        public bool CanExecute(object? parameter) {
            return true;
        }

        public void Execute(object? parameter) {
            vm_.AddDeleteProject();
        }
    }
}
