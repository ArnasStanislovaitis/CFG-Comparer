﻿using CGF_Comparer.Models;

namespace CgfComparerAPI.Models
{
    public class CfgModel55
    {
        public string[]? SourceInformation { get; set; }
        public string[]? TargetInformation { get; set; }
        public List<DataComparisonItem>? ComparisonResults {  get; set; } = new List<DataComparisonItem>();
    }
}