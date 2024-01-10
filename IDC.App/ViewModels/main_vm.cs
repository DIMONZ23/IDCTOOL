using IDC.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using IDC.App.ProjectManagement.Command;
using IDC.Services.Interfaces;
using IDC.App.Views;
using IDC.Services.Models;

namespace IDC.App.ProjectManagement.ViewModels {
    public class MainVM : IViewModel {
        public ObservableCollection<ProjectInfo> ProjectList { get; set; }
        private string project_name_ = string.Empty;
        public string ProjectName {
            get { return project_name_; } 
            set { project_name_ = value; 
                OnPropertyChanged(nameof(ProjectName)); }
        }
        public ProjectInfo SelectedProject { get; set; }
        public int CurrentIndex { get; set; }
        public ICommand GotFocusCommand {  get; set; }
        public ICommand AddDeleteCommand { get; set; }
        private IProjectRepository project_repository_ = null;
        private ProjectSettingController setting_controler_ = null;
        public MainVM(IProjectRepository project_repository, ProjectSettingController setting_controller)
        {
            ProjectName = "Search for project";
            List<ProjectInfo> projects = new List<ProjectInfo> {
                new ProjectInfo() {DateModified = DateTime.Now }
            };
            projects.AddRange(project_repository.GetProjects());
            ProjectList = new ObservableCollection<ProjectInfo>(projects);
            GotFocusCommand = new GotFocusCommand(this);
            AddDeleteCommand = new AddDeleteCommand(this);
            project_repository_ = project_repository;
            setting_controler_ = setting_controller;
        }
        public void AddDeleteProject() {
            if (CurrentIndex == 0) {
                setting_controler_.CreateNewProject(SelectedProject);
                ProjectDetail base_file_window = new ProjectDetail(new ProjectDetailVM());
                base_file_window.Show();
            } else {
                project_repository_.DeleteProject(SelectedProject);
                ProjectList.Remove(SelectedProject);
            }
        }
    }
}
