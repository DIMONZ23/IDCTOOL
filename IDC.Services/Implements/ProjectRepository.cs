using DocumentFormat.OpenXml.ExtendedProperties;
using IDC.Common.Models;
using IDC.Services.Interfaces;
using IDC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Implements {
    public class ProjectRepository : IProjectRepository {
        private string list_project_filepath_ = Directory.GetCurrentDirectory() + "\\..\\..\\..\\ProjectConfig\\project_list.ini";
        private List<ProjectInfo> project_list_ = new List<ProjectInfo>();
        #region IProjectRepository
        public void AddProject(ProjectInfo project) {
            int max_id = project_list_.Count == 0?0:project_list_.Max(s => s.ProjectId);
            project.ProjectId = max_id + 1;
            project_list_.Add(project);
            SaveSetting();
        }

        public void DeleteProject(ProjectInfo project) {
            ProjectInfo? delete_project = project_list_.FirstOrDefault(s => s.ProjectId == project.ProjectId);
            if (delete_project != null) {
                project_list_.Remove(delete_project);
                SaveSetting();
            }
        }

        public ProjectInfo? GetProject(int project_id) {
            return project_list_.FirstOrDefault(s => s.ProjectId == project_id);
        }

        public ICollection<ProjectInfo> GetProjects() {
            string project_name = string.Empty;
            string[] data = new string[5];
            int current_index = 0;
            ProjectInfo temp_project = new ProjectInfo();
            foreach (var line in File.ReadLines(list_project_filepath_)) {
                string trimmed_line = line.Trim();
                if (trimmed_line.StartsWith("[") && trimmed_line.EndsWith("]")) {
                    project_name = trimmed_line.Substring(1, trimmed_line.Length - 2);
                } else if (trimmed_line.Length != 0) {
                    data[current_index++] = trimmed_line;
                    if (current_index == 5) {
                        current_index = 0;
                        CreateProject(temp_project, project_name, data);
                        project_list_.Add(temp_project);
                        temp_project = new ProjectInfo();
                    }
                }
            }
            return project_list_.ToList();
        }
        public void UpdateProject(ProjectInfo project) {
            ProjectInfo? update_project = project_list_.FirstOrDefault(s => s.ProjectId == project.ProjectId);
            if (update_project != null) {
                update_project.ProjectName = project.ProjectName;
                update_project.ProjectId = project.ProjectId;
                update_project.Author = project.Author;
                update_project.Status = project.Status;
                update_project.SettingPath = project.SettingPath;
                update_project.DateModified = project.DateModified;
                SaveSetting();
            }
        }
        #endregion
        #region PrivateMethods
        private void CreateProject(ProjectInfo project, string project_name, string[] data) {
            project.ProjectName = project_name;
            project.ProjectId = int.Parse(data[0]);
            project.Author = data[1];
            project.DateModified = DateTime.Parse(data[2]);
            project.Status = data[3];
            project.SettingPath = data[4];
        }
        private void SaveSetting() {
            using (StreamWriter writer = new StreamWriter(list_project_filepath_, false, Encoding.UTF8)) {
                foreach (ProjectInfo project in project_list_) {
                    writer.WriteLine($"[{project.ProjectName}]");
                    writer.WriteLine($"{project.ProjectId}");
                    writer.WriteLine($"{project.Author}");
                    writer.WriteLine($"{project.DateModified}");
                    writer.WriteLine($"{project.Status}");
                    writer.WriteLine($"{project.SettingPath}");
                    writer.WriteLine();
                }
            }
        }
        #endregion
    }
}
