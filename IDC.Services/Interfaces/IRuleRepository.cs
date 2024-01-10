using IDC.Common.Models;
using IDC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Interfaces {
    public interface IRuleRepository {
        void SaveRules(List<BaseRule> rules);
        List<BaseRule> GetRules(int project_id);
    }
}
