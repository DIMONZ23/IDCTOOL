using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IDC.App.ProjectManagement.ViewModels {
    public class IViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _browserFilePath { get; set; }
        public string BrowserFilePath
        {
            get { return _browserFilePath; }
            set
            {
                _browserFilePath = value;
                OnPropertyChanged(nameof(BrowserFilePath));
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string property_name = null)
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
