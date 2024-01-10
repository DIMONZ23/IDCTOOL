using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.App.Models
{
    public class EncodingItem
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public Encoding EncodingInfo { get; set; }
        public static EncodingItem Generate(Encoding encodingInfo,List<EncodingItem> items)
        {
            return new EncodingItem
            {
                Key = ((items == null || items.Count == 0)? 1:items.Select(x => x.Key).Max()) + 1,
                Value = encodingInfo.EncodingName,
                EncodingInfo = encodingInfo
            };
        }
    }
}
