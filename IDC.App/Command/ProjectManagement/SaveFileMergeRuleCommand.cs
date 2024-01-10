using IDC.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDC.App.Command.ProjectManagement {
    public class SaveFileMergeRuleCommand : ICommand {
        public event EventHandler? CanExecuteChanged;
        private FileMergeVM _vm;
        public SaveFileMergeRuleCommand(FileMergeVM vm)
        {
            _vm = vm;
        }
        public bool CanExecute(object? parameter) {
            return true;
        }

        public void Execute(object? parameter) {
            _vm.SaveRule();
        }
    }
}
