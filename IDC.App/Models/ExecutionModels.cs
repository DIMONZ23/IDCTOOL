using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.App.Models
{
    public class ExecutionItem
    {
        public int ModType { get; set; }
        public string ModName { get; set; }
        public dynamic Setting { get; set; }
    }
    public class ExecutionProject
    {
        public string ProjectName { get; set; }
        public string SaveFileDirectory { get; set; }
        public string BaseFileDirectory { get; set; }
        public string AddFileDirectory { get; set; }
        public List<ExecutionItem> Modifications { get; set; }
    }
}
