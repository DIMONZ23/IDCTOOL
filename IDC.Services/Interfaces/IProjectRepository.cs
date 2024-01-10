using IDC.Common.Models;
using IDC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Interfaces {
    public interface IProjectRepository {
        ICollection<ProjectInfo> GetProjects();
        ProjectInfo? GetProject(int project_id);
        void DeleteProject(ProjectInfo project);
        void AddProject(ProjectInfo project);
        void UpdateProject(ProjectInfo project);
    }
}
