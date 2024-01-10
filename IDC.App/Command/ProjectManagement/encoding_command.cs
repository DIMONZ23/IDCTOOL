using IDC.App.ProjectManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDC.App.Command.ProjectManagement
{
    internal class EncodingCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private ProjectDetailVM _fileVM;

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public EncodingCommand(ProjectDetailVM vm)
        {
            _fileVM = vm;
        }

        public void Execute(object? parameter)
        {
            //if (_fileVM != null)
            //{
            //    _fileVM.Encodings.Clear(); 
            //    foreach (var encodingInfo in Encoding.GetEncodings())
            //    {
            //        _fileVM.Encodings.Add(encodingInfo);
            //    }
            //}

        }
    }
}
