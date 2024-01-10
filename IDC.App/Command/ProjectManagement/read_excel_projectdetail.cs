using IDC.App.ProjectManagement.ViewModels;
using IDC.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDC.App.Command.ProjectManagement
{
    class ReadEcelProjectDetail : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private ProjectDetailVM _fileVM;
        public ReadEcelProjectDetail(ProjectDetailVM vm) 
        {
            _fileVM = vm;
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
