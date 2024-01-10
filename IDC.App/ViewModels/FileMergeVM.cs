using IDC.App.Command.ProjectManagement;
using IDC.App.ProjectManagement;
using IDC.App.ProjectManagement.ViewModels;
using IDC.App.Views;
using IDC.Common.Models;
using IDC.Services.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IDC.App.ViewModels {
    public class FileMergeVM : IViewModel {
        IServiceProvider _serviceProvider = (IServiceProvider)Application.Current.Properties["serviceProvider"];
        public FileMergeRule Rule { get; set; }
        public ICommand SaveFileMergeRuleCommand { get; set; }
        public ProjectSettingController settingController { get; set; }
        public FileMergeVM()
        {
            Rule = new FileMergeRule();
            SaveFileMergeRuleCommand = new SaveFileMergeRuleCommand(this);
            settingController = _serviceProvider.GetService<ProjectSettingController>();
        }
        public void SaveRule() {
            settingController.AddRule(Rule);
            dynamic current_window = Application.Current.Windows.OfType<FileMergeWindow>().FirstOrDefault();
            current_window?.Close();
        }
    }
}
