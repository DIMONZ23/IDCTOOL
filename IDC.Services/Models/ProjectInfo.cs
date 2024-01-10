using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Models {
    public class ProjectInfo {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? Author { get; set; }
        public DateTime DateModified { get; set; }
        public string? Status { get; set; }
        public string? SettingPath { get; set; }
        public List<BaseRule>? Rules { get; set; }
        //Base file config
        public string BaseFilePath { get; set; }
        public string FileFormat { get; set; }
        public string Encoding { get; set; }
        public string SheetName { get; set; }
        public int StartColumn { get; set; }
        public int StartRow { get; set; }
        public int NumbersOfColumns { get; set; }
        public int NumbersOfRows { get; set; }
    }
}
