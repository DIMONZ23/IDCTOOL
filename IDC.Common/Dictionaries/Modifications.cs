using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Common.Dictionaries
{
    public class Modifications
    {
        public static Dictionary<int, string> ModList = new Dictionary<int, string>
        {
            { 1,"Merge" },
            { 2,"Additional Record"},
            { 3,"Add/Remove/Sorting Columns"},
            { 4,"Item Bonding"},
            { 5,"Character Limit"},
            { 6,"Text Replacement"}
        };
        public enum ModListEnum
        {
            Merge=1,
            AddRecord,
            ARSColumns,
            Bonding,
            CharLimit,
            Replace
        }
    }
}
