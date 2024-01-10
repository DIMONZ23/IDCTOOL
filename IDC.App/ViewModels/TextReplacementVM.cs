using IDC.App.Command.ProjectManagement;
using IDC.App.ProjectManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDC.App.ViewModels
{
    public class TextReplacementVM : INotifyPropertyChanged
    {
        private string? findText;
        private string? replacementText;

        public string? FindText
        {
            get
            {
                return findText;
            }
            set
            {
                if (findText != value)
                {
                    findText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? ReplacementText
        {
            get
            {
                return replacementText;
            }
            set
            {
                if (replacementText != value)
                {
                    replacementText = value;
                    OnPropertyChanged();
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
