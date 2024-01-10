using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Models {
    public static class ConvertRuleData {
        public static string ToString(this BaseRule rule, Type ruleType) {
            StringBuilder sb = new StringBuilder();
            sb.Append($"[{ruleType.FullName}]\n");
            PropertyInfo[] properties = ruleType.GetProperties();
            foreach (PropertyInfo property in properties) {
                sb.Append($"{property.Name}={property.GetValue(rule)}\n");
            }
            return sb.ToString();
        }

        public static BaseRule? CreateRule(string? class_name, Dictionary<string, string> propertiy_values) {
            Type type = Type.GetType(class_name);
            object rule = new object();
            if (type != null) {
                 rule = Activator.CreateInstance(type);
                foreach (var entry in propertiy_values) {
                    SetProperty(type, entry.Key, entry.Value, rule);
                }
            }
            return (BaseRule?)rule;
        }

        private static void SetProperty(Type type, string propertyName, string value, object obj) {
            PropertyInfo property = type.GetProperty(propertyName);
            if (property == null) {
                throw new ArgumentException($"Property '{propertyName}' not found.");
            }
            Type propertyType = property.PropertyType;
            object convertedValue = Convert.ChangeType(value, propertyType);
            if (property.CanWrite) {
                property.SetValue(obj, convertedValue);
            } else {
                throw new ArgumentException($"Property '{propertyName}' not writable.");
            }
        }
    }
}
