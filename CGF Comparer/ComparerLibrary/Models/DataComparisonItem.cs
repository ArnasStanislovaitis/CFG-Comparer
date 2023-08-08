using System.Collections.Generic;

namespace ComparerLibrary
{
    public class DataComparisonItem
    {
        public DataComparisonItem() { }
        public string ID { get; set; }
        public string SourceValue { get; set; } = string.Empty;
        public string TargetValue { get; set; } = string.Empty;
        public ResultsType Type { get; set; }
    }     
}