// See https://aka.ms/new-console-template for more information
using IDC.Common.Models;
using IDC.Services.Implements;
using System.Data.Common;
Console.WriteLine("Hello, World!");
AddColumnRule rule = new AddColumnRule();
ItemBondingRule bondingRule = new ItemBondingRule();
FileMergeRule fileMergeRule = new FileMergeRule();
rule.Action = "hhh";
List<BaseRule> rules = new List<BaseRule>() { rule , bondingRule , fileMergeRule };
IniRuleRepository repo = new IniRuleRepository();
repo.SaveRules(rules);
var rules_ = repo.GetRules(0);
Dictionary<string, string> propertiy_values = new Dictionary<string, string>() {
    { "ColumnIndex","0" },
    {"ColumnName","Thanh manh ok"},
    {"ProcessType","AddColumn"},
    {"Action","hhh"},
    {"ActionName","Add a column"},
    {"ProjectInfoId","0"},
    {"Priority","0" }
};
var xxx = ConvertRuleData.CreateRule("IDC.Common.Models.AddColumnRule", propertiy_values);
Console.ReadLine();