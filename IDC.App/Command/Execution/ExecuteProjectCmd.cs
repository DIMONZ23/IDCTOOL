using IDC.App.ProjectManagement.ViewModels;
using IDC.App.ViewModels;
using System.Windows.Input;

namespace IDC.App.Command.Execution
{
    public class ExecuteProjectCmd : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private ExecuteViewVM vm_;
        public ExecuteProjectCmd(ExecuteViewVM vm)
        {
            vm_ = vm;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            vm_.ExecuteProject();
        }
    }
}
