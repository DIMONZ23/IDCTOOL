using DocumentFormat.OpenXml.Wordprocessing;
using IDC.App.Command.ProjectManagement;
using IDC.App.Models;
using IDC.App.ProjectManagement.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace IDC.App.ProjectManagement.ViewModels
{
    public enum Type
    {
        Add,
        Remove,
        Sort
    }
    public class AddDelSortVM : IViewModel
    {
        public string textNameAdd { get; set; }
        public string TextNameAdd
        {
            get
            {
                return textNameAdd;
            }
            set
            {
                textNameAdd = value;
                OnPropertyChanged(nameof(TextNameAdd));
            }
        }

        public string textColumnAdd { get; set; }
        public string TextColumnAdd
        {
            get => textColumnAdd;
            set
            {
                textColumnAdd = value;
                OnPropertyChanged(nameof(TextColumnAdd));
            }
        }

        public int textOrderAdd { get; set; }
        public int TextOrderAdd
        {
            get => textOrderAdd;
            set
            {
                textOrderAdd = value;
            }
        }

        public ObservableCollection<Type> TypeItems { get; }
        public Type SelectedTypeItems { get; set; }

        private ObservableCollection<AddDeleteSortModels> addData = new ObservableCollection<AddDeleteSortModels>();
        public ObservableCollection<AddDeleteSortModels> AddData
        {
            get => addData;
            set
            {
                addData = value;
                OnPropertyChanged(nameof(AddData));
            }
        }

        private AddDeleteSortModels selectedItem;
        public AddDeleteSortModels SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                
            }
        }
        

      

        public ICommand EditRuleCommand { get; set; }
        public ICommand AddMod { get; }
        public ICommand AddCancel { get; }

        public AddDelSortVM()
        {
            TypeItems = new ObservableCollection<Type>((Type[])Enum.GetValues(typeof(Type)));

            AddMod = new RelayCommand(this);
        }
        public void AddRecord()
        {
            if (!string.IsNullOrEmpty(TextColumnAdd) && !string.IsNullOrEmpty(TextNameAdd) && TextOrderAdd >= 1)
            {

                AddData.Add(new AddDeleteSortModels
                {
                    Order = TextOrderAdd,
                    Name = TextNameAdd,
                    Type = SelectedTypeItems.ToString(),
                    Column = TextColumnAdd
                });
                TextNameAdd = string.Empty;
                TextColumnAdd = string.Empty;
                TextOrderAdd = 0;
            }
            
            
        }
        public void EditRecord()
        {
            if (SelectedItem != null)
            {
                SelectedItem.Name = TextNameAdd; // Cập nhật thuộc tính của SelectedItem với giá trị từ TextBox và ComboBox
                SelectedItem.Column = TextColumnAdd;
                SelectedItem.Type = SelectedTypeItems.ToString();
                // Tùy chọn, bạn có thể muốn cập nhật Order dựa trên logic kinh doanh.

                // Thông báo cho giao diện người dùng về sự thay đổi
                OnPropertyChanged(nameof(AddData));

                // Xóa nội dung của các textbox sau khi chỉnh sửa
                TextNameAdd = string.Empty;
                TextColumnAdd = string.Empty;
                TextOrderAdd = 0;
            }
        }


        public void CancelAdd()
        {
            TextNameAdd = string.Empty;
            TextColumnAdd = string.Empty;
            TextOrderAdd = 0;
        }
        
    }
}
