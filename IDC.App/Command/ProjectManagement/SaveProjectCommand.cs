using IDC.App.ProjectManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDC.App.Command.ProjectManagement {
    public class SaveProjectCommand : ICommand {
        public event EventHandler? CanExecuteChanged;
        private ProjectDetailVM vm_;
        public SaveProjectCommand(ProjectDetailVM vm)
        {
            vm_ = vm;
        }
        public bool CanExecute(object? parameter) {
            return true;
        }

        public void Execute(object? parameter) {
            vm_.SaveProject();
        }
    }
}
