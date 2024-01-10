using IDC.App.ProjectManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IDC.App.ViewModels
{
    public class ItemBondingVM : INotifyPropertyChanged
    {
        private string? itemText;
        private string? actionSelectedItem;
        private string? positionSelectedItem;
        private string? item2Text;

        public string? ItemText
        {
            get
            {
                return itemText;
            }
            set
            {
                if (itemText != value)
                {
                    itemText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string>? Action { get; set; } 

        public string? ActionSelectedItem
        {
            get
            {
                return actionSelectedItem;
            }
            set
            {
                if (actionSelectedItem != value)
                {
                    actionSelectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string>? Position { get; set; } 

        public string? PositionSelectedItem
        {
            get
            {
                return positionSelectedItem;
            }
            set
            {
                if (positionSelectedItem != value)
                {
                    positionSelectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? Item2Text
        {
            get
            {
                return Item2Text;
            }
            set
            {
                if (item2Text != value)
                {
                    item2Text = value;
                    OnPropertyChanged();
                }
            }
        }

        public void ItemBonding()
        {
            Action = new ObservableCollection<string>
            {
                 "Add",
                 "Delete",
            };

            Position = new ObservableCollection<string>
            {
                "Front",
                "Back",
            };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
