using IDC.App.ProjectManagement.ViewModels;
using IDC.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace IDC.App.Views
{
    public partial class ProjectDetail : Window
    {
        IServiceProvider _serviceProvider = (IServiceProvider)Application.Current.Properties["serviceProvider"];
        public ProjectDetail(ProjectDetailVM vm)
        {
            InitializeComponent();
            DataContext = vm;
            if(_serviceProvider == null)
            {
                MessageBox.Show("Service Provider loading has failed.");
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ModificationDetail mod = new ModificationDetail(new ModificationDetailVM());
            mod.ShowDialog();
        }
    }
}
