using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IDC.App.ViewModels;

namespace IDC.App.Views.ViewDetails
{
    /// <summary>
    /// Interaction logic for ItemBonding.xaml
    /// </summary>
    public partial class ItemBonding : UserControl
    {
        public ItemBonding()
        {
            InitializeComponent();
            DataContext = new ItemBondingVM();
        }
    }
}
