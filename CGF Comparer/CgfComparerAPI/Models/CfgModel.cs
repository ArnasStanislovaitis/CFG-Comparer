﻿using CGF_Comparer;

namespace CgfComparerAPI.Models
{
    public class CfgModel
    {
        public string[]? SourceInformation { get; set; }
        public string[]? TargetInformation { get; set; }
        public List<ModelCFG>? ComparisonResults {  get; set; } = new List<ModelCFG>();
    }
}