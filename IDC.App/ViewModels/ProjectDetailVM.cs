using IDC.App.Command.ProjectManagement;
using IDC.App.ProjectManagement.Command;
using IDC.App.Views;
using IDC.Common.Dictionaries;
using IDC.Common.Models;
using IDC.Services.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace IDC.App.ProjectManagement.ViewModels {
    public class ProjectDetailVM : IViewModel {
        IServiceProvider _serviceProvider = (IServiceProvider)Application.Current.Properties["serviceProvider"];
        private ProjectSettingController settingController;
        public ICommand BrowseCommand { get; set; }
        public ICommand SaveProjectCommand { get; set; }
        private string base_file_;
        public ProjectInfo NewProject { get; set; }
        public bool IsEdit { get; set; } = false;
        public ObservableCollection<string> Encodings { get; set; }
        public ObservableCollection<BaseRule> Rules { get; set; }
        public Dictionary<string, string> fileFormat
        {
            get {
                return FileDictionary.FileFormat;
            }
        }
        public string _selectedFileFormat { get; set; }
        public string SelectedFileFormat {
            get {
                return _selectedFileFormat;
            }
            set {
                _selectedFileFormat = value;
                OnPropertyChanged(nameof(SelectedFileFormat));
            }
        }
        private string _selectedEcoding;
        public string SelectedEcoding {
            get { return _selectedEcoding; }
            set {
                if (_selectedEcoding != value) {
                    _selectedEcoding = value;
                    OnPropertyChanged(nameof(SelectedEcoding));
                }
            }
        }
        public String BaseFilePath {
            get { return base_file_; }
            set {
                base_file_ = value;
                OnPropertyChanged(nameof(BaseFilePath));
            }
        }
        public ProjectDetailVM() {
            settingController = _serviceProvider.GetService<ProjectSettingController>();
            settingController.NewRuleCreated += SettingController_NewRuleCreated;
            Rules = new ObservableCollection<BaseRule>();
            BrowseCommand = new BrowseCommand(this);
            SaveProjectCommand = new SaveProjectCommand(this);
            NewProject = new ProjectInfo() { ProjectName = "thanh dz" };
            Encodings = new ObservableCollection<string>(Encoding.GetEncodings().Select(s => s.Name).ToList());
            if (!IsEdit)
                NewProject = new ProjectInfo();
            Encodings = new ObservableCollection<string>(Encoding.GetEncodings().Select(x => x.DisplayName).ToList());
        }

        private void SettingController_NewRuleCreated(object sender, Controllers.ProjectManagement.NewRuleEventArgs e) {
            Rules.Add(e.NewRule);
        }
        public void SaveProject() {
            settingController.SaveSetting();
            dynamic current_window = Application.Current.Windows.OfType<ProjectDetail>().FirstOrDefault();
            current_window?.Close();
        }
    }
}
