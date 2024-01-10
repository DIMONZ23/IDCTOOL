using IDC.App.Controllers.ProjectManagement;
using IDC.Common.Models;
using IDC.Services.Implements;
using IDC.Services.Interfaces;
using IDC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDC.App.ProjectManagement {
    public delegate void NewRuleEventHandler(object sender, NewRuleEventArgs e);
    public class ProjectSettingController {
        private ProjectInfo? new_project_ = null;
        private IProjectRepository projectRepository;
        private IRuleRepository savingRules;
        private BaseRule newRule;
        private List<BaseRule> newRules = new List<BaseRule>();
        public event NewRuleEventHandler NewRuleCreated;
        public void CreateNewProject(ProjectInfo? project) {
            new_project_ = project;
        }
        public ProjectInfo? GetProject() {
            return new_project_;
        }
        public ProjectSettingController(IProjectRepository project_repository, IRuleRepository saving_rule)
        {
            projectRepository = project_repository;
            savingRules = saving_rule;
        }
        public void SaveSetting() {
            projectRepository.AddProject(new_project_);
            foreach (var rule in newRules) {
                rule.ProjectInfoId = new_project_.ProjectId;
            }
            savingRules.SaveRules(newRules);
            new_project_.Rules = new List<BaseRule>(newRules);
        }
        public void AddRule(BaseRule new_rule) {
            newRule = new_rule;
            newRules.Add(new_rule);
            NewRuleCreated?.Invoke(this, new NewRuleEventArgs(new_rule));
        }
        public void RemoveRule(BaseRule rule) {  
            newRules.Remove(rule);
        }
    }
}
