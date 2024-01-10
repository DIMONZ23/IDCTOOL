using DocumentFormat.OpenXml.Spreadsheet;
using IDC.App.Command.Execution;
using IDC.App.ProjectManagement.ViewModels;
using IDC.Common.Models;
using IDC.Services.Interfaces;
using IDC.Services.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IDC.App.ViewModels
{
    public class ExecuteViewVM : IViewModel
    {
        private IServiceProvider svc = (IServiceProvider)Application.Current.Properties["serviceProvider"];
        private IRuleRepository _iniSettingSvc;
        private IExcelServices _excelSvc;
        public ICommand browseFile { get; set; }
        public ICommand executeCmd { get; set; }
        private readonly int _projectId;
        public ExecuteViewVM(ProjectInfo projectInfo)
        {
            _projectInfo = projectInfo;
            ProjectName = _projectInfo.ProjectName;
            _iniSettingSvc = svc.GetRequiredService<IRuleRepository>();
            _excelSvc = svc.GetRequiredService<IExcelServices>();
            browseFile = new BrowseCmd(this);
            executeCmd = new ExecuteProjectCmd(this);
        }
        private ProjectInfo _projectInfo { get; set; }
        public string _projectName { get; set; }
        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                _projectName = value;
                OnPropertyChanged(nameof(ProjectName));
            }
        }
        public string _saveFileDirectory { get; set; }
        public string SaveFileDirectory
        {
            get { return _saveFileDirectory; }
            set
            {
                _saveFileDirectory = value;
                OnPropertyChanged(nameof(SaveFileDirectory));
            }
        }
        public void ExecuteProject()
        {
            try
            {
                var ruleList = _iniSettingSvc.GetRules(_projectInfo.ProjectId);
                SheetData processingData = new SheetData();
                foreach (var rule in ruleList.OrderByDescending(x => x.Priority))
                {
                    processingData=rule.Execute(_excelSvc, _projectInfo);
                }
                _excelSvc.SaveExcelFile(processingData, _saveFileDirectory);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
