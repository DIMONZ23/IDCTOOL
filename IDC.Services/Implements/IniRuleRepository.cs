using IDC.Common.Models;
using IDC.Services.Interfaces;
using IDC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Implements {
    public class IniRuleRepository : IRuleRepository {
        private string setting_path = "{0}\\..\\..\\..\\ProjectConfig\\setting_{1}.ini";
        private string PATH = "{0}\\..\\..\\..\\ProjectConfig";
        public List<BaseRule> GetRules(int project_id) {
            string path = string.Format(setting_path, Directory.GetCurrentDirectory(), project_id);
            List<BaseRule> rules = new List<BaseRule>();
            string class_name = string.Empty;
            bool is_start = false;
            Dictionary<string, string> property_values = new Dictionary<string, string>();

            foreach (var line in File.ReadLines(path)) {
                string trimmed_line = line.Trim();
                if (trimmed_line.StartsWith("[") && trimmed_line.EndsWith("]")) {
                    if (is_start) {
                        BaseRule rule = ConvertRuleData.CreateRule(class_name, property_values);
                        rules.Add(rule);
                        property_values.Clear();
                    }
                    class_name = trimmed_line.Substring(1, trimmed_line.Length - 2);
                } else if (trimmed_line.Length != 0) {
                    string[] data = trimmed_line.Split(new char[] { '=' });
                    property_values.Add(data[0], data[1]);
                }
                is_start = true;
            }
            rules.Add(ConvertRuleData.CreateRule(class_name, property_values));
            return rules;
        }

        public void SaveRules(List<BaseRule> rules) {
            StringBuilder content = new StringBuilder();
            foreach (BaseRule rule in rules) {
                content.Append(ConvertRuleData.ToString(rule, rule.GetType()));
            }
            int project_id = rules.First().ProjectInfoId;
            string path = string.Format(PATH, Directory.GetCurrentDirectory());
            string file_name = string.Format(setting_path, Directory.GetCurrentDirectory(), project_id);
            Directory.CreateDirectory(path);
            using (StreamWriter writer = new StreamWriter(file_name, false, Encoding.UTF8)) {
                writer.Write(content.ToString());
            }
        }
    }
}
