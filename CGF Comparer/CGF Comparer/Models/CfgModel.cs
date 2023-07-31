﻿using System.Collections.Generic;

namespace CGF_Comparer.Models
{
    public class CfgModel
    {
        public List<FileMetaInfo> SourceMetaInfo { get; set; }
        public List<FileMetaInfo> TargetMetaInfo { get; set; }
        public List<DataComparisonItem> ComparedData { get; set; } = new();
    }
}