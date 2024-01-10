using IDC.App.Models;
using IDC.App.ProjectManagement.ViewModels;
using IDC.App.ViewModels;
using IDC.App.Views.ViewDetails;
using System.Windows;
using System.Windows.Controls;
using static IDC.Common.Dictionaries.Modifications;

namespace IDC.App.Views
{
    /// <summary>
    /// Interaction logic for ModificationDetail.xaml
    /// </summary>
    public partial class ModificationDetail : Window
    {
        private readonly ModificationDetailVM _vm;
        public ModificationDetail(ModificationDetailVM vm)
        {
            InitializeComponent();
            DataContext =_vm = vm;
        }

        private void ModType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ChangeModType(_vm.selectedMod);
        }
        public void ChangeModType(int modType)
        {
            if (_vm.previousMod == _vm.selectedMod)
                return;
            ContentPanel.Children.Clear();

            switch (modType)
            {
                case (int)ModListEnum.Merge:
                    break;
                case (int)ModListEnum.AddRecord:
                    break;
                case (int)ModListEnum.ARSColumns:
                    Add_Delete_Sorting arsView = new Add_Delete_Sorting(new AddDelSortVM());
                    ContentPanel.Children.Add(arsView);
                    break;
                case (int)ModListEnum.CharLimit:
                    break;
                case (int)ModListEnum.Bonding:
                    ItemBonding bonding = new ItemBonding();
                    ContentPanel.Children.Add(bonding);
                    break;
                case (int)ModListEnum.Replace:
                    TextReplacement replace = new TextReplacement();
                    ContentPanel.Children.Add(replace);
                    break;

            }
        }
    }
}
