using IDC.App.ProjectManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDC.App.Command.ProjectManagement
{
    class ImportCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private ProjectDetailVM fileVM;
        public ImportCommand(ProjectDetailVM fileVM)
        {
            this.fileVM = fileVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            
        }
    }
}
