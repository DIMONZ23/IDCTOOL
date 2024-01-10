namespace IDC.Common.Dictionaries
{
    public class FileDictionary
    {
        public static Dictionary<string, string> FileFormat = new Dictionary<string, string>()
        {
            {"Excel","*.xlsx|*.xls" },
            {"CSV","*.csv" },
            {"TSV","*.tsv" }
        };
    }
}
