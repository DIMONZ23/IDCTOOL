using IDC.App.ProjectManagement.ViewModels;
using IDC.App.ViewModels;
using IDC.App.Views;
using System.Windows;

namespace IDC.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bnt_Chuyen_Click(object sender, RoutedEventArgs e)
        {
            ProjectDetail baseFile = new ProjectDetail(new ProjectDetailVM());
            baseFile.Show();
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            var mainVM = (MainVM)this.DataContext;
            ExecuteViewVM executeViewVM = new ExecuteViewVM(mainVM.SelectedProject);
            ExecutionScreen executionScreen = new ExecutionScreen(executeViewVM);
            executionScreen.ShowDialog();
        }
    }
}