using IDC.Common.Models;
using IDC.Services.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.App.Controllers.ProjectManagement {
    public class NewRuleEventArgs: EventArgs {
        public BaseRule NewRule { get; set; }
        public NewRuleEventArgs(BaseRule rule)
        {
            NewRule = rule;
        }
    }
}
